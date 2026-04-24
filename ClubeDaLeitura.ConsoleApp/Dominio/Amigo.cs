
namespace ClubeDaLeitura.ConsoleApp.Dominio;

public class Amigo : EntidadeBase
{
    public string Nome { get; set; } = string.Empty;
    public string NomeResponsavel { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;

    public Amigo(string nome, string nomeResponsavel, string telefone)
    {
        Nome = nome;
        NomeResponsavel = nomeResponsavel;
        Telefone = telefone;
    }

    public override string[] Validar()
    {
        string erros = string.Empty;

        if (string.IsNullOrWhiteSpace(Nome))
        {
            erros += "O campo '/Nome/' é obrigatório;";
        }
        else if (Nome.Length < 2 || Nome.Length > 100)
        {
            erros += "O nome deve ter entre 2 e 100 caracteres;";
        }

        if (string.IsNullOrWhiteSpace(NomeResponsavel))
        {
            erros += "O campo '/Nome Do Responsavel/' é obrigatório;";
        }
        else if (NomeResponsavel.Length < 2 || NomeResponsavel.Length > 100)
        {
            erros += "O nome do responsavel deve ter entre 2 e 100 caracteres;";
        }

        int contadorDeDigitos = 0;
        bool contemLetraOuSimbolo = false;

        for (int i = 0; i < Telefone.Length; i++)
        {
            char caractereAtual = Telefone[i];

            if (char.IsDigit(caractereAtual))
            {
                contadorDeDigitos++;
            }
            else
            {
                contemLetraOuSimbolo = true;
                break;
            }
        }

        if (contadorDeDigitos < 10 || contadorDeDigitos > 11)
        {
            erros += "O telefone deve conter entre 10 e 11 digitos;";

        }
        if (contemLetraOuSimbolo)
        {
            erros += "O telefone deve conter apenas digitos;";

        }

        return erros.Split(";", StringSplitOptions.RemoveEmptyEntries);
    }

    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        Amigo amigoAtualizado = (Amigo)entidadeAtualizada;

        Nome = amigoAtualizado.Nome;
        NomeResponsavel = amigoAtualizado.NomeResponsavel;
        Telefone = amigoAtualizado.Telefone;
    }
}
