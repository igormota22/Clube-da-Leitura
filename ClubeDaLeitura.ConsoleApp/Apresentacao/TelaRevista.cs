using System;
using ClubeDaLeitura.ConsoleApp.Dominio;
using ClubeDaLeitura.ConsoleApp.Infraestrutura;

namespace ClubeDaLeitura.ConsoleApp.Apresentacao;

public class TelaRevista : TelaBase
{
    private RepositorioRevista repositorioRevista;
    private RepositorioCaixa repositorioCaixa;

    public TelaRevista(RepositorioRevista repositorioRevista, RepositorioCaixa repositorioCaixa) : base("Revista", repositorioRevista)
    {
        this.repositorioRevista = repositorioRevista;
        this.repositorioCaixa = repositorioCaixa;
    }

    public override void Visualizar(bool deveApresentar)
    {
        if (deveApresentar)
            ObterCabecalho("visualizar revistas");

        Console.WriteLine(
      "{0, -7} | {1, -25} | {2, -6} | {3, -4} | {4, -12} | {5, -15}",
      "Id", "Título", "Edição", "Ano", "Status", "Caixa"
  );

        EntidadeBase?[] revistas = repositorioRevista.SelecionarTodos();

        for (int i = 0; i < revistas.Length; i++)
        {
            Revista? r = (Revista?)revistas[i];

            if (r == null)
                continue;

            Console.Write("{0, -7} | ", r.Id);
            Console.Write("{0, -25} | ", r.Titulo);
            Console.Write("{0, -6} | ", r.NumeroDeEdicao);
            Console.Write("{0, -4} | ", r.AnoDePublicacao);
            Console.Write("{0, -6} |", r.Status);

            string corSelecionada = r.Caixa.Cor;

            if (corSelecionada == "Vermelha")
                Console.ForegroundColor = ConsoleColor.Red;

            else if (corSelecionada == "Verde")
                Console.ForegroundColor = ConsoleColor.Green;

            else if (corSelecionada == "Azul")
                Console.ForegroundColor = ConsoleColor.Blue;

            Console.Write("{0, -10}", r.Caixa.Cor);

            Console.ResetColor();
            Console.WriteLine();

        }

        if (deveApresentar)
        {
            System.Console.WriteLine("Pressione ENTER para continuar");
            Console.ReadLine();
        }
    }

    protected override EntidadeBase ObterDadosCadastrais()
    {
        System.Console.Write("Digite o titulo da revista: ");
        string titulo = Console.ReadLine();

        System.Console.Write("Digite a edição: ");
        int numeroDeEdicao = Convert.ToInt32(Console.ReadLine());

        System.Console.Write("Digite o ano de publicação: ");
        int anoDePublicacao = Convert.ToInt32(Console.ReadLine());

        VisualizarCaixas();

        string idCaixa;

        do
        {
            System.Console.Write("Informe o id da caixa que deseja guardar a revista: ");
            idCaixa = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idCaixa) && idCaixa.Length == 7)
            {
                break;
            }
        } while (true);


        Caixa caixaSelecionada = (Caixa)repositorioCaixa.SelecionarPorId(idCaixa);

        return new Revista(titulo, numeroDeEdicao, anoDePublicacao, caixaSelecionada);
    }

    private void VisualizarCaixas()
    {
        Console.WriteLine("---------------------------------");


        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -10} | {3, -20}",
            "Id", "Etiqueta", "Cor", "Tempo de Empréstimo"
        );

        EntidadeBase?[] caixas = repositorioCaixa.SelecionarTodos();

        for (int i = 0; i < caixas.Length; i++)
        {
            Caixa? c = (Caixa?)caixas[i];

            if (c == null)
                continue;

            string corSelecionada = c.Cor;

            if (corSelecionada == "Vermelha")
                Console.ForegroundColor = ConsoleColor.Red;

            else if (corSelecionada == "Verde")
                Console.ForegroundColor = ConsoleColor.Green;

            else if (corSelecionada == "Azul")
                Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -10} | {3, -20}",
                c.Id, c.Etiqueta, c.Cor, c.DiasDeEmprestimo
            );

            Console.ResetColor();
        }

        Console.WriteLine("---------------------------------");
    }
}
