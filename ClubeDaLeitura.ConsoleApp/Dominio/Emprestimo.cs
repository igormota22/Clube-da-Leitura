using System;
using System.Security.Cryptography;

namespace ClubeDaLeitura.ConsoleApp.Dominio;

public class Emprestimo
{
    public string Id { get; set; } = string.Empty;
    public Amigo Amigo { get; set; }
    public Revista Revista { get; set; }
    public DateTime DataDeEmprestimo { get; set; } = DateTime.Now;
    public DateTime DataDeDevolucao { get; set; }
    public string Status { get; set; }

    public Emprestimo(Amigo amigo, Revista revista)
    {
        Id = Convert
      .ToHexString(RandomNumberGenerator.GetBytes(20))
      .ToLower()
      .Substring(0, 7);

        Amigo = amigo;
        Revista = revista;
        DataDeEmprestimo = DateTime.Now;
        DataDeDevolucao = DataDeEmprestimo.AddDays(revista.Caixa.DiasDeEmprestimo);
        Status = "Aberto";
    }

    public void AtualizarStatus()
    {
        if (Status == "Aberto" && DataDeEmprestimo > DataDeDevolucao)
        {
            Status = "Atrasado";
        }


    }

    public void Concluir()
    {
        if (Status == "Aberto" || Status == "Atrasado")
        {
            Status = "Concluído";
            Revista.Status = "Disponível";
        }
    }


    public string[] Validar()
    {
        string erros = string.Empty;

        if (Amigo == null)
            erros += "O campo 'Amigo' é obrigatório;";

        if (Revista == null)
            erros += "O campo 'Revista' é obrigatório;";
        else if (Revista.Status != "Disponível")
            erros += "A revista selecionada não está disponível;";

        return erros.Split(";", StringSplitOptions.RemoveEmptyEntries);
    }

}
