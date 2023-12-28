using Microsoft.EntityFrameworkCore;
using RegistroChamado.Models;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public DbSet<SetorModel>? Setor { get; set; }
    public DbSet<ColaboradorModel>? Colaborador { get; set; }
    public DbSet<ChamadoModel>? Chamado { get; set; }
    
    
}