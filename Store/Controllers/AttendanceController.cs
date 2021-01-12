using Store.Service;
using Store.WebEssential.Mvc;
using System;
using System.Linq;
using System.Web.Mvc;
using Store.Service.Stores;
using Store.WebEssential.Helper;
using Store.Models.Stores;
using Store.WebEssential.UserControl;
using LinqToExcel;
using Store.Core.Domain.StoreTables.Attendancee;
using Store.Models;
using System.Web;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Data.Entity.Validation;
using System.Data.OleDb;
using ExcelDataReader;
using Microsoft.AspNet.Identity;
using System.Text;
using Store.WebEssential.Extensions;
using Store.Core.CommonHelper;
using Store.WebEssential.ModelBinder;
using Store.Essential.Model;
using Store.Service.User;
using Store.Core.Domain.StoreTables.User;
namespace Store.Controllers
{
    [Authorize]
    //[ServerDown]
    public class AttendanceController : BaseController
    {
        #region Fields
        private readonly IAttendanceService _attendanceService;
        private readonly ICheckingRole _checkingRoleService;
        private readonly IUserService _userService;
        private readonly IPersonnelService _personnelService;
        #endregion

        #region Utilities

        [NonAction]
        protected virtual void PrepareAllPersonnelsModel(AttendanceModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            model.PersonnelList.Add(new SelectListItem
            {
                Text = "انتخاب پرسنل",
                Value = " "
            });
            var personnels = _personnelService.GetAll();
            foreach (var c in personnels)
                model.PersonnelList.Add(new SelectListItem
                {
                    Text = $"{c.UserNameFmaily}-{c.PersonnelCode}",
                    Value = c.PersonnelCode.ToString()
                });
        }

        #endregion

        #region Ctor
        public AttendanceController(ICheckingRole checkingRoleService, IAttendanceService attendanceService, IUserService userService, IPersonnelService personnelService)
        {
            this._attendanceService = attendanceService;
            this._checkingRoleService = checkingRoleService;
            this._userService = userService;
            this._personnelService = personnelService;
        }
        #endregion

        #region List
        [HttpGet]
        public JsonResult List(DataTableRequest request, [ModelBinder(typeof(DataTableModelBinder))]DataTableRequestFilter filter,AttendanceModel model)

        {
            if (request.length == -1)
            {
                request.length = int.MaxValue;
            }
            var data = _attendanceService.FilterData(request.start, request.length, filter.Search, filter.SortColumn, filter.SortDirection,model.FromDate,model.ToDate,model.SinglePersonnelCode,model.PresenceStatus);


            var gridModel = new DataTableResponse<AttendanceModel>()
            {
                data = data.Select(x =>
                {

                    var m = new AttendanceModel();
                    m.SinglePersonnelCode = x.PersonnelCode;
                    m.FamilyName = _personnelService.GetById(x.PersonnelCode)!=null ? _personnelService.GetById(x.PersonnelCode).UserNameFmaily:"";
                    m.PresenceStatusTitle = x.PresenceStatus.GetDisplayName();
                    m.ShamsiDate = ConvertAdToJalali(x.Date);
                    m.ShamsiCreateDate = ConvertAdToJalaliDateTime(x.CreatedDate.Value);
                    m.StringTime = x.Time.ToString();
                    m.ActionUserName = _userService.GetById(x.ActionUserId).UserName;
                    m.Id = x.Id;

                    if (x.ModifiedDate != null)
                    {
                        m.ShamsiEditDate = ConvertAdToJalaliDateTime(x.ModifiedDate.Value);
                    }
                    if (x.LastActionUserId != null && !string.IsNullOrEmpty(x.LastActionUserId))
                    {
                        m.EditUserName = _userService.GetById(x.LastActionUserId).UserName;
                    }


                    return m;
                }).ToList(),
                recordsTotal = _attendanceService.Count(filter.Search, model.FromDate, model.ToDate, model.SinglePersonnelCode, model.PresenceStatus),
                recordsFiltered = _attendanceService.Count(filter.Search, model.FromDate, model.ToDate, model.SinglePersonnelCode, model.PresenceStatus),
                draw = request.draw
            };



            return Json(gridModel, JsonRequestBehavior.AllowGet);
        }

        #endregion
        #region ActionMethod

