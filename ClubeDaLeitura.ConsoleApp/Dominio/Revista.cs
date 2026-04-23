

namespace ClubeDaLeitura.ConsoleApp.Dominio;

public class Revista : EntidadeBase
{
    public string Titulo { get; set; }
    public int NumeroDeEdicao { get; set; }
    public int AnoDePublicacao { get; set; }
    public Caixa Caixa { get; set; }
    public StatusRevista Status { get; set; }

    public Revista(string titulo, int numeroDeEdicao, int anoDePublicacao, Caixa caixa)
    {
        Titulo = titulo;
        NumeroDeEdicao = numeroDeEdicao;
        AnoDePublicacao = anoDePublicacao;
        Caixa = caixa;
    }

    public override string[] Validar()
    {
        string erros = string.Empty;

        if (string.IsNullOrWhiteSpace(Titulo))
        {
            erros += "O campo '/Titulo/' é obrigatorio;";
        }
        else if (Titulo.Length < 2 || Titulo.Length > 100)
        {
            erros += "O campo '/Titulo/' deve ter entre 2 e 100 caracteres;";

        }


        if (NumeroDeEdicao < 0)
        {
            erros += "Informe um numero maior ou igual a 0;";

        }

        int anoValido = DateTime.Now.Year;

        if (AnoDePublicacao < 1 || AnoDePublicacao > anoValido)
        {
            erros += "Informe uma data valida;";

        }

        if (Caixa == null)
        {
            erros += "O campo '/Caixa/' é obrigatorio;";

        }

        return erros.Split(";", StringSplitOptions.RemoveEmptyEntries);
    }

    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        Revista revistaAtualizada = (Revista)entidadeAtualizada;

        Titulo = revistaAtualizada.Titulo;
        NumeroDeEdicao = revistaAtualizada.NumeroDeEdicao;
        AnoDePublicacao = revistaAtualizada.AnoDePublicacao;
        Caixa = revistaAtualizada.Caixa;
    }
}
