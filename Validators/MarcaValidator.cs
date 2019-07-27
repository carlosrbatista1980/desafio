using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio.Data;
using Desafio.Models;

namespace Desafio.Validators
{
    public class MarcaValidator
    {
        private readonly DesafioContext _context;

        public MarcaValidator(DesafioContext context)
        {
            _context = context;
        }

        public bool MarcaValidateNomeDuplicado(Marca marca)
        {
            var m = _context.Marca.FirstOrDefault(x => x.Id == marca.Id);
            if (m.Nome == marca.Nome)
                return false;
            return true;
        }
    }
}
