using System.Threading.Tasks;

namespace CalculadoraDeMunicao.Interfaces
{
    public interface IGerenciadorDeArquivo
    {
        Task SalvarArquivo(string nomeDoArquivo, string conteudoDoArquivo);

        string LerArquivo(string nomeDoArquivo);
    }
}