using System;
using ClubeDaLeitura.ConsoleApp.Dominio;

namespace ClubeDaLeitura.ConsoleApp.Infraestrutura;

public class RepositorioRevista : RepositorioBase
{
    public bool TemRevistaNaCaixa(string idCaixa)
    {
        for(int i = 0; i < registros.Length; i++)
        {
            if(registros[i] == null) continue;

            Revista r = (Revista) registros[i];

            if(r.Caixa.Id == idCaixa)
            {
                return true;
            }
        }
        return false;
    }
}
