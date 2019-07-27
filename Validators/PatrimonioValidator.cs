using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Desafio.Data;
using Microsoft.AspNetCore.Rewrite.Internal.ApacheModRewrite;
using Microsoft.CodeAnalysis;
using Desafio.Models;

namespace Desafio.Validators
{
    public class PatrimonioValidator
    {
        private readonly DesafioContext _context;

        public PatrimonioValidator(DesafioContext context)
        {
            _context = context;
        }

        public bool PatrimonioValidateNumeroTombo(Patrimonio patrimonio)
        {
            var valid = _context.Patrimonio.FirstOrDefault(x => x.Id == patrimonio.Id);
            
            if (patrimonio.NumeroTombo.Value != valid.NumeroTombo)
            {
                return false;
            }

            return true;
        }
    }
}
