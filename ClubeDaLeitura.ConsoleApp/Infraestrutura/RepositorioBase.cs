using System;
using ClubeDaLeitura.ConsoleApp.Dominio;

namespace ClubeDaLeitura.ConsoleApp.Infraestrutura;

public class RepositorioBase
{
    public bool Editar(string idSelecionado, EntidadeBase novaEntidade)
    {
       EntidadeBase? EntidadeSelecionada = SelecionarPorId(idSelecionado);

        if (EntidadeSelecionada == null)
        {
            return false;

        }


        EntidadeSelecionada.AtualizarDados(novaEntidade);

        return true;
    }

    public EntidadeBase SelecionarPorId(string idSelecionado)
    {
        return null;
    }
}
