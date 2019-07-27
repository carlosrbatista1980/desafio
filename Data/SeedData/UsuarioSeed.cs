using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio.Models;

namespace Desafio.Data.SeedData
{
    public class UsuarioSeed
    {
        private readonly DesafioContext _context;
        public UsuarioSeed(DesafioContext context)
        {
            _context = context;
        }

        public void Create()
        {
            var usuarios = new[]
            {
                new {nome = "Felipe", email = "felipe@gmail.com", senha = "123456"},
                new {nome = "Rosi", email = "rosi@gmail.com", senha = "654321"},
                new {nome = "Talita", email = "talita@gmail.com", senha = "135642"},
                new {nome = "Joao", email = "joao@gmail.com", senha = "162534"},
            };

            dynamic existe = null;

            foreach (var usuario in usuarios)
            {
                existe = _context.Usuario.FirstOrDefault(m => m.Nome == usuario.nome);

                if (existe == null)
                {
                    var novoUsuario = new Usuario()
                    {
                        Nome = usuario.nome,
                        Senha = usuario.senha,
                        Email = usuario.email,
                    };

                    try
                    {
                        _context.Usuario.Add(novoUsuario);
                        _context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ERRO: O sistema não conseguiu inserir o usuário '{usuario.nome}'.");
                    }
                }
            }
        }
    }
}
