using System;
using ClubeDaLeitura.ConsoleApp.Dominio;

namespace ClubeDaLeitura.ConsoleApp.Infraestrutura;

public class RepositorioEmprestimo : RepositorioBase
{
    public override void Cadastrar(EntidadeBase novaEntidade)
    {
        base.Cadastrar(novaEntidade);

        Emprestimo e = (Emprestimo)novaEntidade;
        e.Revista.Status = "Emprestada";
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
}
