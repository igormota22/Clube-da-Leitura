
using ClubeDaLeitura.ConsoleApp.Apresentacao;
using ClubeDaLeitura.ConsoleApp.Infraestrutura;

RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
RepositorioRevista repositorioRevista = new RepositorioRevista();
RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();

TelaPrincipal telaPrincipal = new TelaPrincipal(repositorioCaixa, repositorioRevista, repositorioAmigo, repositorioEmprestimo);

while (true)
{
    TelaBase telaSelecionada = telaPrincipal.ApresentarMenuPrincipal();

    if (telaSelecionada == null)
    {
        Console.Clear();
        break;
    }

    while (true)
    {
        string? opcaoMenuInterno = telaSelecionada.ObterOpcaoMenu();

        if (opcaoMenuInterno == "S")
        {
            Console.Clear();
            break;
        }

        else if (opcaoMenuInterno == "1")
        {
            telaSelecionada.Cadastrar();
        }
        else if (opcaoMenuInterno == "2")
        {
            telaSelecionada.Editar();
        }
        else if (opcaoMenuInterno == "3")
        {
            telaSelecionada.Excluir();
        }
        else if (opcaoMenuInterno == "4")
        {
            telaSelecionada.Visualizar(deveApresentar: true);
        }

        /*
        else if (opcaoMenuPrincipal == "4")
        {
            opcaoMenuInterno = telaEmprestimo.ObterOpcaoMenu();

            if (opcaoMenuInterno == "S")
            {
                Console.Clear();
                break;
            }

            else if (opcaoMenuInterno == "1")
            {
                telaEmprestimo.Registrar();
            }
            else if (opcaoMenuInterno == "2")
            {
                telaEmprestimo.Devolver();
            }
            else if (opcaoMenuInterno == "3")
            {
                telaEmprestimo.Visualizar();
            }
            */
    }
}

