
using ClubeDaLeitura.ConsoleApp.Apresentacao;
using ClubeDaLeitura.ConsoleApp.Dominio;
using ClubeDaLeitura.ConsoleApp.Infraestrutura;

RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
RepositorioRevista repositorioRevista = new RepositorioRevista();
RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();


TelaCaixa telaCaixa = new TelaCaixa(repositorioCaixa);
TelaRevista telaRevista = new TelaRevista(repositorioRevista, repositorioCaixa);
TelaAmigo telaAmigo = new TelaAmigo(repositorioAmigo);
TelaEmprestimo telaEmprestimo = new TelaEmprestimo(repositorioEmprestimo, repositorioAmigo, repositorioRevista, telaAmigo, telaRevista);

Caixa caixa = new Caixa("lancamento", "Vermelha", 3);
repositorioCaixa.Cadastrar(caixa);

Revista revista = new Revista("batman", 55, 1947, caixa);
repositorioRevista.Cadastrar(revista);

Amigo amigo = new Amigo("Igor", "Rafaela", "4999089867");
repositorioAmigo.Cadastrar(amigo);

while (true)
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

    if (opcaoMenuPrincipal == "S")
    {
        Console.Clear();
        break;
    }

    while (true)
    {
        string? opcaoMenuInterno = string.Empty;

        if (opcaoMenuPrincipal == "1")
        {
            opcaoMenuInterno = telaCaixa.ObterOpcaoMenu();

            if (opcaoMenuInterno == "S")
            {
                Console.Clear();
                break;
            }

            else if (opcaoMenuInterno == "1")
            {
                telaCaixa.Cadastrar();
            }
            else if (opcaoMenuInterno == "2")
            {
                telaCaixa.Editar();
            }
            else if (opcaoMenuInterno == "3")
            {
                telaCaixa.Excluir();
            }
            else if (opcaoMenuInterno == "4")
            {
                telaCaixa.Visualizar(deveApresentar: true);
            }
        }

        else if (opcaoMenuPrincipal == "2")
        {
            opcaoMenuInterno = telaRevista.ObterOpcaoMenu();

            if (opcaoMenuInterno == "S")
            {
                Console.Clear();
                break;
            }

            else if (opcaoMenuInterno == "1")
            {
                telaRevista.Cadastrar();
            }
            else if (opcaoMenuInterno == "2")
            {
                telaRevista.Editar();
            }
            else if (opcaoMenuInterno == "3")
            {
                telaRevista.Excluir();
            }
            else if (opcaoMenuInterno == "4")
            {
                telaRevista.Visualizar(deveApresentar: true);
            }
        }
        else if (opcaoMenuPrincipal == "3")
        {
            opcaoMenuInterno = telaAmigo.ObterOpcaoMenu();

            if (opcaoMenuInterno == "S")
            {
                Console.Clear();
                break;
            }

            else if (opcaoMenuInterno == "1")
            {
                telaAmigo.Cadastrar();
            }
            else if (opcaoMenuInterno == "2")
            {
                telaAmigo.Editar();
            }
            else if (opcaoMenuInterno == "3")
            {
                telaAmigo.Excluir();
            }
            else if (opcaoMenuInterno == "4")
            {
                telaAmigo.Visualizar(deveApresentar: true);
            }
        }

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
        }
    }
}
