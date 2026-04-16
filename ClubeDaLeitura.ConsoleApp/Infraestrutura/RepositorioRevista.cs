using System;
using ClubeDaLeitura.ConsoleApp.Dominio;

namespace ClubeDaLeitura.ConsoleApp.Infraestrutura;

public class RepositorioRevista
{
    Revista?[] revistas = new Revista[100];

    public void Cadastrar(Revista novaRevista)
    {
        for (int i = 0; i < revistas.Length; i++)
        {
            if (revistas[i] == null)
            {
                revistas[i] = novaRevista;
                break;
            }
        }
    }

    public bool Editar(string idSelecionado, Revista novaRevista)
    {
        Revista? RevistaSelecionada = SelecionarPorId(idSelecionado);

        if (RevistaSelecionada == null)
        {
            return false;

        }


        RevistaSelecionada.AtualizarDados(novaRevista);

        return true;
    }

    private Revista? SelecionarPorId(string idSelecionado)
    {
        Revista revistaSelecionada = null;

        for (int i = 0; i < revistas.Length; i++)
        {
            Revista? r = revistas[i];

            if (r == null)
            {
                continue;
            }
            if (r.Id == idSelecionado)
            {
                revistaSelecionada = r;
                break;
            }
        }

        return revistaSelecionada;
    }

    public Revista?[] SelecionarTodos()
    {
        return revistas;
    }


}
