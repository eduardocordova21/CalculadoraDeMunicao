using System.Threading.Tasks;

namespace CalculadoraDeMunicao.Interfaces
{
    public interface IGerenciadorDeArquivo
    {
        Task SalvarArquivo(string conteudoDoArquivo);

        string LerArquivo();
    }
}