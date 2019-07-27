using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Models
{
    public class Patrimonio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int MarcaId { get; set; }
        public string Descricao { get; set; }
        public int? NumeroTombo { get; set; }
        public Marca Marca { get; set; }
    }
}
