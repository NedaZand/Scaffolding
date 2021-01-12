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
using Store.Core.Domain.StoreTables.Work;
using Store.Service;
using Store.Essential.Model;
using Store.Service.DateTimeExtentions;
using System.Web;
using System.IO;
using ExcelDataReader;
using System.Data;
using System.Collections.Generic;

namespace Store.Controllers
{
    [Authorize]
    public class WorkOrderController : BaseController
    {
        #region Fields

        private readonly IWorkOrderService _workorderService;
        private readonly ICheckingRole _checkingRoleService;
        private readonly ICompanyService _companyService;
        private readonly IUserService _userService;
        private readonly IScaffoldingService _scaffoldingService;

        #endregion
        #region Ctor
        public WorkOrderController(IScaffoldingService scaffoldingService, IWorkOrderService workorderService, ICheckingRole checkingRoleService, ICompanyService companyService, IUserService userService)
        {
            this._workorderService = workorderService;
            this._checkingRoleService = checkingRoleService;
            this._companyService = companyService;
            this._userService = userService;
            this._scaffoldingService = scaffoldingService;
        }
        #endregion
        #region Utilities

        //[NonAction]
        //protected virtual void PrepareAllCompaniesModel(WorkOrderModel model)
        //{
        //    if (model == null)
        //        throw new ArgumentNullException("model");

        //    model.Companies.Add(new SelectListItem
        //    {
        //        Text = "[None]",
        //        Value = " "
        //    });
        //    var companies = SelectListHelper.GetCompanyList(_companyService);
        //    foreach (var c in companies)
        //        model.Companies.Add(c);
        //}

        [NonAction]
        protected virtual void PrepareAllTypesModel(WorkOrderModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            model.Types = WorkOrderType.Unassigned.ToSelectList().ToList();

            //model.Types.Add(new SelectListItem
            //{
            //    Text = "[None]",
            //    Value = " "
            //});
            //var types = _workorderTypeService.GetAll();
            //foreach (var c in types)
            //    model.Types.Add(new SelectListItem
            //    {
            //        Text = c.Title,
            //        Value = c.Id.ToString()
            //    });
        }

        [NonAction]
        protected virtual void PrepareAllStatusModel(WorkOrderModel model)
        {

            model.Statuses = WorkOrderStatus.Select.ToSelectList().ToList();
            //if (model == null)
            //    throw new ArgumentNullException("model");

            //model.Statuses.Add(new SelectListItem
            //{
            //    Text = "[None]",
            //    Value = " "
            //});
            //var statuses =_workorderStatusService.GetAll();
            //foreach (var c in statuses)
            //    model.Statuses.Add(new SelectListItem
            //    {
            //        Text = c.Title,
            //        Value = c.Id.ToString()
            //    });
        }

        [NonAction]
        protected virtual void PrepareAllPrioritiesModel(WorkOrderModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            model.Priorities = WorkOrderPriority.Unassigned.ToSelectList().ToList();

            //model.Priorities.Add(new SelectListItem
            //{
            //    Text = "[None]",
            //    Value = " "
            //});
            //var priorities = _workorderPriorityService.GetAll();
            //foreach (var c in priorities)
            //    model.Priorities.Add(new SelectListItem
            //    {
            //        Text = c.Title,
            //        Value = c.Id.ToString()
            //    });
        }

        [NonAction]
        protected virtual void PrepareAllScaffoldings(WorkOrderModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            var scaffoldings = _scaffoldingService.GetAll();

            model.Scaffoldings.Add(new SelectListItem
            {
                Text = "انتخاب داربست",
                Value = "0"
            });

            foreach (var c in scaffoldings)
            {

                model.Scaffoldings.Add(new SelectListItem
                {
                    Text = c.Title,
                    Value = c.Id.ToString(),
                    Selected = false
                });
            }

        }

        [NonAction]
        protected virtual void PrepareAllCompaniesModel(WorkOrderModel model, int? parentId = null)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            model.Companies.Add(new SelectListItem
            {
                Text = "انتخاب ",
                Value = "0"
            });

