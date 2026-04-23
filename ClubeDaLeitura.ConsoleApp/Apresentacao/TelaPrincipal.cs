using System;
using ClubeDaLeitura.ConsoleApp.Apresentacao.Base;
using ClubeDaLeitura.ConsoleApp.Dominio;
using ClubeDaLeitura.ConsoleApp.Infraestrutura;

namespace ClubeDaLeitura.ConsoleApp.Apresentacao;

public class TelaPrincipal
{
    private RepositorioCaixa repositorioCaixa;
    private RepositorioRevista repositorioRevista;
    private RepositorioAmigo repositorioAmigo;
    private RepositorioEmprestimo repositorioEmprestimo;

    private TelaCaixa telaCaixa;
    private TelaRevista telaRevista;
    private TelaAmigo telaAmigo;
    private TelaEmprestimo telaEmprestimo;

    public TelaPrincipal(RepositorioCaixa repositorioCaixa, RepositorioRevista repositorioRevista,
    RepositorioAmigo repositorioAmigo, RepositorioEmprestimo repositorioEmprestimo)
    {
        this.repositorioCaixa = repositorioCaixa;
        this.repositorioRevista = repositorioRevista;
        this.repositorioAmigo = repositorioAmigo;
        this.repositorioEmprestimo = repositorioEmprestimo;

        Caixa caixa = new Caixa("lancamento", "Vermelha", 3);
        repositorioCaixa.Cadastrar(caixa);

        Revista revista = new Revista("batman", 55, 1947, caixa);
        repositorioRevista.Cadastrar(revista);

        Amigo amigo = new Amigo("Igor", "Rafaela", "4999089867");
        repositorioAmigo.Cadastrar(amigo);

        Emprestimo emprestimo = new Emprestimo(amigo,revista);
        emprestimo.Abrir();
        repositorioEmprestimo.Cadastrar(emprestimo);

        telaCaixa = new TelaCaixa(repositorioCaixa, repositorioRevista);
        telaRevista = new TelaRevista(repositorioRevista, repositorioCaixa);
        telaAmigo = new TelaAmigo(repositorioAmigo);
        telaEmprestimo = new TelaEmprestimo(repositorioEmprestimo, repositorioAmigo, repositorioRevista, telaAmigo, telaRevista);
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
