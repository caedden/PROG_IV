namespace ProgramacaoIV.ToDoList.Model;

public sealed class Notas
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Aluno { get; set; } = string.Empty;
    public string Disciplina { get; set; } = string.Empty;
    public decimal Valor { get; set; } = decimal.Zero;

    public DateTime DataLancamento { get; set; } = DateTime.UtcNow;
}