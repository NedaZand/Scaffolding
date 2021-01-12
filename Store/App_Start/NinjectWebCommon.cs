[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Store.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Store.App_Start.NinjectWebCommon), "Stop")]

namespace Store.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Data;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Core.Domain.StoreTables.User;
    using Service.User;
    using Microsoft.Owin.Security;
    using Service;
    using WebEssential.Extensions;
    using WebEssential.UserControl;
    using Ninject.Web.Common.WebHost;
    using Store.Service.Stores;
    using Store.Service.Media;
    using Store.Service.Setting;
    using Store.Core;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IDbContext>().To<StoreContext>().InRequestScope();
            kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>));
            kernel.Bind<IUserStore<ApplicationUser>>().To<ApplicationUserStore>();
            kernel.Bind<IRoleStore<ApplicationRole, string>>().To<ApplicationRoleStore>();

            kernel.Bind<ApplicationUserManager>().ToSelf();
            kernel.Bind<ApplicationRoleManager>().ToSelf();
            kernel.Bind<ApplicationSignInManager>().ToSelf();
            kernel.Bind<IAuthenticationManager>().ToMethod(x => HttpContext.Current.GetOwinContext().Authentication);
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IRoleService>().To<RoleService>();


            kernel.Bind<ISettingService>().To<SettingService>();

            kernel.Bind<IPictureService>().To<PictureService>();
            kernel.Bind<HttpContext>().ToMethod(ctx => HttpContext.Current).InTransientScope();

           // kernel.Bind<HttpContextBase>().ToMethod(ctx => new HttpContextWrapper(HttpContext.Current)).InTransientScope();



            kernel.Bind<IPermissionService>().To<PermissionService>();
            kernel.Bind<ICheckingRole>().To<CheckingRole>();
            kernel.Bind<IEmployeeTypeService>().To<EmployeeTypeService>();
            kernel.Bind<IRoutinService>().To<RoutinService>();
            kernel.Bind<ICompanyService>().To<CompanyService>();
            kernel.Bind<IWorkorderAssignedUsersService>().To<WorkorderAssignedUsersService>();
            kernel.Bind<IAssignedWorkorderService>().To<AssignedWorkorderService>();
            kernel.Bind<IAttendanceService>().To<AttendanceService>();
            kernel.Bind<IPositionTypeService>().To<PositionTypeService>();
            kernel.Bind<IWorkOrderService>().To<WorkOrderService>();
            kernel.Bind<IPersonnelService>().To<PersonnelService>();
            kernel.Bind<IAssignedWorkorderDetailService>().To<AssignedWorkorderDetailService>();
            kernel.Bind<IAssignedTaskService>().To<AssignedTaskService>();
            kernel.Bind<IAssignedTaskUserService>().To<AssignedTaskUserService>();
            kernel.Bind<IEarthService>().To<EarthService>();
            kernel.Bind<IBuildingService>().To<BuildingService>();
            kernel.Bind<IMessageService>().To<MessageService>();
            kernel.Bind<IPropertyService>().To<PropertyService>();
            kernel.Bind<IScaffoldHasEquipmentService>().To<ScaffoldHasEquipmentService>();
            kernel.Bind<IEquipmentService>().To<EquipmentService>();
            kernel.Bind<IEquipmentHasPropertyService>().To<EquipmentHasPropertyService>();
            kernel.Bind<IScaffoldingService>().To<ScaffoldingService>();
            kernel.Bind<IPersonnelDetailService>().To<PersonnelDetailService>();
            kernel.Bind<IPersonnelDetailValueService>().To<PersonnelDetailValueService>();
            kernel.Bind<IPesonnelHasDetailService>().To<PesonnelHasDetailService>();
            kernel.Bind<IScaffoldTypeService>().To<ScaffoldTypeService>();
            kernel.Bind<IUnitService>().To<UnitService>();
            kernel.Bind<ICompanyStoreRoomService>().To<CompanyStoreRoomService>();
            kernel.Bind<IWebHelper>().To<WebHelper>();
            kernel.Bind<IBuyMaterialService>().To<BuyMaterialService>();
            kernel.Bind<IStockService>().To<StockService>();
            kernel.Bind<IOutputMaterialService>().To<OutputMaterialService>();
            kernel.Bind<IInputMaterialService>().To<InputMaterialService>();
            kernel.Bind<IWorkgroupService>().To<WorkgroupService>();
            kernel.Bind<IWorkgroupPersonnelService>().To<WorkingGroupPersonnelService>();
            kernel.Bind<IQuestionService>().To<QuestionService>();
            kernel.Bind<IAnswerService>().To<AnswerService>();
            kernel.Bind<IOutputMaterialHasEquipmentService>().To<OutputMaterialHasEquipmentService>();
            kernel.Bind<IInputMaterialHasEquipmentService>().To<InputMaterialHasEquipmentService>();


        }

    }
}
