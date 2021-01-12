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
using System.Collections.Generic;
using Store.Core.Domain.StoreTables.Work;
using Rotativa;

namespace Store.Controllers
{
    [Authorize]
    public class SafetyChecklistController : BaseController
    {
        #region Fields
        private readonly IQuestionService _questionService;
        private readonly IAnswerService _answerService;
        private readonly ICheckingRole _checkingRoleService;
        private readonly  IScaffoldingService _scaffoldingService;
        private readonly IWorkOrderService _workOrderService;
        private readonly IPersonnelService _personnelService;
        private readonly ICompanyService _companyService;
        #endregion
        #region Ctor

        public SafetyChecklistController(ICompanyService companyService,IPersonnelService personnelService,IWorkOrderService workOrderService,IAnswerService answerService,IScaffoldingService scaffoldingService, ICheckingRole checkingRoleService, IQuestionService questionService)
        {
            _questionService = questionService;
            _checkingRoleService = checkingRoleService;
            _scaffoldingService = scaffoldingService;
            _answerService = answerService;
            _workOrderService = workOrderService;
            _personnelService = personnelService;
            _companyService = companyService;
        }
        #endregion
        #region Utilities

        private void PrepareAllQuestion(QuestionModel model, List<Answer> answers)
        {
            var questionList = _questionService.GetAll();
           
            foreach (var question in questionList)
            {
                if (answers != null && answers.Count > 0)
                {
                    if (answers.Where(x => x.QuestionId == question.Id).Count() > 0)
                    {
                        var permissionModel = new Question();
                        permissionModel.Text = question.Text;
                        permissionModel.Description = question.Description;
                        permissionModel.Id = question.Id;
                        permissionModel.AnswerId = answers.Where(x => x.QuestionId == question.Id).FirstOrDefault().Id;
                        permissionModel.IsChecked = answers.Where(x => x.QuestionId == question.Id).FirstOrDefault().Desirable;
                        model.QuestionList.Add(permissionModel);
                    }
                    else
                    {
                        var permissionModel = new Question();
                        permissionModel.Text = question.Text;
                        permissionModel.Description = question.Description;
                        permissionModel.Id = question.Id;
                        permissionModel.IsChecked = answers.Where(x => x.QuestionId == question.Id).FirstOrDefault().Desirable;
                        model.QuestionList.Add(permissionModel);
                    }
                }
                else
                {
                    var permissionModel = new Question();
                    permissionModel.Text = question.Text;
                    permissionModel.Description = question.Description;
                    permissionModel.Id = question.Id;
                    model.QuestionList.Add(permissionModel);
                }

            }

        }

        [NonAction]
        protected virtual void PrepareAllScaffoldings(QuestionModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            var scaffoldings = _scaffoldingService.GetAll().Where(d => d.ScaffoldStates == ScaffoldStates.Running);

            model.ScaffoldingList.Add(new SelectListItem
            {
                Text = "انتخاب داربست",
                Value = " "
            });

            foreach (var c in scaffoldings)
            {

                model.ScaffoldingList.Add(new SelectListItem
                {
                    Text = c.Title,
                    Value = c.Id.ToString(),
                    Selected = false
                });
            }

        }

        [NonAction]
        protected virtual void PrepareAllWorkOrders(QuestionModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            var workOrders = _workOrderService.GetAll();

            model.WorkOrders.Add(new SelectListItem
            {
                Text = "انتخاب شماره درخواست",
                Value = " "
            });

            foreach (var workOrder in workOrders)
            {

                model.WorkOrders.Add(new SelectListItem
                {
                    Text = workOrder.Title,
                    Value = workOrder.Id.ToString()
                });
            }

        }

        [NonAction]
        protected virtual void PrepareAllPersonnels(QuestionModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            var personnels = _personnelService.GetAll();

            model.PersonnelList.Add(new SelectListItem
            {
                Text = "انتخاب استادکار",
                Value = " "
            });

            foreach (var personnel in personnels)
            {

                model.PersonnelList.Add(new SelectListItem
                {
                    Text = personnel.PositionType != null ? $"{personnel.UserNameFmaily} ({personnel.PositionType.Title})" : personnel.UserNameFmaily,
                    Value = personnel.PersonnelCode.ToString()
                });
            }

        }

