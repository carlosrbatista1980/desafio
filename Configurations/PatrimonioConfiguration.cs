using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.Configurations
{
    public class PatrimonioConfiguration : IEntityTypeConfiguration<Patrimonio>
    {
        public void Configure(EntityTypeBuilder<Patrimonio> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Nome).IsRequired().IsUnicode(false);
            builder.Property(x => x.Descricao).IsRequired(false);
            builder.Property(x => x.NumeroTombo).IsRequired(false);

            //Foreign Keys
            builder.HasOne(x => x.Marca)
                .WithMany(m => m.Patrimonios)
                .HasForeignKey(f => f.MarcaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
