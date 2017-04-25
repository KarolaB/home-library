﻿using System.Collections.Generic;
using System.Reflection;
using Autofac;
using Autofac.Integration.SignalR;
using Autofac.Integration.WebApi;
using HomeLibrary.Api.Hubs;
using HomeLibrary.DataLayer;
using HomeLibrary.Services;
using Newtonsoft.Json;

namespace HomeLibraryWeb
{
    public class InversionOfControlConfiguration
    {
        private static IContainer _container;

        public static IContainer Container
        {
            get
            {
                if (_container == null)
                {
                    _container = BuildContainer();
                }

                return _container;
            }
        }

        private static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<LibraryRepository>().As<ILibraryRepository>();

            builder.RegisterType<GetLibraryState>().As<IQueryHandler<GetLibraryStateQuery, LibraryState>>();
            builder.RegisterType<FindBook>().As<IQueryHandler<FindBookQuery, IList<Book>>>();

            builder.RegisterHubs(typeof(BooksHub).Assembly);

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            var serializer = JsonSerializer.CreateDefault();
            builder.Register(s => serializer).As<JsonSerializer>();
            
            return builder.Build();
        }
    }
}