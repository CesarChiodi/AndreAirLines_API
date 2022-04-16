using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreAirLines_API.Model;

namespace AndreAirLines_API.Data
{
    public class AndreAirLines_APIContext : DbContext
    {
        public AndreAirLines_APIContext (DbContextOptions<AndreAirLines_APIContext> options)
            : base(options)
        {
        }

        public DbSet<AndreAirLines_API.Model.Aeronave> Aeronave { get; set; }

        public DbSet<AndreAirLines_API.Model.Aeroporto> Aeroporto { get; set; }

        public DbSet<AndreAirLines_API.Model.Endereco> Endereco { get; set; }

        public DbSet<AndreAirLines_API.Model.Passageiro> Passageiro { get; set; }

        public DbSet<AndreAirLines_API.Model.Voo> Voo { get; set; }

        public DbSet<AndreAirLines_API.Model.Classe> Classe { get; set; }

        public DbSet<AndreAirLines_API.Model.Passagem> Passagem { get; set; }

        public DbSet<AndreAirLines_API.Model.PrecoBase> PrecoBase { get; set; }


    }
}
