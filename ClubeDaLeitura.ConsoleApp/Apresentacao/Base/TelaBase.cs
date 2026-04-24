using System;
using ClubeDaLeitura.ConsoleApp.Apresentacao.Base;
using ClubeDaLeitura.ConsoleApp.Dominio;
using ClubeDaLeitura.ConsoleApp.Infraestrutura;

namespace ClubeDaLeitura.ConsoleApp.Apresentacao;

public abstract class TelaBase : ITela
{

    private string nomeEntidade = string.Empty;
    private RepositorioBase repositorio;

    protected TelaBase(string nomeEntidade, RepositorioBase repositorio)
    {
        this.nomeEntidade = nomeEntidade;
        this.repositorio = repositorio;
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

    public void Cadastrar()
    {
        ObterCabecalho($"Cadastrar {nomeEntidade}");
        EntidadeBase novaEntidade = ObterDadosCadastrais();
        string repetido = ExibirMensagemDeValorRepetido(novaEntidade);

        if (repetido != null)
        {
            ExibirMensagem(repetido);

            Cadastrar();
            return;
        }

        string[] erros = novaEntidade.Validar();

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

        repositorio.Cadastrar(novaEntidade);

        ExibirMensagem("O registro foi cadastrado com sucesso");
    }

    public void Editar()
    {
        ObterCabecalho($"editar {nomeEntidade}");

        Visualizar(deveApresentar: false);

        string? idSelecionado;

        do
        {
            System.Console.Write("Informe o id que do registro que deseja editar ou pressione 'S' para sair: ");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
            {
                break;
            }
            if (idSelecionado.ToUpper() == "S")
            {
                return;
            }
        } while (true);

        EntidadeBase novaEntidade = ObterDadosCadastrais();

        string[] erros = novaEntidade.Validar();

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

        bool conseguiuEditar = repositorio.Editar(idSelecionado, novaEntidade);

        if (!conseguiuEditar)
        {
            ExibirMensagem("O registro não foi encontrado");
            return;

        }

        ExibirMensagem("O registro foi atualizado com sucesso");
    }

    public virtual void Excluir()
    {
        ObterCabecalho($"excluir {nomeEntidade}");

        Visualizar(deveApresentar: false);

        string? idSelecionado;

        do
        {
            System.Console.Write("Informe o id que do registro que deseja excluir ou pressione 'S' para sair : ");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
            {
                break;
            }

            if (idSelecionado.ToUpper() == "S")
            {
                return;
            }
        } while (true);

        EntidadeBase entidade = repositorio.SelecionarPorId(idSelecionado);

        string erro = ValidarExclusao(entidade);
        if (erro != null)
        {
            ExibirMensagem(erro);

            Excluir();
            return;
        }



        bool conseguiuExcluir = repositorio.Excluir(idSelecionado);

        if (!conseguiuExcluir)
        {
            ExibirMensagem("O registro não foi encontrado");
            return;

        }

        ExibirMensagem("O registro foi excluido com sucesso");
    }



    public abstract void Visualizar(bool deveApresentar);

    protected void ObterCabecalho(string cabecalho)
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine(cabecalho);
        Console.WriteLine("---------------------------------");
    }

    protected abstract EntidadeBase ObterDadosCadastrais();

    protected virtual string ValidarExclusao(EntidadeBase entidade)
    {
        return null;
    }

    protected virtual string ExibirMensagemDeValorRepetido(EntidadeBase entidade)
    {
        return null;
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
