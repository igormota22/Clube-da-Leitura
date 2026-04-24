
using ClubeDaLeitura.ConsoleApp.Dominio;

namespace ClubeDaLeitura.ConsoleApp.Infraestrutura;

public class RepositorioRevista : RepositorioBase
{
    public bool TemRevistaNaCaixa(string idCaixa)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            if (registros[i] == null) continue;

            Revista r = (Revista)registros[i];

            if (r.Caixa.Id == idCaixa)
            {
                return true;
            }
        }
        return false;
    }

    public override bool VerificarValoresIguais(EntidadeBase entidade)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            if (registros[i] == null) continue;

            Revista r = (Revista)registros[i];
            Revista revistaSelecionada = (Revista)entidade;

            if (r.Titulo == revistaSelecionada.Titulo && r.NumeroDeEdicao == revistaSelecionada.NumeroDeEdicao)
            {
                return true;
            }
        }
        return false;
    }
}
