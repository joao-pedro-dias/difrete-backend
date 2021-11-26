using Microsoft.Extensions.DependencyInjection;
using System;
using Template.Application.Interfaces;
using Template.Application.Services;
using Template.Data.Repositories;
using Template.Domain.Interfaces;

namespace Template.Ioc
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion

            #region Repositories2
            services.AddScoped<IFretistaRepository, FretistaRepository>();
            #endregion

            #region Repositories3
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<ISolicitacaoRepository, SolicitacaoRepository>();
            services.AddScoped<IStatusSolicitacaoRepository, StatusSolicitacaoRepository>();
            #endregion

            #region Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ISolicitacaoService, SolicitacaoService>();
            #endregion

            #region Services2
            services.AddScoped<IFretistaService, FretistaService>();
            #endregion

        }
    }
}