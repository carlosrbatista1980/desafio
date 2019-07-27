using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio.Models;

namespace Desafio.Data.SeedData
{
    public class PatrimonioSeed
    {
        private readonly DesafioContext _context;

        public PatrimonioSeed(DesafioContext context)
        {
            _context = context;
        }

        public void Create()
        {
            var patrimonios = new[]
            {
                new {nome = "Casa", descricao = "descricao 001", numeroTombo = 88999},
                new {nome = "Predio", descricao = "descricao 002", numeroTombo = 54333},
                new {nome = "Carro", descricao = "descricao 003", numeroTombo = 23454},
                new {nome = "Eletronico", descricao = "descricao 004", numeroTombo = 50964},
            };

            dynamic existe = null;

            foreach (var patrimonio in patrimonios)
            {
                existe = _context.Patrimonio.FirstOrDefault(m => m.Nome == patrimonio.nome);
                if (existe == null)
                {
                    int marca = 0;

                    if(patrimonio.nome == "Casa" || patrimonio.nome == "Predio")
                        marca = _context.Marca.FirstOrDefault(m => m.Id == 1).Id;
                    else if(patrimonio.nome == "Carro")
                        marca = _context.Marca.FirstOrDefault(m => m.Id == 2).Id;
                    else if (patrimonio.nome == "Eletronico")
                        marca = _context.Marca.FirstOrDefault(m => m.Id == 3).Id;

                    var novoPatrimonio = new Patrimonio()
                    {
                        Nome = patrimonio.nome,
                        Descricao = patrimonio.descricao,
                        NumeroTombo = patrimonio.numeroTombo,
                        MarcaId = marca,
                    };

                    try
                    {
                        _context.Patrimonio.Add(novoPatrimonio);
                        _context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ERRO: O sistema não conseguiu inserir o patrimonio '{patrimonio.nome}'.");
                    }
                }
            }
        }
    }
}
