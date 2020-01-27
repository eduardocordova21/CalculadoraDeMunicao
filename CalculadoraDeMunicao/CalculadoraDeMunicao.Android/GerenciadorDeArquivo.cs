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
        private readonly string nomeDoArquivo = "municoes.json";

        public string LerArquivo()
        {
            var caminhoPastaPessoal = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var caminhoCompleto = Path.Combine(caminhoPastaPessoal, nomeDoArquivo);

            using (var stream = new StreamReader(caminhoCompleto))
            {
                return stream.ReadToEnd();
            }
        }

        public async Task SalvarArquivo(string conteudoDoArquivo)
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