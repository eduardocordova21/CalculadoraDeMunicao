using CalculadoraDeMunicao.Droid;
using CalculadoraDeMunicao.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(GerenciadorDeArquivo))]
namespace CalculadoraDeMunicao.Droid
{
    public class GerenciadorDeArquivo : IGerenciadorDeArquivo
    {
        public async Task<string> LerArquivo()
        {
            string nomeDoArquivo = "municoes.json";
            var caminhoPastaPessoal = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var caminhoCompleto = Path.Combine(caminhoPastaPessoal, nomeDoArquivo);

            using (var stream = new StreamReader(caminhoCompleto))
            {
                return await stream.ReadToEndAsync();
            }
        }

        public async Task SalvarArquivo(string conteudoDoArquivo)
        {
            string nomeDoArquivo = "municoes.json";
            var caminhoPastaPessoal = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var caminhoCompleto = Path.Combine(caminhoPastaPessoal, nomeDoArquivo);
            
            using (var stream = new StreamWriter(caminhoCompleto, false))
            {
                stream.AutoFlush = true;
                await stream.WriteAsync(conteudoDoArquivo);
            }
        }
    }
}