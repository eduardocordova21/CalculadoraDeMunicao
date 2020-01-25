using CalculadoraDeMunicao.Interfaces;
using Xamarin.Forms;

namespace CalculadoraDeMunicao.Views
{
    public partial class CalculadoraPage : ContentPage
    {
        public IGerenciadorDeArquivo GerenciadorDeArquivo{ get; }

        public CalculadoraPage()
        {
            InitializeComponent();
            GerenciadorDeArquivo = DependencyService.Get<IGerenciadorDeArquivo>();
        }
    }
}
