
using ClubeDaLeitura.ConsoleApp.Apresentacao;
using ClubeDaLeitura.ConsoleApp.Apresentacao.Base;
using ClubeDaLeitura.ConsoleApp.Dominio;
using ClubeDaLeitura.ConsoleApp.Infraestrutura;

static class Program
{

    static void Main(string[] args)
    {
        Executar();
    }

    private static void Executar()
    {
        TelaPrincipal telaPrincipal = FabricaTela.CriarTelaPrincipal();
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