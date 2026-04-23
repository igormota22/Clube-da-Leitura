using System;
using ClubeDaLeitura.ConsoleApp.Dominio;

namespace ClubeDaLeitura.ConsoleApp.Infraestrutura;

public class RepositorioEmprestimo
{
    private Emprestimo?[] emprestimos = new Emprestimo[100];
    public void Cadastrar(Emprestimo novoEmprestimo)
    {
        for (int i = 0; i < emprestimos.Length; i++)
        {
            if (emprestimos[i] == null)
            {
                emprestimos[i] = novoEmprestimo;
                novoEmprestimo.Abrir();
                break;
            }
        }


    }

    public bool AmigoTemEmprestimoAtivo(string idAmigo)
    {
        for (int i = 0; i < emprestimos.Length; i++)
        {
            if (emprestimos[i] == null) continue;

            Emprestimo? e = emprestimos[i];
            if (e.Amigo.Id == idAmigo && e.Status == StatusEmprestimo.Aberto)
                return true;
        }
        return false;
    }

    public Emprestimo? SelecionarPorId(string idSelecionado)
    {
        Emprestimo? EmprestimoSelecionado = null;

        for (int i = 0; i < emprestimos.Length; i++)
        {
            Emprestimo? e = emprestimos[i];

            if (e == null)
                continue;

            if (e.Id == idSelecionado)
            {
                EmprestimoSelecionado = e;
                break;
            }
        }

        return EmprestimoSelecionado;
    }

    public Emprestimo[] SelecionarTodos()
    {
        return emprestimos;
    }
}