            //var companies = SelectListHelper.GetCompanyList(_companyService);
            var companies = _companyService.GetAll(parentId: parentId);
            foreach (var c in companies)
            {

                model.Companies.Add(new SelectListItem
                {
                    Text = c.Title,
                    Value = c.Id.ToString()
                });
            }
        }

        #endregion
        #region ActionMethod
        public ActionResult Index()
        {
            var model = new WorkOrderModel();

            if (!_checkingRoleService.HasAccess(PermissionList.WorkOrderList, CurrentUser.GetCurrentUser))
            {
                return View("Inaccessibility");
            }
            ///بدست آوردن زیر مجموعه های شرکت
            PrepareAllCompaniesModel(model);
            ///آماده سازی لیست اولویت ها
            PrepareAllPrioritiesModel(model);
            ///آماده سازی لیست وضعیت
            PrepareAllStatusModel(model);
            ///آماده سازی لیست انواع
            PrepareAllTypesModel(model);
            ///آماده سازی لیست داربست
            PrepareAllScaffoldings(model);

            return View(model);
        }
        public ActionResult Create()
        {
            var model = new WorkOrderModel();

            if (!_checkingRoleService.HasAccess(PermissionList.WorkOrderCreate, CurrentUser.GetCurrentUser))
            {

                return View("Inaccessibility");
            }
            ///بدست آوردن زیر مجموعه های شرکت
            PrepareAllCompaniesModel(model);
            ///آماده سازی لیست اولویت ها
            PrepareAllPrioritiesModel(model);
            ///آماده سازی لیست وضعیت
            PrepareAllStatusModel(model);
            ///آماده سازی لیست انواع
            PrepareAllTypesModel(model);
            ///آماده سازی لیست داربست
            PrepareAllScaffoldings(model);

            return View(model);
        }
        [HttpPost]
        public ActionResult Create(WorkOrderModel model)
        {
            var result = new ReturnAjaxForm();
            var work = new WorkOrder();

            if (model.TypeId == WorkOrderType.Reopening && model.ScaffoldingId==0)
                ModelState.AddModelError("ScaffoldingId", "داربست را انتخاب نمایید");

            if (model.Date.HasValue && model.ExpireDate.HasValue && model.ExpireDate.Value.Date<model.Date.Value.Date)
                ModelState.AddModelError("ExpireDate", "تاریخ انقضا نمی تواند از تاریخ شروع کوچکتر باشد.");

            if (model.CompanyId==0)
                ModelState.AddModelError("CompanyId", "شرکت الزامی است");

            if (ModelState.IsValid)
            {
                try
                {
                    work.Title = model.Title.Trim();
                    work.Tag = model.Tag;
                    work.Priority = model.PriorityId.Value;
                    if (model.Status != WorkOrderStatus.Select)
                        work.Status = model.Status.Value;
                    work.TypeId = model.TypeId.Value;
                    if (model.ExpireDate.HasValue)
                        work.ExpireDate = model.ExpireDate.Value;
                    if (model.Date.HasValue)
                        work.Date = model.Date.Value;
                    work.CompanyId = model.CompanyId.Value;
                    if (model.UnitId != 0)
                        work.UnitId = model.UnitId;
                    if (model.SectionId != 0)
                        work.SectionId = model.SectionId;
                    work.Description = model.Description;
                    if(model.ScaffoldingId!=0)
                    work.ScaffoldingId = model.ScaffoldingId;
                    work.ActionUserId = User.Identity.GetUserId();

                    ///عملیات ثبت در دیتابیس
                    _workorderService.Insert(work);

                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                    ShowMessageToUser(result, "با موفقیت ثبت شد. ", ResultType.Success);
                }
                catch (Exception ex)
                {
                    /// لاگ خطا

                    LogException.Write(ex, "CreateMethodInWorkorderController");


                    ///نمایش پیام خطا به کاربر
                    if (ex.InnerException != null && ex.InnerException.InnerException != null && ex.InnerException.InnerException.Message.Contains("duplicate key"))
                        ShowMessageToUser(result, " عنوان دستور کار تکراری می باشد ", ResultType.Failure);
                    else

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

        [HttpGet]
        public ActionResult Edit(int id)
        {

            var model = new WorkOrderModel();

            if (!_checkingRoleService.HasAccess(PermissionList.WorkOrderEdit, CurrentUser.GetCurrentUser))
            {

                return View("Inaccessibility");
            }

            /// پر کردن مدل و ارسال به ویو جهت ویرایش

            #region FillModelWithDatabase

            var entity = _workorderService.GetById(id);
            model.Id = entity.Id;
            model.Title = entity.Title;
            model.Tag = entity.Tag;
            model.Status = entity.Status;
            model.TypeId = entity.TypeId;
            model.PriorityId = entity.Priority;
            model.ExpireDate = entity.ExpireDate;
            model.Date = entity.Date;
            model.CompanyId = entity.CompanyId;
            model.UnitId = entity.UnitId;
            model.SectionId = entity.SectionId;
            model.ScaffoldingId = entity.ScaffoldingId;
            model.Description = entity.Description;
            model.StartDate = entity.StartDate;
            model.EndDate = entity.EndDate;

            ///آماده سازی لیست شرکت ها
            PrepareAllCompaniesModel(model);

            //if (entity.UnitId.HasValue)
            //{
            ///آماده سازی لیست واحد ها

            model.Units.Add(new SelectListItem
            {
                Text = "",
                Value = " "
            });

            var companies = _companyService.GetAll(parentId: entity.CompanyId);
                foreach (var c in companies)
                {

                    model.Units.Add(new SelectListItem
                    {
                        Text = c.Title,
                        Value = c.Id.ToString()
                    });
                }
        

            if (entity.UnitId.HasValue)
            {
                model.Sections.Add(new SelectListItem
                {
                    Text = "",
                    Value = " "
                });
                ///آماده سازی لیست بخش ها
                companies = _companyService.GetAll(parentId: entity.UnitId);
                foreach (var c in companies)
                {

                    model.Sections.Add(new SelectListItem
                    {
                        Text = c.Title,
                        Value = c.Id.ToString()
                    });
                }

            }
            ///آماده سازی لیست اولویت ها
            PrepareAllPrioritiesModel(model);
            ///آماده سازی لیست وضعیت
            PrepareAllStatusModel(model);
            ///آماده سازی لیست انواع
            PrepareAllTypesModel(model);
            ///آماده سازی لیست داربست
            PrepareAllScaffoldings(model);

            #endregion FillModelWithDatabase

            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(WorkOrderModel model)
        {
            var result = new ReturnAjaxForm();

            if (model.TypeId == WorkOrderType.Reopening && model.ScaffoldingId==0)
                ModelState.AddModelError("ScaffoldingId", "داربست را انتخاب نمایید");

            //if (model.PriorityId == WorkOrderPriority.Unassigned)
            //    ModelState.AddModelError("PriorityId", "اولویت را انتخاب نمایید");

            //if (model.TypeId == WorkOrderType.Unassigned)
            //    ModelState.AddModelError("TypeId", "نوع را انتخاب نمایید");
            if (model.CompanyId == 0)
                ModelState.AddModelError("CompanyId", "شرکت الزامی است");


            if (ModelState.IsValid)
            {
                try
                {

                    var work = _workorderService.GetById(model.Id);

                    work.Title = model.Title;
                    work.Tag = model.Tag;
                    work.Priority = model.PriorityId.Value;
                    work.Status = model.Status.Value;
                    work.TypeId = model.TypeId.Value;
                    if(model.ExpireDate.HasValue)
                    work.ExpireDate = model.ExpireDate.Value;
                    work.Date = model.Date.Value;
                    if(model.CompanyId!=0)
                    work.CompanyId = model.CompanyId.Value;
                    if (model.SectionId != 0)
                        work.SectionId = model.SectionId;
                    if (model.UnitId != 0)
                        work.UnitId = model.UnitId;
                    work.Description = model.Description;
                    work.StartDate = model.StartDate;
                    work.EndDate = model.EndDate;
                    //work.ScaffoldingId = model.ScaffoldingId;
                    ///ثبت زمان و کاربر ویرایش کننده
                    work.ModifiedDate = DateTime.Now;
                    work.LastActionUserId = User.Identity.GetUserId();

                    ///عملیات ویرایش در دیتابیس

                    _workorderService.Update(work);

                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                    ShowMessageToUser(result, "با موفقیت ویرایش شد. ", ResultType.Success);

                }
                catch (Exception ex)
                {
                    /// لاگ خطا

                    LogException.Write(ex, "EditMethodInWorkorderController");


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
        [HttpGet]
        public JsonResult List(DataTableRequest request, [ModelBinder(typeof(DataTableModelBinder))]DataTableRequestFilter filter, WorkOrderModel model)

        {
            if (request.length == -1)
            {
                request.length = int.MaxValue;
            }
            var data = _workorderService.FilterData(request.start, request.length, filter.Search, filter.SortColumn, filter.SortDirection, model.FromDate, model.ToDate, model.FromExpireDate, model.ToExpireDate, model.Status, model.TypeId, model.PriorityId, model.TitleSearch, model.TagSearch, model.Description, model.CompanyId,model.ScaffoldingId);


            var gridModel = new DataTableResponse<WorkOrderModel>()
            {
                data = data.Select(x =>
                {

                    var m = new WorkOrderModel();
                    m.Title = x.Title;
                    m.Tag = x.Tag;
                    m.Description = x.Description;
                    m.ShamsiDate = ConvertAdToJalali(x.Date);
                    if(x.ExpireDate.HasValue)
                    m.ShamsiExpireDate = ConvertAdToJalali(x.ExpireDate.Value);
                    m.StatusTitle = x.Status.GetDisplayName();
                    m.TypeTitle = x.TypeId.GetDisplayName();
                    m.PriorityTitle = x.Priority.GetDisplayName();
                    m.ScaffoldingTitle = x.Scaffolding?.Title;
                    //m.CompanyName = x.Company.GetFormattedBreadCrumb(_companyService);
                    m.CompanyName =_companyService.GetById(x.CompanyId)?.Title;
                    if(x.UnitId.HasValue)
                    m.UnitName = _companyService.GetById(x.UnitId.Value).Title;
                    if (x.SectionId.HasValue)
                        m.SectionName = _companyService.GetById(x.SectionId.Value).Title;
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
                recordsTotal = _workorderService.Count(filter.Search, model.FromDate, model.ToDate, model.FromExpireDate, model.ToExpireDate, model.Status, model.TypeId, model.PriorityId, model.TitleSearch, model.TagSearch, model.Description, model.CompanyId,model.ScaffoldingId),
                recordsFiltered = _workorderService.Count(filter.Search, model.FromDate, model.ToDate, model.FromExpireDate, model.ToExpireDate, model.Status, model.TypeId, model.PriorityId, model.TitleSearch, model.TagSearch, model.Description, model.CompanyId, model.ScaffoldingId),
                draw = request.draw
            };



            return Json(gridModel, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = new ReturnAjaxForm();

            if (!_checkingRoleService.HasAccess(PermissionList.WorkOrderDelete, CurrentUser.GetCurrentUser))
            {

                ///نمایش پیام عدم دسترسی به کاربر

                ShowMessageToUser(result, "کاربر گرامی،شما  مجوز حذف رکورد را ندارید! ", ResultType.NotAllow);

                //return Json(result, JsonRequestBehavior.AllowGet);
            }



            try
            {
                var entity = _workorderService.GetById(id);
                _workorderService.Remove(entity);

                ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                ShowMessageToUser(result, "با موفقیت حذف شد.", ResultType.Success);
            }
            catch (Exception ex)
            {
                /// لاگ خطا

                LogException.Write(ex, "DeleteMethodInWorkorderController");


                ///نمایش پیام خطا به کاربر

                ShowMessageToUser(result, "امکان حذف  رکورد وجود ندارد.", ResultType.Failure);

            }

            return Json(result, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult GetCompaniesByParentId(int parentId)

        {
            var model = new WorkOrderModel();


            PrepareAllCompaniesModel(model, parentId);

            return Json(model.Companies);
        }
        #endregion

        #region AddFromExcel   
        public ActionResult ExcelUpload()
        {
            if (!_checkingRoleService.HasAccess(PermissionList.AttendanceCreate, CurrentUser.GetCurrentUser))
            {
                return View("Inaccessibility");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase fileUpload)
        {
            // اعتبار سنجی فایل آپلود شده
            if (fileUpload != null && fileUpload.ContentLength > 0 && (fileUpload.FileName.EndsWith(".xls") || fileUpload.FileName.EndsWith(".xlsx")))
            {
                // با خواندن فایل به صورت باینری، این کتابخانه نیازی به نصب پیش نیازهای آفیس ندارد
                Stream stream = fileUpload.InputStream;

                //  نیازی به نگرانی در مورد پسوند فایل نیست
                // کتابخانه به صورت خودکار کلاس مورد نظر برای پسوند مربوطه را استفاده می‌کند
                // ExcelDataReader.ExcelBinaryReader یا ExcelDataReader.ExcelOpenXmlReader
                IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);

                // روش ذکر شده در قسمت دوم برای خواندن کل اطلاعات بصورت یکجا
                DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                    {
                        // true: ردیف اول از فایل را به عنوان هدر در نظر می‌گیرد
                        // مقدار پیش فرض: false
                        UseHeaderRow = true
                    }
                });

                reader.Close();

                var workorders = new List<WorkOrder>();
                var company = new Company();
                var vahed = new Company();
                var section = new Company();

                foreach (DataRow row in result.Tables[0].Rows)
                {

                    
                    try
                    {
                        if (!string.IsNullOrEmpty(row[17].ToString()))
                        {
                            company = _companyService.GetAll(row[17].ToString(),0).FirstOrDefault();

                            if (company == null)
                            {
                                company = new Company
                                {
                                    Title = row[17].ToString(),
                                    ActionUserId = User.Identity.GetUserId()

                                };
                                _companyService.Insert(company);
                            }
                        }
                        if (!string.IsNullOrEmpty(row[0].ToString()))
                        {
                            vahed = _companyService.GetAll(row[0].ToString(),company.Id).FirstOrDefault();

                            if (vahed == null)
                            {
                                vahed = new Company
                                {
                                    Title = row[0].ToString(),
                                    ParentID = company.Id,
                                    ActionUserId = User.Identity.GetUserId()
                                };
                                _companyService.Insert(vahed);
                            }
                        }
                        if (!string.IsNullOrEmpty(row[1].ToString()))
                        {
                            section = _companyService.GetAll(row[1].ToString(),vahed.Id).FirstOrDefault();

                            if (section == null)
                            {
                                section = new Company
                                {
                                    Title = row[1].ToString(),
                                    ParentID = vahed.Id,
                                    ActionUserId = User.Identity.GetUserId()
                                };
                                _companyService.Insert(section);
                            }
                        }


                        workorders.Add(new WorkOrder
                        {
                            Tag = Convert.ToString(row[5]),
                            Title = Convert.ToString(row[7]),
                            Description = Convert.ToString(row[10]),
                            Date = ConvertJalaliToAd(row[11].ToString()),
                            CompanyId=company.Id,
                            UnitId=vahed.Id,
                            SectionId=section.Id,
                            //CompanyId =section!=null?section.Id:vahed!=null?vahed.Id:company.Id,
                            Status= WorkOrderStatus.Unassigned,
                            TypeId= Convert.ToString(row[10]).ToLower().Trim().Contains("install") || Convert.ToString(row[10]).ToLower().Trim().Contains("close") || Convert.ToString(row[10]).ToLower().Trim().Contains("scafold") || Convert.ToString(row[10]).ToLower().Trim().Contains("assembling")|| Convert.ToString(row[10]).ToLower().Trim().Contains("assemble") ? WorkOrderType.Installation  : Convert.ToString(row[10]).ToLower().Trim().Contains("remove") || Convert.ToString(row[10]).ToLower().Trim().Contains("open") || Convert.ToString(row[10]).ToLower().Trim().Contains("opening") || Convert.ToString(row[10]).ToLower().Trim().Contains("dis assemblling") || Convert.ToString(row[10]).ToLower().Trim().Contains("disassemblling") ? WorkOrderType.Reopening : Convert.ToString(row[10]).ToLower().Trim().Contains("standby") || Convert.ToString(row[10]).ToLower().Trim().Contains("stand by") ? WorkOrderType.Standby:WorkOrderType.Unassigned,
                          
                            ActionUserId = User.Identity.GetUserId()

                        });
               
                    }
                    catch (Exception ex)
                    {


                        LogException.Write(ex, "UploadMethodInWorkOrderController");
                    }

                    
                }

                try
                {
                  
                    _workorderService.Insert(workorders);
                }
                catch (Exception ex)
                {
                    LogException.Write(ex, "UploadMethodInWorkOrderController");
                }

                return RedirectToAction("Index");
            }
            ModelState.AddModelError("File", "Please upload Excel file ...");
            return View();
        }
        #endregion AddFromExcel
        #region Report
        [HttpPost]
        public ActionResult Report(WorkOrderModel model)
        {
            ModelState.Remove(nameof(model.Title));
            ModelState.Remove(nameof(model.Tag));
            ModelState.Remove(nameof(model.Date));
            ModelState.Remove(nameof(model.ExpireDate));
            ModelState.Remove(nameof(model.TypeId));
            ModelState.Remove(nameof(model.Status));
            ModelState.Remove(nameof(model.PriorityId));
            ModelState.Remove(nameof(model.CompanyId));

            if (System.Web.HttpContext.Current.Session["filter"] != null)
            {
                Session.Remove("filter");
                Session.Add("filter", model);
            }
            else
            {
                Session.Add("filter", model);
            }



            return RedirectToAction("Print");
        }
        public virtual ActionResult Print()
        {
            WorkOrderModel model = (WorkOrderModel)Session["filter"];
            return View();
        }
        public virtual ActionResult StiReport()
        {
            WorkOrderModel model = (WorkOrderModel)Session["filter"];


            // ایجاد شی جدید
            var mainReport = new Stimulsoft.Report.StiReport();
            try
            {
                mainReport["@priority"] = model.PriorityId == WorkOrderPriority.Unassigned ? null : model.PriorityId;
                mainReport["@type"] = model.TypeId == WorkOrderType.Unassigned ? null : model.TypeId;
                mainReport["@companyId"] = model.CompanyId == 0 ? null : model.CompanyId;
                mainReport["@status"] = model.Status == WorkOrderStatus.Select ? null : model.Status;
                mainReport["@title"] = model.TitleSearch;
                mainReport["@tag"] = model.TagSearch;
                mainReport["@date"] = model.FromDate;
                mainReport["@toDate"] = model.ToDate;
                mainReport["@expireDate"] = model.FromExpireDate;
                mainReport["@toExpireDate"] = model.ToExpireDate;
            }
            catch (Exception)
            {

                mainReport["@priority"] = null;
                mainReport["@type"] = null;
                mainReport["@companyId"] = null;
                mainReport["@status"] = null;
                mainReport["@title"] = null;
                mainReport["@tag"] = null;
                mainReport["@date"] = null;
                mainReport["@toDate"] = null;
                mainReport["@expireDate"] = null;
                mainReport["@toExpireDate"] = null;

            }

            // فراخوانی فایل استیمول
            mainReport.Load(Server.MapPath("~/ReportFiles/WorkorderReportFilter.mrt"));
            // 
            mainReport.Compile();

            //if (model.FromDate.HasValue)
            //    mainReport["FromDate"] = ConvertAdToJalali(model.FromDate.Value);
            //if (model.ToDate.HasValue)
            //    mainReport["ToDate"] = ConvertAdToJalali(model.ToDate.Value);
            //mainReport["DateAndTime"] = ConvertAdToJalaliDateTime(DateTime.Now);
            //mainReport["PersonelId"] =model.IDPersonel;
            //mainReport["AgencyId"] = _agencyService.GetById(model.AgencyId).IDAgent;
            //mainReport["MelliCode"] = model.MelliCode;

            return Stimulsoft.Report.Mvc.StiMvcViewer.GetReportSnapshotResult(mainReport);
        }
        public virtual ActionResult ViewerEvent()
        {
            return Stimulsoft.Report.Mvc.StiMvcViewer.ViewerEventResult(HttpContext);
        }
        #endregion

    }
}