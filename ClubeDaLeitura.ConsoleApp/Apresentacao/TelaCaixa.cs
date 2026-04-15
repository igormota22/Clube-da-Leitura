using System;
using ClubeDaLeitura.ConsoleApp.Dominio;
using ClubeDaLeitura.ConsoleApp.Infraestrutura;

namespace ClubeDaLeitura.ConsoleApp.Apresentacao;

public class TelaCaixa

{

    private RepositorioCaixa repositorioCaixa;

    public TelaCaixa(RepositorioCaixa repositorioCaixa)
    {
        this.repositorioCaixa = repositorioCaixa;
    }

    public string? ObterOpcaoMenu()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Caixas");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Cadastrar caixa");
        Console.WriteLine("2 - Editar caixa");
        Console.WriteLine("3 - Excluir caixa");
        Console.WriteLine("4 - Visualizar caixas");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        string? opcaoMenu = Console.ReadLine()?.ToUpper();

        return opcaoMenu;
    }

    public void Cadastrar()
    {
        ObterCabecalho("Cadastrar caixa");

        System.Console.Write("Informe a etiqueta da caixa: ");
        string? etiqueta = Console.ReadLine();

        Console.WriteLine("---------------------------------");
        System.Console.WriteLine("Selecione uma das cores validas");
        Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine("1 - Vermelho");
        Console.ForegroundColor = ConsoleColor.Green;
        System.Console.WriteLine("2 - Verde");
        Console.ForegroundColor = ConsoleColor.Blue;
        System.Console.WriteLine("3 - Azul");
        Console.ResetColor();
        System.Console.WriteLine("4 - Branco (padrão)");
        Console.WriteLine("---------------------------------");


        System.Console.Write("Informe a cor da caixa: ");
        string? Codigocor = Console.ReadLine();

        string cor;

        if (Codigocor == "1")
        {
            cor = "Vermelho";
        }
        else if (Codigocor == "2")
        {
            cor = "Verde";
        }
        else if (Codigocor == "3")
        {
            cor = "Azul";
        }
        else
        {
            cor = "Branco";
        }

        System.Console.WriteLine("Informe o tempo de emprestimo das revistas da caixa: ");
        int diasDeEmprestimo = Convert.ToInt32(Console.ReadLine());

        Caixa novaCaixa = new Caixa(etiqueta, cor, diasDeEmprestimo);

        repositorioCaixa.Cadastrar(novaCaixa);

        System.Console.WriteLine("---------------------------------------------");
        System.Console.WriteLine("O registro foi cadstrado com sucesso");
        System.Console.WriteLine("---------------------------------------------");
        Console.ReadLine();


    }
    public void Editar()
    {
        throw new NotImplementedException();
    }

    public void Excluir()
    {
        throw new NotImplementedException();
    }

    public void Visualizar()
    {
        throw new NotImplementedException();
    }

    public void ObterCabecalho(string cabecalho)
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine(cabecalho);
        Console.WriteLine("---------------------------------");
    }
}

