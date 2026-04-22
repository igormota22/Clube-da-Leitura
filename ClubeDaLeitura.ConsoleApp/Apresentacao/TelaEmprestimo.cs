using System;
using ClubeDaLeitura.ConsoleApp.Dominio;
using ClubeDaLeitura.ConsoleApp.Infraestrutura;

namespace ClubeDaLeitura.ConsoleApp.Apresentacao;

public class TelaEmprestimo
{
    private RepositorioEmprestimo repositorioEmprestimo;
    private RepositorioAmigo repositorioAmigo;
    private RepositorioRevista repositorioRevista;
    private TelaAmigo telaAmigo;
    private TelaRevista telaRevista;

    public TelaEmprestimo(RepositorioEmprestimo repositorioEmprestimo, RepositorioAmigo repositorioAmigo, RepositorioRevista repositorioRevista, TelaAmigo telaAmigo, TelaRevista telaRevista)
    {
        this.repositorioEmprestimo = repositorioEmprestimo;
        this.repositorioAmigo = repositorioAmigo;
        this.repositorioRevista = repositorioRevista;
        this.telaAmigo = telaAmigo;
        this.telaRevista = telaRevista;
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

    public void Registrar()
    {
        ObterCabecalho("Registrar Emprestimo");

        telaAmigo.Visualizar(false);

        string? idSelecionado;

        do
        {
            System.Console.Write("Informe o id da pessoa que deseja fazer o emprestimo: ");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
            {
                break;
            }
        } while (true);

        System.Console.WriteLine();

        Amigo amigoSelecionado = (Amigo)repositorioAmigo.SelecionarPorId(idSelecionado);

        if (amigoSelecionado == null)
        {
            ExibirMensagem("Registro não foi encontrado");
            return;
        }

        if (repositorioEmprestimo.AmigoTemEmprestimoAtivo(idSelecionado))
        {
            ExibirMensagem("Essa pessoa ja tem um emprestimo ativo");
            return;
        }

        telaRevista.Visualizar(false);

        string? idRevistaSelecionado;

        do
        {
            System.Console.Write("Informe o id da revista que deseja emprestar: ");
            idRevistaSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
            {
                break;
            }
        } while (true);


        Revista revistaSelecionada = (Revista)repositorioRevista.SelecionarPorId(idRevistaSelecionado);

        if (revistaSelecionada == null)
        {
            ExibirMensagem("Registro não encontrado");
        }

        if (revistaSelecionada.Status != StatusRevista.Disponivel)
        {
            ExibirMensagem("Essa revista não esta disponivel para emprestimo");
            return;
        }

        Emprestimo novoEmprestimo = new Emprestimo(amigoSelecionado, revistaSelecionada);
        repositorioEmprestimo.Cadastrar(novoEmprestimo);

        ExibirMensagem("Emprestimo efetuado");


    }

    public void Devolver()
    {
        ObterCabecalho("Devolução");

        Visualizar();

        string? idSelecionado;

        do
        {
            System.Console.Write("Informe o id do emprestimo que deseja efetuar a devolução: ");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
            {
                break;
            }
        } while (true);

        Emprestimo emprestimoSelecionado = repositorioEmprestimo.SelecionarPorId(idSelecionado);

        if (emprestimoSelecionado == null)
        {
            ExibirMensagem("Registro não encontrado");
            return;
        }

        if (emprestimoSelecionado.Status == StatusEmprestimo.Concluido)
        {
            ExibirMensagem("Ja foi feita a devolução desse emprestimo");
            return;
        }

        System.Console.Write("Deseja mesmo efetuar a devolução? (S/n)");
        string? opcaoDevolucao = Console.ReadLine()?.ToUpper();

        if (opcaoDevolucao != "S")
        {
            return;
        }

        emprestimoSelecionado.Concluir();
        ExibirMensagem("Devolução registrada com sucesso");
    }

    public void Visualizar()
    {
        ObterCabecalho("Visualizar Emprestimos");

        Console.WriteLine(
   "{0, -7} | {1, -20} | {2, -25} | {3, -12} | {4, -12} | {5, -10}",
   "Id", "Amigo", "Revista", "Abertura", "Devolução", "Status"
);
        Console.WriteLine("--------------------------------------------------------------------------------------");

        Emprestimo[] registros = repositorioEmprestimo.SelecionarTodos();

        int qtdAbertos = 0;
        int qtdAtrasados = 0;
        int qtdConcluidos = 0;

        for (int i = 0; i < registros.Length; i++)
        {
            if (registros[i] == null) continue;

            Emprestimo e = registros[i];
            e.AtualizarStatus();

            Console.Write(
                "{0, -7} | {1, -20} | {2, -25} | {3, -12} | {4, -12} | ",
                e.Id,
                e.Amigo.Nome,
                e.Revista.Titulo,
                e.DataDeEmprestimo.ToString("dd/MM/yyyy"),
                e.DataDeDevolucao.ToString("dd/MM/yyyy")
            );

            if (e.Status == StatusEmprestimo.Atrasado)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                qtdAtrasados++;
            }
            else if (e.Status == StatusEmprestimo.Concluido)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                qtdConcluidos++;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                qtdAbertos++;
            }

            Console.WriteLine("{0, -10}", e.Status);
            Console.ResetColor();
        }

        Console.WriteLine("--------------------------------------------------------------------------------------");
        Console.WriteLine($"Total: Abertos: {qtdAbertos} | Atrasados: {qtdAtrasados} | Concluídos: {qtdConcluidos}");
        Console.WriteLine("------------------------------------");
        Console.WriteLine("Pressione ENTER para continuar");
        Console.ReadLine();
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
