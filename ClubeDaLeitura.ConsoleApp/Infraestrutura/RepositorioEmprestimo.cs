using System;
using ClubeDaLeitura.ConsoleApp.Dominio;

namespace ClubeDaLeitura.ConsoleApp.Infraestrutura;

public class RepositorioEmprestimo
{
    protected Emprestimo?[] registros = new Emprestimo[100];
    public void Cadastrar(Emprestimo novoEmprestimo)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            if (registros[i] == null)
            {
                registros[i] = novoEmprestimo;
                break;
            }
        }

        novoEmprestimo.Revista.Status = "Emprestada";
    }

    public bool AmigoTemEmprestimoAtivo(string idAmigo)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            if (registros[i] == null) continue;

            Emprestimo? e = (Emprestimo)registros[i];
            if (e.Amigo.Id == idAmigo && e.Status == "Aberto")
                return true;
        }
        return false;
    }

      public Emprestimo? SelecionarPorId(string idSelecionado)
    {
        Emprestimo? EmprestimoSelecionado = null;

        for (int i = 0; i < registros.Length; i++)
        {
            Emprestimo? e = registros[i];

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
        return registros;
    }
}