        [NonAction]
        public virtual void PrepareCheckList(QuestionModel model, List<Answer> answers)
        {
            // دریافت لیست کلیه سوالات
            var allquestions = _questionService.GetAll().ToList();

            List<QuestionModel> QuestionList = new List<QuestionModel>();

            // مقایسه سوالات با پاسخ ها

            foreach (var question in allquestions)
            {
                if (answers != null && answers.Count > 0)
                {
                    if (answers.Where(x => x.QuestionId == question.Id).Count() > 0)
                    {
                        var questionModel = new Question();
                        questionModel.Text = question.Text;
                        questionModel.Id = question.Id;
                        questionModel.IsChecked = answers.Where(x => x.QuestionId == question.Id).FirstOrDefault().Desirable;
                        model.QuestionList.Add(questionModel);
                    }
                    else
                    {
                        var questionModel = new Question();
                        questionModel.Text = question.Text;
                        questionModel.Id = question.Id;
                        questionModel.IsChecked = false;
                        model.QuestionList.Add(questionModel);
                    }
                }
                else
                {
                    var questionModel = new Question();
                    questionModel.Text = question.Text;
                    questionModel.Id = question.Id;
                    questionModel.IsChecked = false;
                    model.QuestionList.Add(questionModel);
                }

            }


        }

        private void PrepareScaffoldingModel(QuestionModel model, Scaffolding scaffold, WorkOrder workorder)
        {
            model.ScaffoldModel.ExpertName = scaffold.ExpertName;
            model.ScaffoldModel.PermitNumber = scaffold.PermitNumber;
            model.ScaffoldModel.WorkOrderTitle = _workOrderService.GetById(workorder.Id).Title;
            model.Name = _personnelService.GetById(scaffold.PersonnelCode.Value).UserNameFmaily;
            if (scaffold.RegistrationDate.HasValue)
                model.ScaffoldModel.ShamsiRegistrationDate = ConvertAdToJalali(scaffold.RegistrationDate.Value);
            model.ScaffoldModel.Tag = workorder.Tag;
            model.ScaffoldModel.Title = scaffold.Title;
            model.ScaffoldModel.Tag = scaffold.Tag;
            model.ScaffoldModel.EarthTitle = scaffold.Earth.Title;
            model.ScaffoldModel.BuildingTitle = scaffold.Building.Title;
            model.ScaffoldModel.ScaffoldTypeTitle = scaffold.ScaffoldType.Title;
            if (scaffold.SafetyTagExpire.HasValue)
                model.ScaffoldModel.ShamsiSafetyTagExpire = ConvertAdToJalali(scaffold.SafetyTagExpire.Value);
            if (scaffold.ExpireDate.HasValue)
                model.ScaffoldModel.ShamsiExpireDate = ConvertAdToJalali(scaffold.ExpireDate.Value);
            model.ScaffoldModel.ShamsiDate = ConvertAdToJalali(scaffold.Date);
            model.ScaffoldModel.Height = scaffold.Height;
            model.ScaffoldModel.Width = scaffold.Width;
            model.ScaffoldModel.Length = scaffold.Length;
            model.RealArea = workorder.RealArea;

            model.CompanyTitle = _companyService.GetById(workorder.CompanyId)?.Title;
            model.SectionTitle = _companyService.GetById(workorder.SectionId.Value)?.Title;
            model.UnitTitle = _companyService.GetById(workorder.UnitId.Value)?.Title;
            model.WorkOrderTitle = workorder.Title;
            model.Tag = workorder.Tag;
            model.ShamsiCreateDate = ConvertAdToJalali(workorder.Date);
        }

