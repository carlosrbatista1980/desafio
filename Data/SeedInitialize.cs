using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Desafio.Data.SeedData;
using Desafio.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Desafio.Data
{
    public class SeedInitialize
    {
        public static void Initialize(IApplicationBuilder application)
        {
            //Debugger.Launch();

            using (var scope = application.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetService<DesafioContext>();
                context.Database.EnsureCreated();

                //Seed
                new MarcaSeed(context).Create();
                new PatrimonioSeed(context).Create();
                new UsuarioSeed(context).Create();
            }
        }
    }
}
