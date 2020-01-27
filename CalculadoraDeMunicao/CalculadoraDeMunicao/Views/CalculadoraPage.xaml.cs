using CalculadoraDeMunicao.Interfaces;
using CalculadoraDeMunicao.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using Xamarin.Forms;

namespace CalculadoraDeMunicao.Views
{
    public partial class CalculadoraPage : ContentPage
    {
        public IGerenciadorDeArquivo GerenciadorDeArquivo { get; }

        public CalculadoraPage()
        {
            InitializeComponent();
            GerenciadorDeArquivo = DependencyService.Get<IGerenciadorDeArquivo>();
            string dados = GerenciadorDeArquivo.LerArquivo();
        }
    }
}