        #endregion
        #region ActionMethod
        public ActionResult Index()
        {
            var model = new CompanyStoreRoomModel();

            if (!_checkingRoleService.HasAccess(PermissionList.SafetyCheckList, CurrentUser.GetCurrentUser))
            {
                return View("Inaccessibility");
            }

            return View(model);
        }
        public ActionResult Create(int scaffoldingId=0)
        {
            var model = new QuestionModel();
           
            if (!_checkingRoleService.HasAccess(PermissionList.SafetyCheckCreate, CurrentUser.GetCurrentUser))
            {

                return View("Inaccessibility");
            }
            var getWorkorder = _workOrderService.GetAll(type:WorkOrderType.Installation,scaffoldingId:scaffoldingId);
            PrepareAllQuestion(model,null);
            PrepareAllPersonnels(model);
            PrepareAllWorkOrders(model);
            PrepareAllScaffoldings(model);
            model.ScaffoldingId = scaffoldingId;
            model.WorkOrderId = getWorkorder.FirstOrDefault().Id;
            return View(model);
        }
        public ActionResult CreatePartial()
        {
            var model = new QuestionModel();

            if (!_checkingRoleService.HasAccess(PermissionList.SafetyCheckCreate, CurrentUser.GetCurrentUser))
            {

                return View("Inaccessibility");
            }

            PrepareAllQuestion(model, null);
            PrepareAllPersonnels(model);
            PrepareAllWorkOrders(model);
            PrepareAllScaffoldings(model);
            return PartialView("_CreatePartial", model);
        }
        [HttpPost]
        public ActionResult Create(QuestionModel model)
        {
            var result = new ReturnAjaxForm();
            var answers = new List<Answer>();
            var editAnsewer = new List<Answer>();
            var question = new Question();
            int score = 0;
            
          
            if (ModelState.IsValid)
            {
                try
                {
                    //if (_answerService.GetAll().Any(x => x.ScaffoldingId == model.ScaffoldingId))
                    //{

                    //    ///نمایش پیام خطا به کاربر

                    //    ShowMessageToUser(result, "برای این داربست قبلا چک لیست ثبت شده است.", ResultType.Failure);
                    //}
                  
                    //else
                    //{
                        for (int i = 0; i < model.IdList.Count; i++)
                        {

                        bool isDesirable = model.AnswerList.Where(x => x == model.IdList[i]).Count() > 0;

                        if (isDesirable)
                            score += _questionService.GetById(model.IdList[i]).Score;

                        if (model.AnswerIds[i] !=0)
                        {
                            var getAnsewer = _answerService.GetById(model.AnswerIds[i]);

                            getAnsewer.Desirable = isDesirable;
                            getAnsewer.Description = model.DescList[i];
                            getAnsewer.ModifiedDate = DateTime.Now;
                            editAnsewer.Add(getAnsewer);

                        }
                        else
                        {
                            answers.Add(new Answer
                            {
                                QuestionId = model.IdList[i],
                                Desirable = isDesirable,
                                Description = model.DescList[i],
                                ScaffoldingId = model.ScaffoldingId,
                                ActionUserId = HttpContext.User.Identity.GetUserId()
                            });
                        }
                          

                    }


                    if (answers.Count > 0)
                    {
                        if (_answerService.Insert(answers, model.WorkOrderId, model.ExpertName, model.ScaffoldingId, model.RegistrationDate, model.PermitNumber,model.PersonnelId,model.RealArea, score))
                        {
                            ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر
                            var scaffold = _scaffoldingService.GetById(model.ScaffoldingId);
                            if (scaffold == null)
                            {
                                ShowMessageToUser(result, "داربست موردنظر یافت نشد", ResultType.Failure);
                            }
                            scaffold.ScaffoldStates = ScaffoldStates.Secure;
                            _scaffoldingService.Update(scaffold);
                            ShowMessageToUser(result, "با موفقیت ثبت شد", ResultType.Success);
                        }
                        else
                        {
                            ///نمایش پیام خطا به کاربر

                            ShowMessageToUser(result, "عملیات با خطا مواجه شد.", ResultType.Failure);
                        }
                    }
                      
                    //if (editAnsewer.Count > 0)
                    //    _answerService.Update(editAnsewer, model.WorkOrderId, model.ExpertName, model.ScaffoldingId, model.RegistrationDate, model.PermitNumber, model.PersonnelId, score);

                
                }
                catch (Exception ex)
                {
                    /// لاگ خطا

                    LogException.Write(ex, "CreateMethodInSafetyChecklistController");


                    ///نمایش پیام خطا به کاربر

                    ShowMessageToUser(result, "عملیات با خطا مواجه شد.", ResultType.Failure);

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

        [HttpPost]
        public PartialViewResult GetSafetyChecklist(int scaffoldingId)
        {
            var model = new QuestionModel();
            try
            {
               
                var answers = _answerService.GetAll().Where(x=>x.ScaffoldingId==scaffoldingId);
                var scaffolding = _scaffoldingService.GetById(scaffoldingId);
               
                model.ScaffoldingId = scaffoldingId;
                model.PermitNumber = scaffolding.PermitNumber;
                if(scaffolding.PersonnelCode.HasValue)
                model.PersonnelId = scaffolding.PersonnelCode.Value;
                model.ExpertName = scaffolding.ExpertName;
                if(_workOrderService.GetAll(type:WorkOrderType.Installation,scaffoldingId:scaffolding.Id).Count>0)
                model.WorkOrderId = _workOrderService.GetAll(type: WorkOrderType.Installation, scaffoldingId: scaffolding.Id).FirstOrDefault().Id;
                if(scaffolding.RegistrationDate.HasValue)
                model.RegistrationDate = scaffolding.RegistrationDate;

                PrepareAllQuestion(model,answers.ToList());
                PrepareAllPersonnels(model);
                PrepareAllWorkOrders(model);
                PrepareAllScaffoldings(model);
            }
            catch (Exception ex)
            {


            }
            return PartialView("_CreateOrUpdate", model);
        }

        public ActionResult PrintSafetyChecklist(int scaffoldingId)
        {
            var model = new QuestionModel();
            var scaffold = _scaffoldingService.GetById(scaffoldingId);
            var workorder = _workOrderService.GetAll(type: WorkOrderType.Installation, scaffoldingId: scaffoldingId).FirstOrDefault();
            var answers = _answerService.GetAll().Where(x => x.ScaffoldingId == scaffoldingId);
            PrepareCheckList(model, answers.ToList());
            PrepareScaffoldingModel(model, scaffold, workorder);

            return new ViewAsPdf("PrintSafetyChecklist", model);
        }

     
        #endregion


    }
}