        public ActionResult Index()
        {
            var model = new AttendanceModel();

            if (!_checkingRoleService.HasAccess(PermissionList.AttendanceList, CurrentUser.GetCurrentUser))
            {
                return View("Inaccessibility");
            }
            ///آماده سازی نوع تردد
            model.PresenceStatusList = PresenceStatus.Unknown.ToSelectList().ToList();

            ///آماده سازی پرسنل
            PrepareAllPersonnelsModel(model);

            return View(model);
        }
        public ActionResult Create()
        {
            var model = new AttendanceModel();

            if (!_checkingRoleService.HasAccess(PermissionList.AttendanceCreate, CurrentUser.GetCurrentUser))
            {
                return View("Inaccessibility");
            }

            ///آماده سازی نوع تردد
            model.PresenceStatusList = PresenceStatus.Unknown.ToSelectList().ToList();

            ///آماده سازی پرسنل
            PrepareAllPersonnelsModel(model);
            model.Time= new TimeSpan(0, 0, 0);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(AttendanceModel model)
        {
            var result = new ReturnAjaxForm();

            ///اگر کاربر هیچ کاربری را انتخاب نکرده باشد
            if (model.PersonnelCode.Count == 0)
                ModelState.AddModelError("PersonnelCode", "حداقل یک پرسنل انتخاب نمایید");
            if (model.PresenceStatus.Value == PresenceStatus.Entry && model.Time==null)
                ModelState.AddModelError("Time", "ساعت ورود الزامی است");

            var entities = new List<Attendance>();
            if (ModelState.IsValid)
            {
                try
                {

                    foreach (var personnelCode in model.PersonnelCode)
                    {
                        entities.Add(new Attendance
                        {
                            PersonnelCode = personnelCode,
                            PresenceStatus = model.PresenceStatus.Value,
                            Time= model.Time.Value,
                            Date = model.Date.Value.Date,
                            ActionUserId = User.Identity.GetUserId()
                        });
                    }


                    ///عملیات ثبت در دیتابیس
                    _attendanceService.Insert(entities);

                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                    ShowMessageToUser(result, "با موفقیت ثبت شد .", ResultType.Success);
                }
                catch (Exception ex)
                {
                    LogException.Write(ex, "CreateMethodInAttendanceController");
                    ///نمایش پیام خطا به کاربر

                    ShowMessageToUser(result, ex.Message, ResultType.Failure);
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

        public ActionResult Edit(int id)
        {
            if (!_checkingRoleService.HasAccess(PermissionList.AttendanceEdit, CurrentUser.GetCurrentUser))
            {
                return PartialView("_Inaccessibility");
            }

            var entity = _attendanceService.GetById(id);
            var model = new AttendanceModel
            {
                Id = entity.Id,
                Date = entity.Date,
                Time = entity.Time,
                //PersonnelCode = entity.PersonnelCode,
                PresenceStatus = entity.PresenceStatus

            };
            model.PresenceStatusList = PresenceStatus.Unknown.ToSelectList().ToList();

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(AttendanceModel model)
        {
            var result = new ReturnAjaxForm();

            var entities = new List<Attendance>();
            if (ModelState.IsValid)
            {
                try
                {

                    var entity = _attendanceService.GetById(model.Id);

                    entity.PresenceStatus = model.PresenceStatus.Value;
                    entity.Time = model.Time.Value;
                    entity.Date = model.Date.Value;
                    entity.LastActionUserId = User.Identity.GetUserId();
                    entity.ModifiedDate = DateTime.Now;


                    ///عملیات ثبت در دیتابیس
                    _attendanceService.Update(entity);
                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                    ShowMessageToUser(result, "با موفقیت ویرایش شد .", ResultType.Success);
                }
                catch (Exception ex)
                {
                    LogException.Write(ex, "EditMethodInAttendanceController");

                    ///نمایش پیام خطا به کاربر

                    ShowMessageToUser(result, ex.Message, ResultType.Failure);
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
        public ActionResult Delete(int id)
        {
            var result = new ReturnAjaxForm();

            if (!_checkingRoleService.HasAccess(PermissionList.AttendanceDelete, CurrentUser.GetCurrentUser))
            {
                result.ResultType = ResultType.NotAllow;
                result.Message = " کاربر گرامی،شما  مجوز حذف رکورد را ندارید!  ";
                return Json(result, JsonRequestBehavior.AllowGet);
            }


            try
            {
                var entity = _attendanceService.GetById(id);
                _attendanceService.Remove(entity);

                result.ResultType = ResultType.Success;
                result.Message = " با موفقیت حذف شد";
            }
            catch (Exception ex)
            {
                /// لاگ خطا

                LogException.Write(ex, "DeleteMethodInAttendanceController");


                ///نمایش پیام خطا به کاربر

                ShowMessageToUser(result, "امکان حذف  رکورد وجود ندارد.", ResultType.Failure);
            }

            return Json(result, JsonRequestBehavior.AllowGet);

        }
        public ActionResult ExcelUpload()
        {
            if (!_checkingRoleService.HasAccess(PermissionList.AttendanceCreate, CurrentUser.GetCurrentUser))
            {
                return View("Inaccessibility");
            }

            return View();
        }
        //[HttpPost]
        //public ActionResult UploadExcel(EmployeeInfo objEmpDetail, HttpPostedFileBase FileUpload)
        //{


        //    string data = "";
        //    if (FileUpload != null)
        //    {
        //        if (FileUpload.ContentType == "application/vnd.ms-excel" || FileUpload.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
        //        {
        //            string filename = FileUpload.FileName;
        //            var columnHeaders = new List<string>();
        //            columnHeaders.Add("شماره پرسنلی");


        //            if (filename.EndsWith(".xlsx"))
        //            {
        //                string targetpath = Server.MapPath("~/Content/");
        //                FileUpload.SaveAs(targetpath + filename);
        //                string pathToExcelFile = targetpath + filename;

        //                string sheetName = "Sheet1";

        //                var excel = new ExcelQueryFactory(pathToExcelFile);
        //                excel.AddMapping<Attendance>(x => x.PersonnelCode, "شماره پرسنلی");
        //                //var SheetColumnNames = excel.GetColumnNames(sheetName);
        //                var empDetails = from a in excel.Worksheet<Attendance>(sheetName) select a;




        //                foreach (var a in empDetails)
        //                {

        //                }

        //            }

        //            else
        //            {
        //                data = "This file is not valid format";
        //                ViewBag.Message = data;
        //            }
        //            return View("ExcelUpload");

        //        }
        //        else
        //        {

        //            data = "Only Excel file format is allowed";

        //            ViewBag.Message = data;
        //            return View("ExcelUpload");

        //        }

        //    }
        //    else
        //    {

        //        if (FileUpload == null)
        //        {
        //            data = "Please choose Excel file";
        //        }

        //        ViewBag.Message = data;
        //        return View("ExcelUpload");

        //    }
        //}

        //[HttpPost]
        //public ActionResult UploadExcel2(EmployeeInfo probes, HttpPostedFileBase FileUpload)
        //{

        //    var data = new List<string>();
        //    if (FileUpload != null)
        //    {
        //        if (FileUpload.ContentType == "application/vnd.ms-excel" || FileUpload.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
        //        {
        //            var filename = FileUpload.FileName;
        //            var targetpath = Server.MapPath("~/Content/");
        //            FileUpload.SaveAs(targetpath + filename);
        //            var pathToExcelFile = targetpath + filename;
        //            string FileName = Path.GetFileName(FileUpload.FileName);
        //            string Extension = Path.GetExtension(FileUpload.FileName);
        //            DataTable dataFound = Import_To_Grid(pathToExcelFile, Extension, "Yes");
        //            List<Attendance> dataProbList = new List<Attendance>();
        //            foreach (DataRow item in dataFound.Rows)
        //            {
        //                try
        //                {
        //                    //var attendance = new Attendance();
        //                    //attendance.PersonnelCode = Convert.ToInt32(item.ItemArray[2].ToString());
        //                    //attendance.Time = Convert.ToDateTime(item.ItemArray[0]).TimeOfDay;
        //                    //attendance.Date = DateTime.Now.Date;

        //                    //_attendanceService.Insert(attendance);

        //                }
        //                catch (DbEntityValidationException ex)
        //                {
        //                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
        //                    {

        //                        foreach (var validationError in entityValidationErrors.ValidationErrors)
        //                        {

        //                            Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);

        //                        }

        //                    }
        //                }

        //            }
        //            //deleting excel file from folder  
        //            if ((System.IO.File.Exists(pathToExcelFile)))
        //            {
        //                System.IO.File.Delete(pathToExcelFile);
        //            }
        //            ViewBag.ProbeData = dataProbList;
        //            //ViewBag.SCImportData = dataSCImporobList;
        //            return View("Index");
        //        }
        //        else
        //        {
        //            //alert message for invalid file format  
        //            data.Add("<ul>");
        //            data.Add("<li>Only Excel file format is allowed</li>");
        //            data.Add("</ul>");
        //            data.ToArray();
        //            return Json(data, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    else
        //    {
        //        data.Add("<ul>");
        //        if (FileUpload == null) data.Add("<li>Please choose Excel file</li>");
        //        data.Add("</ul>");
        //        data.ToArray();
        //        return Json(data, JsonRequestBehavior.AllowGet);
        //    }
        //}
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
                var all = new List<Attendance>();
                var personnels = new List<Personnel>();

                foreach (DataRow row in result.Tables[0].Rows)
                {

                    //foreach (DataColumn col in row)
                    //{
                    try
                    {

                        all.Add(new Attendance
                        {
                            PersonnelCode = Convert.ToInt32(row[12]),
                            Description = Convert.ToString(row[5]),
                            PresenceStatus = Convert.ToString(row[5]).Contains("ورود") ? PresenceStatus.Entry : PresenceStatus.Exit,
                            Time = TimeSpan.Parse(row[7].ToString()),
                            Date = DateTime.Now.Date,
                            ActionUserId = User.Identity.GetUserId()

                        });
                        //if (_personnelService.GetAll().Count <= 0)
                        //{
                           
                            personnels.Add(new Personnel
                            {
                                PersonnelCode = Convert.ToInt32(row[12]),
                                UserNameFmaily = Convert.ToString(row[16]),
                                CreatedDate = DateTime.Now,
                                ActionUserId = User.Identity.GetUserId()

                            });

                        //}



                    }
                    catch (Exception e)
                    {


                    }




                    //}
                }

                try
                {
                    //if(personnels.Count>0)
                    //{
                    foreach (var per in personnels)
                    {
                            _personnelService.Insert(per);
                        
                    }
                    
                        

                    //}

                    _attendanceService.Insert(all);
                }
                catch (Exception ex)
                {
                    LogException.Write(ex, "UploadMethodInAttendanceController");
                }
              
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("File", "Please upload Excel file ...");
            return View();
        }
        private DataTable Import_To_Grid(string FilePath, string Extension, string isHDR)
        {
            string conStr = "";
            switch (Extension)
            {
                case ".xls": //Excel 97-03
                    conStr =

                        conStr = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", FilePath);


                    break;
                case ".xlsx": //Excel 07
                    conStr = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";", FilePath);
                    break;
            }
            conStr = String.Format(conStr, FilePath, isHDR);
            OleDbConnection connExcel = new OleDbConnection(conStr);
            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbDataAdapter oda = new OleDbDataAdapter();
            DataTable dt = new DataTable();
            cmdExcel.Connection = connExcel;

            //Get the name of First Sheet
            connExcel.Open();
            DataTable dtExcelSchema;
            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
            connExcel.Close();

            //Read Data from First Sheet
            connExcel.Open();
            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
            oda.SelectCommand = cmdExcel;
            oda.Fill(dt);
            connExcel.Close();
            return dt;

        }

        #endregion

        #region Report
        [HttpPost]
        public ActionResult Report(AttendanceModel model)
        {
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
            AttendanceModel model = (AttendanceModel)Session["filter"];
            return View();
        }
        public virtual ActionResult StiReport()
        {
            AttendanceModel model = (AttendanceModel)Session["filter"];


            // ایجاد شی جدید
            var mainReport = new Stimulsoft.Report.StiReport();
            try
            {
                mainReport["@personnelCode"] = model.SinglePersonnelCode;
                mainReport["@status"] =model.PresenceStatus==PresenceStatus.Unknown?null: model.PresenceStatus;
                mainReport["@fromDate"] = model.FromDate;
                mainReport["@toDate"] = model.ToDate;
            }
            catch (Exception)
            {

                mainReport["@personnelCode"] = null;
                mainReport["@status"] = null;
                mainReport["@fromDate"] = null;
                mainReport["@toDate"] = null;

            }

            // فراخوانی فایل استیمول
            mainReport.Load(Server.MapPath("~/ReportFiles/PersonnelAttendanceReport.mrt"));
            // 
            mainReport.Compile();
            try
            {
                mainReport["@personnelCode"] = model.SinglePersonnelCode;
                mainReport["@status"] = model.PresenceStatus == PresenceStatus.Unknown ? null : model.PresenceStatus;
                mainReport["@fromDate"] = model.FromDate;
                mainReport["@toDate"] = model.ToDate;
            }
            catch (Exception)
            {

                mainReport["@personnelCode"] = null;
                mainReport["@status"] = null;
                mainReport["@fromDate"] = null;
                mainReport["@toDate"] = null;

            }

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