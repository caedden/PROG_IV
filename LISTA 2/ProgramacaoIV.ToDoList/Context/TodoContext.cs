using Microsoft.EntityFrameworkCore;
using ProgramacaoIV.ToDoList.Model;

namespace ProgramacaoIV.ToDoList.Context;

public sealed class TodoContext : DbContext
{
    public DbSet<Notas> Notas { get; set; }

    public TodoContext(DbContextOptions<TodoContext> options) : base(options) 
    {
        if (Database.GetPendingMigrations().Any())
            Database.Migrate();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region nota

        modelBuilder.Entity<Notas>().HasKey(t => t.Id);
        modelBuilder.Entity<Notas>().Property(t => t.Aluno).IsRequired();
        modelBuilder.Entity<Notas>().Property(t => t.Disciplina).IsRequired();
        modelBuilder.Entity<Notas>().Property(t => t.Valor).IsRequired();
        modelBuilder.Entity<Notas>().Property(t => t.DataLancamento).IsRequired();



        #endregion nota
    }
}