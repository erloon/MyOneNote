using System.Reflection;
using Autofac;
using MyOneNote.EF;
using MyOneNote.Services;
using MyOneNote.WWW.Services;


namespace MyOneNote.WWW.Infrastructure
{
    public class ApiModule: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var dataAccess = Assembly.GetEntryAssembly();

            //builder.RegisterGeneric(typeof(UnitOfWork<>))
            //    .As<IUnitOfWork>()
            //    .InstancePerLifetimeScope();
            builder.RegisterType<AuthMessageSender>()
                .As<IEmailSender>()
                .InstancePerLifetimeScope();

           

            builder.RegisterType<AuthMessageSender>()
                .As<ISmsSender>()
                .InstancePerLifetimeScope();

            builder.RegisterType<NoteService>()
                .As<INoteService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<CategoryService>()
                .As<ICategoryService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ProjectService>()
                .As<IProjectService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<UserService>()
                .As<IUserService>()
                .InstancePerLifetimeScope();


            //builder.RegisterAssemblyTypes(dataAccess)
            //    .Where(t => t.Name.EndsWith("Service"))
            //    .AsImplementedInterfaces();
        }
    }
}