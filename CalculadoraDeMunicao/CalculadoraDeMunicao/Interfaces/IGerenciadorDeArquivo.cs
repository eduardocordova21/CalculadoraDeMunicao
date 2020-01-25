using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace CalculadoraDeMunicao.Interfaces
{
    public interface IGerenciadorDeArquivo
    {
        Task SalvarArquivo(string conteudoDoArquivo);

        Task<string> LerArquivo();
    }
}
