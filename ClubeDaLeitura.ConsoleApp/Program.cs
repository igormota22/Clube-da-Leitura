
using ClubeDaLeitura.ConsoleApp.Apresentacao;
using ClubeDaLeitura.ConsoleApp.Apresentacao.Base;
using ClubeDaLeitura.ConsoleApp.Infraestrutura;

static class Program
{

    static void Main(string[] args)
    {
        Executar();
    }

    private static void Executar()
    {
        RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
        RepositorioRevista repositorioRevista = new RepositorioRevista();
        RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
        RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();

        TelaPrincipal telaPrincipal = new TelaPrincipal(
            repositorioCaixa, repositorioRevista, repositorioAmigo, repositorioEmprestimo
        );

        while (true)
        {
            ITela telaSelecionada = telaPrincipal.ApresentarMenuPrincipal();

            if (telaSelecionada == null) break;

            while (true)
            {
                string opcao = telaSelecionada.ObterOpcaoMenu();

                if (opcao == "S") break;

                telaSelecionada.ExecutarOpcao(opcao);
            }
        }
    }

}