
using System.Security.Cryptography;

namespace ClubeDaLeitura.ConsoleApp.Dominio;

public class Emprestimo
{
    public string Id { get; set; } = string.Empty;
    public Amigo Amigo { get; set; }
    public Revista Revista { get; set; }
    public DateTime DataDeEmprestimo { get; set; } = DateTime.Now;
    public DateTime DataDeDevolucao
    {
        get
        {
            return DataDeEmprestimo.AddDays(Revista.Caixa.DiasDeEmprestimo);
        }
    }
    public StatusEmprestimo Status { get; set; }

    public Emprestimo(Amigo amigo, Revista revista)
    {
        Id = Convert
      .ToHexString(RandomNumberGenerator.GetBytes(20))
      .ToLower()
      .Substring(0, 7);

        Amigo = amigo;
        Revista = revista;
        DataDeEmprestimo = DateTime.Now;

    }

    public void Abrir()
    {
        DateTime previaDevolucao = DataDeDevolucao;
        Revista.Status = StatusRevista.Emprestada;
    }

    public void AtualizarStatus()
    {
        if (Status == StatusEmprestimo.Aberto && DataDeEmprestimo > DataDeDevolucao)
        {
            Status = StatusEmprestimo.Atrasado;
        }


    }

    public void Concluir()
    {
        if (Status == StatusEmprestimo.Aberto)
        {
            Status = StatusEmprestimo.Concluido;
            Revista.Status = StatusRevista.Disponivel;
        }
    }


    public string[] Validar()
    {
        string erros = string.Empty;

        if (Amigo == null)
            erros += "O campo 'Amigo' é obrigatório;";

        if (Revista == null)
            erros += "O campo 'Revista' é obrigatório;";
        else if (Revista.Status != StatusRevista.Emprestada)
            erros += "A revista selecionada não está disponível;";

        return erros.Split(";", StringSplitOptions.RemoveEmptyEntries);
    }

}
