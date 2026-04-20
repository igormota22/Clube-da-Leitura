using System;
using ClubeDaLeitura.ConsoleApp.Dominio;
using ClubeDaLeitura.ConsoleApp.Infraestrutura;

namespace ClubeDaLeitura.ConsoleApp.Apresentacao;

public class TelaEmprestimo
{
    private RepositorioEmprestimo repositorioEmprestimo;
    private RepositorioAmigo repositorioAmigo;
    private RepositorioRevista repositorioRevista;

    public TelaEmprestimo(RepositorioEmprestimo repositorioEmprestimo, RepositorioAmigo repositorioAmigo, RepositorioRevista repositorioRevista)
    {
        this.repositorioEmprestimo = repositorioEmprestimo;
        this.repositorioAmigo = repositorioAmigo;
        this.repositorioRevista = repositorioRevista;
    }

    public string ObterOpcaoMenu()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Emprestimos");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Registrar Emprestimo");
        Console.WriteLine("2 - Registrar Devolução");
        Console.WriteLine("3 - Visualizar Emprestimos");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        string opcaoMenu = Console.ReadLine()?.ToUpper() ?? string.Empty;

        return opcaoMenu;
    }

    public void RegistrarEmprestimo()
    {

    }

    public void Visualizar()
    {

    }
}
