using System;

namespace ClubeDaLeitura.ConsoleApp.Apresentacao;

public abstract class TelaBase
{

    private string nomeEntidade = string.Empty;

    protected TelaBase(string nomeEntidade)
    {
        this.nomeEntidade = nomeEntidade;
    }

     public string? ObterOpcaoMenu()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"Gestão de {nomeEntidade}s");
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"1 - Cadastrar {nomeEntidade}");
        Console.WriteLine($"2 - Editar {nomeEntidade}");
        Console.WriteLine($"3 - Excluir {nomeEntidade}");
        Console.WriteLine($"4 - Visualizar {nomeEntidade}s");
        Console.WriteLine($"S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        string? opcaoMenu = Console.ReadLine()?.ToUpper();

        return opcaoMenu;
    }

    protected void ObterCabecalho(string cabecalho)
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine(cabecalho);
        Console.WriteLine("---------------------------------");
    }

    protected void ExibirMensagem(string mensagem)
    {
        System.Console.WriteLine("--------------------------------");
        System.Console.WriteLine(mensagem);
        System.Console.WriteLine("--------------------------------");
        System.Console.WriteLine("Digite ENTER para continuar");
        Console.ReadLine();
    }
}
