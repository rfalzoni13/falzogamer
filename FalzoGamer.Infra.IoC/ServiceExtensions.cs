using FalzoGamer.Application.AppServices;
using FalzoGamer.Application.AppServices.Base;
using FalzoGamer.Application.Interfaces;
using FalzoGamer.Application.Interfaces.Base;
using FalzoGamer.Domain.Interfaces;
using FalzoGamer.Domain.Interfaces.Repositories;
using FalzoGamer.Domain.Interfaces.Repositories.Base;
using FalzoGamer.Domain.Interfaces.Services;
using FalzoGamer.Domain.Interfaces.Services.Base;
using FalzoGamer.Infra.Data.Context;
using FalzoGamer.Infra.Data.Repositories;
using FalzoGamer.Infra.Data.Repositories.Base;
using FalzoGamer.Services.Base;
using FalzoGamer.Services.Classes;
using Microsoft.Extensions.DependencyInjection;

namespace FalzoGamer.Infra.IoC
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IBaseRepositorio<>), typeof(BaseRepositorio<>));
            services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddTransient<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddTransient<ICategoriaRepositorio, CategoriaRepositorio>();

            services.AddTransient(typeof(IServicoBase<>), typeof(ServicoBase<>));
            services.AddTransient<IUsuarioServico, UsuarioServico>();
            services.AddTransient<IProdutoServico, ProdutoServico>();
            services.AddTransient<ICategoriaServico, CategoriaServico>();

            services.AddTransient(typeof(IBaseAppServico<>), typeof(BaseAppServico<>));
            services.AddTransient<IUsuarioAppServico, UsuarioAppServico>();
            services.AddTransient<IProdutoAppServico, ProdutoAppServico>();
            services.AddTransient<ICategoriaAppServico, CategoriaAppServico>();

            services.AddTransient<IFalzoGamerContext, FalzoGamerContext>();
            return services;
        }
    }
}
