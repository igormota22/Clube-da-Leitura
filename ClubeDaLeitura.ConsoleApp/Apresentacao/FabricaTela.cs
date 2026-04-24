using System;
using ClubeDaLeitura.ConsoleApp.Dominio;
using ClubeDaLeitura.ConsoleApp.Infraestrutura;

namespace ClubeDaLeitura.ConsoleApp.Apresentacao;

public static class FabricaTela
{
    public  static TelaPrincipal CriarTelaPrincipal()
    {
        RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
        RepositorioRevista repositorioRevista = new RepositorioRevista();
        RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
        RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();

        Caixa caixa = new Caixa("lancamento", "Vermelha", 3);
        repositorioCaixa.Cadastrar(caixa);

        Revista revista = new Revista("batman", 55, 1947, caixa);
        repositorioRevista.Cadastrar(revista);

        Amigo amigo = new Amigo("Igor", "Rafaela", "4999089867");
        repositorioAmigo.Cadastrar(amigo);

        Emprestimo emprestimo = new Emprestimo(amigo, revista);
        emprestimo.Abrir();
        repositorioEmprestimo.Cadastrar(emprestimo);

        TelaCaixa telaCaixa = new TelaCaixa(repositorioCaixa, repositorioRevista);
        TelaRevista telaRevista = new TelaRevista(repositorioRevista, repositorioCaixa);
        TelaAmigo telaAmigo = new TelaAmigo(repositorioAmigo, repositorioEmprestimo);
        TelaEmprestimo telaEmprestimo = new TelaEmprestimo(
            repositorioEmprestimo, repositorioAmigo, repositorioRevista, telaAmigo, telaRevista
        );

        return new TelaPrincipal(telaCaixa,telaRevista,telaAmigo,telaEmprestimo);
    }
}
