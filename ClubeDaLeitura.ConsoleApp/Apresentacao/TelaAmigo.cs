using System;
using ClubeDaLeitura.ConsoleApp.Dominio;
using ClubeDaLeitura.ConsoleApp.Infraestrutura;

namespace ClubeDaLeitura.ConsoleApp.Apresentacao;

public class TelaAmigo : TelaBase
{
    private RepositorioAmigo repositorioAmigo;
    private RepositorioEmprestimo repositorioEmprestimo;

    public TelaAmigo(RepositorioAmigo repositorioAmigo, RepositorioEmprestimo repositorioEmprestimo) : base("Amigo", repositorioAmigo)
    {
        this.repositorioAmigo = repositorioAmigo;
        this.repositorioEmprestimo = repositorioEmprestimo;
    }

    public override void Visualizar(bool deveApresentar)
    {
        if (deveApresentar)

            ObterCabecalho("visualizar amigos");

        Console.WriteLine(
           "{0, -7} | {1, -15} | {2, -15} | {3, -13}",
           "Id", "Nome", "Responsavel", "Telefone"
       );

        EntidadeBase[]? amigos = repositorioAmigo.SelecionarTodos();

        for (int i = 0; i < amigos.Length; i++)
        {
            Amigo? a = (Amigo?)amigos[i];

            if (a == null)
            {
                continue;

            }
            Console.WriteLine(
    "{0, -7} | {1, -15} | {2, -15} | {3, -13}",
    a.Id, a.Nome, a.NomeResponsavel, a.Telefone

     );

            System.Console.WriteLine("------------------------------------");
        }

        if (deveApresentar)
        {


            System.Console.WriteLine("Pressione ENTER para continuar");
            Console.ReadLine();
        }
    }

    protected override string ExibirMensagemDeValorRepetido(EntidadeBase entidade)
    {
        if (repositorioAmigo.VerificarValoresIguais(entidade))
        {
            return "Ja existe uma pessoa com este nome e telefone";
        }
        return null;
    }

    protected override EntidadeBase ObterDadosCadastrais()
    {
        System.Console.Write("Informe o nome: ");
        string nome = Console.ReadLine() ?? string.Empty;

        System.Console.Write("Informe o nome do responsavel: ");
        string NomeResponsavel = Console.ReadLine() ?? string.Empty;

        System.Console.Write("Informe o telefone: ");
        string telefone = Console.ReadLine() ?? string.Empty;

        Amigo novoAmigo = new Amigo(nome, NomeResponsavel, telefone);

        return novoAmigo;
    }

    protected override string ValidarExclusao(EntidadeBase entidade)
    {
        if (repositorioEmprestimo.AmigoTemEmprestimoAtivo(entidade.Id))
            return "Não é possível excluir. Essa pessoa tem um emprestimo em aberto!";

        return null;
    }
}
