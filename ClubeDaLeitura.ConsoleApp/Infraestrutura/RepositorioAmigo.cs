
using ClubeDaLeitura.ConsoleApp.Dominio;

namespace ClubeDaLeitura.ConsoleApp.Infraestrutura;

public class RepositorioAmigo : RepositorioBase
{
    public override bool VerificarValoresIguais(EntidadeBase entidade)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            if (registros[i] == null) continue;

            Amigo a = (Amigo)registros[i];
            Amigo amigoVerificado = (Amigo)entidade;

            if (a.Nome == amigoVerificado.Nome && a.Telefone == amigoVerificado.Telefone)
            {
                return true;
            }
        }
        return false;
    }
}

