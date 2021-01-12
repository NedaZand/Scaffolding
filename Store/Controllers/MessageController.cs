using Store.Models;
using Store.WebEssential.Mvc;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Text;
using Microsoft.AspNet.Identity;
using Store.Core.CommonHelper;
using Store.WebEssential.ModelBinder;
using Store.WebEssential.UserControl;
using Store.Service.User;
using Store.WebEssential.Extensions;
using System.Configuration;
using Store.Service.Stores;
using Store.Core.Domain.StoreTables;
using Store.Models.Stores;
using Store.WebEssential.Helper;
using Store.Service;
using Store.Essential.Model;
using Store.Core.Domain.StoreTables.StoreRoom;
using Store.Models.Stores.StoreRoom;

namespace Store.Controllers
{
    [Authorize]
    public class MessageController : BaseController
    {
        #region Fields
        private readonly IMessageService _messageService;
        private readonly ICheckingRole _checkingRoleService;
        private readonly IScaffoldingService _scaffoldingService;
        private readonly IUserService _userService;
        #endregion
        #region Ctor

        public MessageController(IUserService userService,IMessageService messageService, ICheckingRole checkingRoleService, IScaffoldingService scaffoldingService)
        {
            _messageService = messageService;
            _checkingRoleService = checkingRoleService;
            _scaffoldingService = scaffoldingService;
            _userService = userService;
        }
        #endregion
        #region Utilities

        [NonAction]
        public void PrepareAllScaffoldings(MessageModel model)
        {
            var units = _scaffoldingService.GetAll();

            model.Scaffoldings = (from c in units
                               select new SelectListItem
                               {
                                   Text = c.Title,
                                   Value = c.Id.ToString(),
                                   Selected = false
                               }).ToList();
            model.Scaffoldings.Add(new SelectListItem
            {
                Text = "انتخاب داربست ",
                Value = "",
                Selected = true
            });
        }

        #endregion
        #region ActionMethod
        public ActionResult Index()
        {
            var model = new MessageModel();

            if (!_checkingRoleService.HasAccess(PermissionList.CompanyList, CurrentUser.GetCurrentUser))
            {
                return View("Inaccessibility");
            }

            return View(model);
        }
        public ActionResult Create()
        {
            var model = new MessageModel();

            if (!_checkingRoleService.HasAccess(PermissionList.CompanyCreate, CurrentUser.GetCurrentUser))
            {

                return View("Inaccessibility");
            }

            ///آماده سازی داربست ها
            PrepareAllScaffoldings(model);

            return View(model);
        }
        [HttpPost]
        public ActionResult Create(MessageModel model)
        {
            var result = new ReturnAjaxForm();
            var message = new Message();

            if (ModelState.IsValid)
            {
                try
                {
                    message.Subject = model.Subject;
                    message.Content = model.Content;
                    message.ScaffoldingId = model.ScaffoldingId;
                    message.SendTime = model.SendTime;
                   
                    message.CreatedDate = DateTime.Now;
                    message.ActionUserId = User.Identity.GetUserId();

                    ///عملیات ثبت در دیتابیس
                    _messageService.Insert(message);

                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                    ShowMessageToUser(result, "با موفقیت ثبت شد", ResultType.Success);

                }
                catch (Exception e)
                {
                    ///نمایش پیام خطا به کاربر

                    ShowMessageToUser(result, e.InnerException.InnerException.Message, ResultType.Failure);

                }

            }
            else
            {
                /// show Error Message To User beacuse ModelState Is Invalid
                StringBuilder builder = AddErrors();
                ShowMessageToUser(result, builder.ToString(), ResultType.Failure);
            }
            return Json(result);
        }




