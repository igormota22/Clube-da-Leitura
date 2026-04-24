using System;
using ClubeDaLeitura.ConsoleApp.Dominio;

namespace ClubeDaLeitura.ConsoleApp.Infraestrutura;

public class RepositorioCaixa : RepositorioBase
{
    public override bool VerificarValoresIguais(EntidadeBase entidade)
    {
        
        for(int i = 0; i < registros.Length; i++)
        {
            if(registros[i] == null) continue;

            Caixa c = (Caixa)registros[i];
            Caixa caixaSelecionada = (Caixa)entidade;

            if(c.Etiqueta == caixaSelecionada.Etiqueta)
            {
                return true;
            }
        }
        return false;
    }
}



