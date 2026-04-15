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
        Caixa novaCaixa = ObterDadosCadastrais();

        repositorioCaixa.Cadastrar(novaCaixa);

        System.Console.WriteLine("---------------------------------------------");
        System.Console.WriteLine("O registro foi cadastrado com sucesso");
        System.Console.WriteLine("---------------------------------------------");
        Console.ReadLine();


    }
    public void Editar()
    {
        ObterCabecalho("editar caixa");

        Visualizar(deveApresentar: false);

        string? idSelecionado;

        do
        {
            System.Console.Write("Informe o id que do registro que deseja editar: ");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
            {
                break;
            }
        } while (true);

        Caixa novaCaixa = ObterDadosCadastrais();

        bool conseguiuEditar = repositorioCaixa.Editar(idSelecionado, novaCaixa);

        if (!conseguiuEditar)
        {
            System.Console.WriteLine("---------------------------------------------");
            System.Console.WriteLine("O registro foi não foi encontrado");
            System.Console.WriteLine("---------------------------------------------");
            Console.ReadLine();

        }

        System.Console.WriteLine("---------------------------------------------");
        System.Console.WriteLine("O registro foi atualizado com sucesso");
        System.Console.WriteLine("---------------------------------------------");
        Console.ReadLine();


    }

    public void Excluir()
    {
        ObterCabecalho("excluir caixa");

        Visualizar(deveApresentar: false);

        string? idSelecionado;

        do
        {
            System.Console.Write("Informe o id que do registro que deseja editar: ");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
            {
                break;
            }
        } while (true);

        bool conseguiuExcluir = repositorioCaixa.Excluir(idSelecionado);

        if (!conseguiuExcluir)
        {
            System.Console.WriteLine("---------------------------------------------");
            System.Console.WriteLine("O registro foi não foi encontrado");
            System.Console.WriteLine("---------------------------------------------");
            Console.ReadLine();

        }

        System.Console.WriteLine("---------------------------------------------");
        System.Console.WriteLine("O registro foi excluido com sucesso");
        System.Console.WriteLine("---------------------------------------------");
        Console.ReadLine();
    }

    public void Visualizar(bool deveApresentar)
    {
        if (deveApresentar)

            ObterCabecalho("visualizar caixas");

        Console.WriteLine(
           "{0, -7} | {1, -20} | {2, -10} | {3, -20}",
           "Id", "Etiqueta", "Cor", "Tempo de Empréstimo"
       );

        Caixa[]? caixas = repositorioCaixa.SelecionarTodos();

        for (int i = 0; i < caixas.Length; i++)
        {
            Caixa c = caixas[i];

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

    private void ObterCabecalho(string cabecalho)
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine(cabecalho);
        Console.WriteLine("---------------------------------");
    }

    private Caixa ObterDadosCadastrais()
    {
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

