using System;
using ClubeDaLeitura.ConsoleApp.Dominio;
using ClubeDaLeitura.ConsoleApp.Infraestrutura;

namespace ClubeDaLeitura.ConsoleApp.Apresentacao;

public class TelaRevista
{
    private RepositorioRevista repositorioRevista;
    private RepositorioCaixa repositorioCaixa;

    public TelaRevista(RepositorioRevista repositorioRevista, RepositorioCaixa repositorioCaixa)
    {
        this.repositorioRevista = repositorioRevista;
        this.repositorioCaixa = repositorioCaixa;
    }

    public string ObterOpcaoMenu()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Revistas");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Cadastrar revista");
        Console.WriteLine("2 - Editar revista");
        Console.WriteLine("3 - Excluir revista");
        Console.WriteLine("4 - Visualizar revista");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        string? opcaoMenu = Console.ReadLine()?.ToUpper();

        return opcaoMenu;

    }

    public void Cadastrar()
    {
        ObterCabecalho("cadastrar revista");
        Revista novaRevista = ObterDadosCadastrais();

        string[] erros = novaRevista.Verificar();

        System.Console.WriteLine("-----------------------------------");

        if (erros.Length > 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            for (int i = 0; i < erros.Length; i++)
            {
                string erro = erros[i];

                Console.WriteLine(erro);
            }


            Console.ResetColor();
            System.Console.WriteLine("-----------------------------------");
            System.Console.WriteLine("Digite ENTER para continuar");
            Console.ReadLine();

            Cadastrar();
            return;

        }

        repositorioRevista.Cadastrar(novaRevista);

        ExibirMensagem("O registro foi cadastrado com sucesso");
    }

    public void Editar()
    {
        ObterCabecalho("editar revista");

        Visualizar(deveApresentar: false);

        string? idSelecionado;

        do
        {
            System.Console.Write("Informe o id  do registro que deseja editar: ");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
            {
                break;
            }
        } while (true);

        Revista novaRevista = ObterDadosCadastrais();

        string[] erros = novaRevista.Verificar();

        System.Console.WriteLine("-----------------------------------");

        if (erros.Length > 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            for (int i = 0; i < erros.Length; i++)
            {
                string erro = erros[i];

                Console.WriteLine(erro);
            }


            Console.ResetColor();
            System.Console.WriteLine("-----------------------------------");
            System.Console.WriteLine("Digite ENTER para continuar");
            Console.ReadLine();

            Editar();
            return;

        }

        bool conseguiuEditar = repositorioRevista.Editar(idSelecionado, novaRevista);

        if (!conseguiuEditar)
        {
            ExibirMensagem("O registro não foi encontrado");
            return;

        }

        ExibirMensagem("O registro foi atualizado com sucesso");
    }

    public void Excluir()
    {
        ObterCabecalho("excluir revista");

        Visualizar(deveApresentar: false);

        string? idSelecionado;

        do
        {
            System.Console.Write("Informe o id que do registro que deseja excluir: ");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
            {
                break;
            }
        } while (true);

        bool conseguiuExcluir = repositorioRevista.Excluir(idSelecionado);

        if (!conseguiuExcluir)
        {
            ExibirMensagem("O registro não foi encontrado");
            return;

        }

        ExibirMensagem("O registro foi excluido com sucesso");
    }

    public void Visualizar(bool deveApresentar)
    {
        if (deveApresentar)
            ObterCabecalho("visualizar revistas");

        Console.WriteLine(
           "{0, -7} | {1, -25} | {2, -6} | {3, -4} | {4, -15}",
           "Id", "Título", "Edição", "Ano", "Caixa"
       );

        Revista?[] revistas = repositorioRevista.SelecionarTodos();

        for (int i = 0; i < revistas.Length; i++)
        {
            Revista? r = revistas[i];

            if (r == null)
                continue;

            Console.Write("{0, -7} | ", r.Id);
            Console.Write("{0, -25} | ", r.Titulo);
            Console.Write("{0, -6} | ", r.NumeroDeEdicao);
            Console.Write("{0, -4} | ", r.AnoDePublicacao);

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

    private void ObterCabecalho(string cabecalho)
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine(cabecalho);
        Console.WriteLine("---------------------------------");
    }

    private Revista ObterDadosCadastrais()
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


        Caixa caixaSelecionada = repositorioCaixa.SelecionarPorId(idCaixa);

        return new Revista(titulo, numeroDeEdicao, anoDePublicacao, caixaSelecionada);
    }

    private void VisualizarCaixas()
    {
        Console.WriteLine("---------------------------------");


        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -10} | {3, -20}",
            "Id", "Etiqueta", "Cor", "Tempo de Empréstimo"
        );

        Caixa?[] caixas = repositorioCaixa.SelecionarTodos();

        for (int i = 0; i < caixas.Length; i++)
        {
            Caixa? c = caixas[i];

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

    private void ExibirMensagem(string mensagem)
    {
        System.Console.WriteLine("--------------------------------");
        System.Console.WriteLine(mensagem);
        System.Console.WriteLine("--------------------------------");
        System.Console.WriteLine("Digite ENTER para continuar");
        Console.ReadLine();
    }



}
