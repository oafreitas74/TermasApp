using Microsoft.EntityFrameworkCore;
using TermasApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TermasApp.Data
{
    public class TermasAppContext : IdentityDbContext<ApplicationUser>
    {
        public TermasAppContext(DbContextOptions<TermasAppContext> options)
            : base(options)
        {
        }
        public DbSet<Aquista>? Aquista { get; set; }
        public DbSet<Consulta>? Consulta { get; set; }
        public DbSet<Funcionario>? Funcionario { get; set; }
        public DbSet<PedidosReparacao>? PedidosReparacao { get; set; }
        public DbSet<Precricao>? Precricao { get; set; }
        public DbSet<TipoConsulta>? TipoConsulta { get; set; }
        public DbSet<TipoTratamento>? TipoTratamento { get; set; }
        public DbSet<Tratamento>? Tratamento { get; set; }
        public DbSet<Triagem>? Triagem { get; set; }
        public DbSet<Equipamento>? Equipamento { get; set; }
    }
}
