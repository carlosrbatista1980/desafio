using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Desafio.Data.SeedData
{
    public class MarcaSeed
    {
        private readonly DesafioContext _context;
        public MarcaSeed(DesafioContext context)
        {
            _context = context;
        }

        public void Create()
        {
            var marcas = new[]
            {
                new {nome = "Tim"},
                new {nome = "Vivo"},
                new {nome = "Claro"},
            };

            dynamic existe = null;
            
            foreach (var marca in marcas)
            {
                existe = _context.Marca.FirstOrDefault(m => m.Nome == marca.nome);

                if (existe == null)
                {
                    var novaMarca = new Marca()
                    {
                        Nome = marca.nome,
                    };

                    try
                    {
                        _context.Marca.Add(novaMarca);
                        _context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ERRO: O sistema não conseguiu inserir a marca '{marca.nome}'.");
                    }
                }
            }
        }
    }
}
