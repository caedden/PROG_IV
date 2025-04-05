
using Microsoft.EntityFrameworkCore;
using ProgramacaoIV.ToDoList.Context;
using ProgramacaoIV.ToDoList.Model;

namespace ProgramacaoIV.ToDoList;

public class Program
{
    private const string _connectionString = "Server=localhost;Port=3307;Database=umfg_todo_list;Uid=root;Pwd=root;";

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<TodoContext>(options => options.UseMySQL(_connectionString));

        var app = builder.Build();

        #region endpoints

        // GET - Listar todas as notas
        app.MapGet("/notas", async (TodoContext context) => await context.Notas.ToListAsync());

        // GET - Obter uma nota por ID
        app.MapGet("/notas/{id}", async (string id, TodoContext context) =>
            await context.Notas.FindAsync(Guid.Parse(id)) is Notas todo ? Results.Ok(todo) : Results.NotFound());

        // POST - Criar uma nova nota
        app.MapPost("/notas", async (Notas todo, TodoContext context) => {
            context.Notas.Add(todo);
            await context.SaveChangesAsync();

            return Results.Created($"/notas/{todo.Id}", todo);
        });

        // PUT - Atualizar uma nota
        app.MapPut("/notas/{id}", async (string id, Notas inputTodo, TodoContext context) => {
            var todo = await context.Notas.FindAsync(Guid.Parse(id));
            
            if (todo is null) 
                return Results.NotFound();

            todo.Aluno = inputTodo.Aluno;
            todo.Disciplina = inputTodo.Disciplina;
            todo.Valor = inputTodo.Valor;


            await context.SaveChangesAsync();

            return Results.NoContent();
        });

        // DELETE - Remover uma nota
        app.MapDelete("/notas/{id}", async (string id, TodoContext context) => {
            var todo = await context.Notas.FindAsync(Guid.Parse(id));
            
            if (todo is null) 
                return Results.NotFound();

            context.Notas.Remove(todo);
            await context.SaveChangesAsync();

            return Results.NoContent();
        });

        #endregion endpoints

        app.Run();
    }
}