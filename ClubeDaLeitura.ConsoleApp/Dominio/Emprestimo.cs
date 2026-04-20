using System;

namespace ClubeDaLeitura.ConsoleApp.Dominio;

public class Emprestimo : EntidadeBase
{
    public Amigo amigo { get; set; }
    public Revista revista { get; set; }
    public DateTime dataDeEmprestimo { get; set; } = DateTime.Now;
    public DateTime dataDeDevolucao { get; set; }
    public string status { get; set; } = string.Empty;

    public Emprestimo(Amigo amigo, Revista revista, DateTime dataDeEmprestimo, DateTime dataDeDevolucao, string status)
    {
        this.amigo = amigo;
        this.revista = revista;
        this.dataDeEmprestimo = dataDeEmprestimo;
        this.dataDeDevolucao = dataDeDevolucao;
        this.status = status;
    }

    public override string[] Validar()
    {
        throw new NotImplementedException();
    }

    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        Emprestimo emprestimoAtualizado = (Emprestimo)entidadeAtualizada;

        amigo = emprestimoAtualizado.amigo;
        revista = emprestimoAtualizado.revista;
        dataDeEmprestimo = emprestimoAtualizado.dataDeEmprestimo;
        dataDeDevolucao = emprestimoAtualizado.dataDeDevolucao;
        status = emprestimoAtualizado.status;
    }
}