        [HttpGet]
        public ActionResult Edit(int id)
        {

            var model = new MessageModel();

            if (!_checkingRoleService.HasAccess(PermissionList.CompanyEdit, CurrentUser.GetCurrentUser))
            {
                return View("Inaccessibility");
            }

            var message = _messageService.GetById(id);
            model.Subject = message.Subject;
            model.ScaffoldingId = message.ScaffoldingId;
            model.Content = message.Content;
            model.SendTime = message.SendTime;
            model.Id = message.Id;

            ///آماده سازی داربست
            PrepareAllScaffoldings(model);

            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(MessageModel model)
        {
            var result = new ReturnAjaxForm();

            var message = _messageService.GetById(model.Id);



            if (ModelState.IsValid)
            {
                try
                {
                    message.Subject = model.Subject;
                    message.Content = model.Content;
                    message.SendTime = model.SendTime;
                    message.ScaffoldingId = model.ScaffoldingId;
                    message.ModifiedDate = DateTime.Now;
                    message.LastActionUserId = User.Identity.GetUserId();

                    ///عملیات ویرایش در دیتابیس

                    _messageService.Update(message);

                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                    ShowMessageToUser(result, "با موفقیت ویرایش شد", ResultType.Success);

                }
                catch (Exception e)
                {
                    ///نمایش پیام خطا به کاربر

                    ShowMessageToUser(result, e.InnerException.InnerException.Message, ResultType.Failure);

                }

            }
            else
            {
                /// show Error Message To User beacuse ModelState Is Invalid
                StringBuilder builder = AddErrors();
                ShowMessageToUser(result, builder.ToString(), ResultType.Failure);
            }
            return Json(result);
        }
        [HttpGet]
        public JsonResult List(DataTableRequest request, [ModelBinder(typeof(DataTableModelBinder))]DataTableRequestFilter filter)

        {
            if (request.length == -1)
            {
                request.length = int.MaxValue;
            }
            var data = _messageService.FilterData(request.start, request.length, filter.Search, filter.SortColumn, filter.SortDirection);


            var gridModel = new DataTableResponse<MessageModel>()
            {
                data = data.Select(x =>
                {

                    var m = new MessageModel();
                    m.Subject = x.Subject;
                    m.Content = x.Content;
                
                    m.ShamsiCreateDate = ConvertAdToJalaliDateTime(x.CreatedDate.Value);
                    m.ActionUserName = _userService.GetById(x.ActionUserId).UserName;
                    if (x.ModifiedDate.HasValue)
                        m.ShamsiCreateDate = ConvertAdToJalaliDateTime(x.ModifiedDate.Value);
                    if (x.LastActionUserId != null)
                        m.EditUserName = _userService.GetById(x.ActionUserId).UserName;

                    m.Id = x.Id;

                    if (x.ModifiedDate != null)
                    {
                        m.ShamsiEditDate = ConvertAdToJalaliDateTime(x.ModifiedDate.Value);
                    }


                    return m;
                }).ToList(),
                recordsTotal = _messageService.Count(filter.Search),
                recordsFiltered = _messageService.Count(filter.Search),
                draw = request.draw
            };



            return Json(gridModel, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = new ReturnAjaxForm();

            if (!_checkingRoleService.HasAccess(PermissionList.CompanyDelete, CurrentUser.GetCurrentUser))
            {
                ///نمایش پیام عدم دسترسی  به کاربر

                ShowMessageToUser(result, "کاربر گرامی،شما  مجوز حذف رکورد را ندارید! ", ResultType.NotAllow);


                //return Json(result, JsonRequestBehavior.AllowGet);
            }

            try
            {
                var entity = _messageService.GetById(id);
                _messageService.Remove(entity);

                ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                ShowMessageToUser(result, "با موفقیت حذف شد", ResultType.Success);

            }
            catch (Exception e)
            {
                ///نمایش پیام خطا به کاربر

                ShowMessageToUser(result, e.Message, ResultType.Failure);
            }

            return Json(result);

        }

        #endregion


        #region Report
        public virtual ActionResult Print()
        {
            return View();
        }





        #endregion

    }
}