using BLL.Service;
using BLL.Service.Implementation;
using DAL.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Provider
{
    public static class DependencyProvider
    {
        private static ServiceProvider _provider;

        public static bool Init()
        {
            var container = new ServiceCollection();
            container.AddSingleton<IUnitOfWork, UnitOfWork>();
            container.AddSingleton<IGuestService, GuestService>();
            container.AddSingleton<IPostService, PostService>();

            _provider = container.BuildServiceProvider();
            return true;
        }

        public static T GetDependency<T>()
        {
            return _provider.GetService<T>();
        }
    }
}
