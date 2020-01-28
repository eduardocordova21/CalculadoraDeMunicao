using CalculadoraDeMunicao.Droid;
using CalculadoraDeMunicao.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(GerenciadorDeArquivo))]

namespace CalculadoraDeMunicao.Droid
{
    public class GerenciadorDeArquivo : IGerenciadorDeArquivo
    {
        public string LerArquivo(string nomeDoArquivo)
        {
            var caminhoPastaPessoal = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var caminhoCompleto = Path.Combine(caminhoPastaPessoal, nomeDoArquivo);

            using (var stream = new StreamReader(caminhoCompleto))
            {
                return stream.ReadToEnd();
            }
        }

        public async Task SalvarArquivo(string nomeDoArquivo, string conteudoDoArquivo)
        {
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