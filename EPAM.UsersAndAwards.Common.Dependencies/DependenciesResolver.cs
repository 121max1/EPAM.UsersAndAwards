using EPAM.UsersAndAwards.BLL;
using EPAM.UsersAndAwards.DAL.SqlDAL;
using EPAM.UsersAndAwards.BLL.Interfaces;
using EPAM.UsersAndAwards.DAL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.UsersAndAwards.Common.Dependencies
{
    public class DependenciesResolver
    {
        public static IServiceProvider Kernel { get; private set; }
        private static IServiceCollection _services { get; set; }

        static DependenciesResolver()
        {
            _services = new ServiceCollection();
            Kernel = Configurates();
        }

        private static IServiceProvider Configurates()
        {

            _services.AddTransient<IUserDAO, UserDAO>();
            _services.AddTransient<IAwardDAO, AwardDAO>();
            _services.AddTransient<IUserAwardDAO, UserAwardDAO>();
            _services.AddTransient<IUserAuthDAO, UserAuthDAO>();

            _services.AddTransient<IUserService, UserService>();
            _services.AddTransient<IAwardService, AwardService>();
            _services.AddTransient<IUserAwardService, UserAwardService>();
            _services.AddTransient<IUserAuthService, UserAuthService>();



            return _services.BuildServiceProvider();
        }
    }
}
