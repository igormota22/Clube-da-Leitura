using System;
using ClubeDaLeitura.ConsoleApp.Dominio;
using ClubeDaLeitura.ConsoleApp.Infraestrutura;

namespace ClubeDaLeitura.ConsoleApp.Apresentacao;

public class TelaCaixa : TelaBase

{
    private RepositorioCaixa repositorioCaixa;

    public TelaCaixa(RepositorioCaixa repositorioCaixa) : base("Caixa", repositorioCaixa)
    {
        this.repositorioCaixa = repositorioCaixa;
    }



    public override void Visualizar(bool deveApresentar)
    {
        if (deveApresentar)

            ObterCabecalho("visualizar caixas");

        Console.WriteLine(
           "{0, -7} | {1, -20} | {2, -10} | {3, -20}",
           "Id", "Etiqueta", "Cor", "Tempo de Empréstimo"
       );

        EntidadeBase[]? caixas = repositorioCaixa.SelecionarTodos();

        for (int i = 0; i < caixas.Length; i++)
        {
            Caixa c = (Caixa)caixas[i];

            if (c == null)
            {
                continue;

            }
            Console.WriteLine(
    "{0, -7} | {1, -20} | {2, -10} | {3, -20}",
    c.Id, c.Etiqueta, c.Cor, c.DiasDeEmprestimo

     );

            System.Console.WriteLine("------------------------------------");
        }

        if (deveApresentar)
        {


            System.Console.WriteLine("Pressione ENTER para continuar");
            Console.ReadLine();
        }


    }

    protected override EntidadeBase ObterDadosCadastrais()
    {
        System.Console.Write("Informe a etiqueta da caixa: ");
        string? etiqueta = Console.ReadLine();

        Console.WriteLine("---------------------------------");
        System.Console.WriteLine("Selecione uma das cores validas");
        Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine("1 - Vermelha");
        Console.ForegroundColor = ConsoleColor.Green;
        System.Console.WriteLine("2 - Verde");
        Console.ForegroundColor = ConsoleColor.Blue;
        System.Console.WriteLine("3 - Azul");
        Console.ResetColor();
        System.Console.WriteLine("4 - Branco (padrão)");
        Console.WriteLine("---------------------------------");


        System.Console.Write("Informe a cor da caixa: ");
        string? codigoCor = Console.ReadLine();

        string cor;

        if (codigoCor == "1")
        {
            cor = "Vermelho";
        }
        else if (codigoCor == "2")
        {
            cor = "Verde";
        }
        else if (codigoCor == "3")
        {
            cor = "Azul";
        }
        else
        {
            cor = "Branco";
        }

        System.Console.Write("Informe o tempo de emprestimo das revistas da caixa: ");
        int diasDeEmprestimo = Convert.ToInt32(Console.ReadLine());

        Caixa novaCaixa = new Caixa(etiqueta, cor, diasDeEmprestimo);

        return novaCaixa;
    }


}

