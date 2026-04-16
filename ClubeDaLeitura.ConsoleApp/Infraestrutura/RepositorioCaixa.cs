using System;
using ClubeDaLeitura.ConsoleApp.Dominio;

namespace ClubeDaLeitura.ConsoleApp.Infraestrutura;

public class RepositorioCaixa
{
    private Caixa[] caixas = new Caixa[100];

    public void Cadastrar(Caixa novaCaixa)
    {
        for (int i = 0; i < caixas.Length; i++)
        {
            if (caixas[i] == null)
            {
                caixas[i] = novaCaixa;
                break;
            }
        }
    }

    public bool Editar(string idSelecionado, Caixa novaCaixa)
    {
        Caixa? CaixaSelecionada = SelecionarPorId(idSelecionado);

        if (CaixaSelecionada == null)
        {
            return false;

        }


        CaixaSelecionada.AtualizarDados(novaCaixa);

        return true;
    }


    public Caixa? SelecionarPorId(string idSelecionado)
    {
        Caixa? CaixaSelecionada = null;

        for (int i = 0; i < caixas.Length; i++)
        {
            Caixa? c = caixas[i];

            if (c == null)
                continue;

            if (c.Id == idSelecionado)
            {
                CaixaSelecionada = c;
                break;
            }
        }

        return CaixaSelecionada;
    }

    public bool Excluir(string idSelecionado)
    {
        for (int i = 0; i < caixas.Length; i++)
        {
            Caixa? c = caixas[i];

            if (c == null)
            {
                continue;
            }

            if (c.Id == idSelecionado)
            {
                caixas[i] = null;
                return true;
            }
        }

        return false;
    }

    public Caixa[]? SelecionarTodos()
    {
        return caixas;
    }
}
