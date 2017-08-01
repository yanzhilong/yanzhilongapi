﻿using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using yanzhilong.Repository;
using yanzhilong.Service;

namespace yanzhilongapi
{
    public class Autofac
    {
        public static IContainer Container { get; set; }

        public static void Application_Start()
        {
            // Create your builder.
            var builder = new ContainerBuilder();

            // 注册所有的MVC Controller
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            // 注册所有的Web Api Controller
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            RegisterAll(builder);

            //把容器装入到微软默认的依赖注入容器中
            Container = builder.Build();

            //MVC
            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));

            //WebApi
            var resolver = new AutofacWebApiDependencyResolver(Container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;

        }

        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <param name="builder"></param>
        private static void RegisterAll(ContainerBuilder builder)
        {

            // 注册类型，每次创建一个新的实例(不写默认就是这个)
            //builder.RegisterType<SomeType>().As<IService>().InstancePerDependency();

            // 注册类型,单例模式，只创建一个实例
            //builder.RegisterType<SomeType>().As<IService>().SingleInstance();

            // 注册类型,生命周期模式，每个生命周期每次创建一个新的实例
            //builder.RegisterType<SomeType>().As<IService>().InstancePerLifetimeScope();

            //泛型注册
            //builder.RegisterGeneric(typeof(NHibernateRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope()

            //手动注入，需要已经注入的值 
            //builder.Register(c => new LogManager(DateTime.Now, c.Resolve<IService>)).As<ILogger>();

            //注册实体
            //builder.RegisterType<TaskController>();

            //手动注入单例
            //builder.RegisterInstance(new TaskRepository()).As<ITaskRepository>();

            //手动注入，每次创建一个新的实例
            //builder.Register(new TaskRepository()).As<ITaskRepository>();

            builder.RegisterGeneric(typeof(MbRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            builder.RegisterType<BrowsingService>();
            
        }
    }
}