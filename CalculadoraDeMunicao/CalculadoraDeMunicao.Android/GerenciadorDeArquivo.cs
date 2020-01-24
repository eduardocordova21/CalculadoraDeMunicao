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
        public async Task<string> LerArquivo(string caminhoDoArquivo, string nomeDoArquivo)
        {
            var caminhoCompleto = Path.Combine(caminhoDoArquivo, nomeDoArquivo);
            using var stream = new StreamReader(caminhoCompleto);
            return await stream.ReadToEndAsync();
        }

        public async Task SalvarArquivo(string nomeDoArquivo, string conteudoDoArquivo)
        {
            var caminhoPastaPessoal = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var caminhoCompleto = Path.Combine(caminhoPastaPessoal, nomeDoArquivo);
            using var stream = new StreamWriter(caminhoCompleto, false)
            {
                AutoFlush = true
            };
            await stream.WriteAsync(conteudoDoArquivo);
        }
    }
}