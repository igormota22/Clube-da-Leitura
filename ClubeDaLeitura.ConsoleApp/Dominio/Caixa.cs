using System;
using System.Dynamic;
using System.Security.Cryptography;

namespace ClubeDaLeitura.ConsoleApp.Dominio;

public class Caixa
{
    public string Id { get; set; } = string.Empty;
    public string Etiqueta { get; set; } = string.Empty;
    public string Cor { get; set; } = string.Empty;
    public int DiasDeEmprestimo { get; set; } = 7;

    public Caixa(string etiqueta, string cor, int diasDeEmprestimo)
    {
        Id = Convert
        .ToHexString(RandomNumberGenerator.GetBytes(20))
        .ToLower()
        .Substring(0, 7);

        Etiqueta = etiqueta;
        Cor = cor;
        DiasDeEmprestimo = diasDeEmprestimo;
    }

    public Caixa AtualizarDados(Caixa caixaAtualizada)
    {
        Etiqueta = caixaAtualizada.Etiqueta;
        Cor = caixaAtualizada.Cor;
        DiasDeEmprestimo = caixaAtualizada.DiasDeEmprestimo;

        return caixaAtualizada;

    }

    public string[] Validar()
    {
        string erros = string.Empty;

        if (string.IsNullOrWhiteSpace(Etiqueta))
        {
            erros += "O campo '/Etiqueta/' é obrigatório;";
        }
        else if (Etiqueta.Length > 50)
        {
            erros += "O campo '/Etiqueta/' deve ter no maximo 50 caracteres;";
        }

        if (DiasDeEmprestimo < 1)
        {
            erros += "O campo '/Dias De Emprestimo/' deve ser maior que 0;";
        }

        return erros.Split(";", StringSplitOptions.RemoveEmptyEntries);
    }
}
