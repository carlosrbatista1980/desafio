using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio.Data;
using Desafio.Models;

namespace Desafio.Validators
{
    public class UsuarioValidator
    {
        private readonly DesafioContext _context;

        public UsuarioValidator(DesafioContext context)
        {
            _context = context;
        }

        public bool UsuarioValidateEmail(Usuario usuario)
        {
            var valid = _context.Usuario.FirstOrDefault(x => x.Id == usuario.Id);

            if (usuario.Email == valid.Email)
                return false;
            return true;
        }
    }
}
