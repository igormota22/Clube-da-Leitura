
using ClubeDaLeitura.ConsoleApp.Apresentacao.Base;
using ClubeDaLeitura.ConsoleApp.Dominio;
using ClubeDaLeitura.ConsoleApp.Infraestrutura;

namespace ClubeDaLeitura.ConsoleApp.Apresentacao;

public class TelaPrincipal
{
    private TelaCaixa telaCaixa;
    private TelaRevista telaRevista;
    private TelaAmigo telaAmigo;
    private TelaEmprestimo telaEmprestimo;

    public TelaPrincipal(TelaCaixa telaCaixa, TelaRevista telaRevista,TelaAmigo telaAmigo,  TelaEmprestimo telaEmprestimo)    {

        this.telaCaixa = telaCaixa;
        this.telaRevista = telaRevista;
        this.telaAmigo = telaAmigo;
        this.telaEmprestimo = telaEmprestimo;
    }

    public ITela ApresentarMenuPrincipal()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Clube da Leitura");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Gerenciar caixas de revistas");
        Console.WriteLine("2 - Gerenciar revistas");
        Console.WriteLine("3 - Gerenciar amigos");
        Console.WriteLine("4 - Gerenciar empréstimos");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

        if (opcaoMenuPrincipal == "1")
        {
            return telaCaixa;
        }
        else if (opcaoMenuPrincipal == "2")
        {
            return telaRevista;
        }
        else if (opcaoMenuPrincipal == "3")
        {
            return telaAmigo;
        }
        else if (opcaoMenuPrincipal == "4")
        {
            return telaEmprestimo;
        }
        else
        {
            return null;
        }

    }
}
