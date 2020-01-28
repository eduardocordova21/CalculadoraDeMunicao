using CalculadoraDeMunicao.Interfaces;
using CalculadoraDeMunicao.Models;
using Newtonsoft.Json;
using System;
using Xamarin.Forms;

namespace CalculadoraDeMunicao.Views
{
    public partial class DefinicoesPage : ContentPage
    {
        public DefinicoesPage()
        {
            InitializeComponent();
            GerenciadorDeArquivo = DependencyService.Get<IGerenciadorDeArquivo>();
            OnAppearing();
        }

        public IGerenciadorDeArquivo GerenciadorDeArquivo { get; }

        protected override void OnAppearing()
        {
            CarregarDadosNoGrid();
        }

        private string AlertMessageSuccess(int quantidadeTotalEspoleta, double valorTotalEspoleta, int quantidadeTotalEstojo, double valorTotalEstojo, int quantidadeTotalPolvora, double valorTotalPolvora, int quantidadeTotalProjetil, double valorTotalProjetil, int quantidadeTotalOutros, double valorTotalOutros)
        {
            return "Qtd de Espoleta: " + quantidadeTotalEspoleta + " | Valor Total R$ " + valorTotalEspoleta + "\n" +
                    "Qtd de Estojo: " + quantidadeTotalEstojo + " | Valor Total R$ " + valorTotalEstojo + "\n" +
                    "Qtd de Pólvora: " + quantidadeTotalPolvora + " | Valor Total R$ " + valorTotalPolvora + "\n" +
                    "Qtd de Projétil: " + quantidadeTotalProjetil + " | Valor Total R$ " + valorTotalProjetil + "\n" +
                    "Qtd de Outros: " + quantidadeTotalOutros + " | Valor Total R$ " + valorTotalOutros + "\n";
        }

        private void ButtonCarregarDadosSalvos_Clicked(object sender, EventArgs e)
        {
            CarregarDadosNoGrid();
        }

        private void ButtonLimparCampos_Clicked(object sender, System.EventArgs e)
        {
            QuantidadeTotalDeEspoleta.Text = "";
            QuantidadeTotalDeEstojo.Text = "";
            QuantidadeTotalDePolvora.Text = "";
            QuantidadeTotalDeProjetil.Text = "";
            QuantidadeTotalDeOutros.Text = "";

            ValorTotalDeEspoleta.Text = "";
            ValorTotalDeEstojo.Text = "";
            ValorTotalDePolvora.Text = "";
            ValorTotalDeProjetil.Text = "";
            ValorTotalDeOutros.Text = "";
        }

        private void ButtonSalvar_Clicked(object sender, System.EventArgs e)
        {
            SalvarDados();
        }

        private void CarregarDadosNoGrid()
        {
            try
            {
                string espoleta = GerenciadorDeArquivo.LerArquivo("JsonEspoleta.json");
                string estojo = GerenciadorDeArquivo.LerArquivo("JsonEstojo.json");
                string polvora = GerenciadorDeArquivo.LerArquivo("JsonPolvora.json");
                string projetil = GerenciadorDeArquivo.LerArquivo("JsonProjetil.json");
                string outros = GerenciadorDeArquivo.LerArquivo("JsonOutros.json");

                Espoleta espoletaObject = JsonConvert.DeserializeObject<Espoleta>(espoleta);
                Espoleta estojoObject = JsonConvert.DeserializeObject<Espoleta>(estojo);
                Espoleta polvoraObject = JsonConvert.DeserializeObject<Espoleta>(polvora);
                Espoleta projetilObject = JsonConvert.DeserializeObject<Espoleta>(projetil);
                Espoleta outrosObject = JsonConvert.DeserializeObject<Espoleta>(outros);

                QuantidadeTotalDeEspoleta.Text = espoletaObject.QuantidadeTotal.ToString();
                QuantidadeTotalDeEstojo.Text = estojoObject.QuantidadeTotal.ToString();
                QuantidadeTotalDePolvora.Text = polvoraObject.QuantidadeTotal.ToString();
                QuantidadeTotalDeProjetil.Text = projetilObject.QuantidadeTotal.ToString();
                QuantidadeTotalDeOutros.Text = outrosObject.QuantidadeTotal.ToString();

                ValorTotalDeEspoleta.Text = espoletaObject.ValorTotal.ToString();
                ValorTotalDeEstojo.Text = estojoObject.ValorTotal.ToString();
                ValorTotalDePolvora.Text = polvoraObject.ValorTotal.ToString();
                ValorTotalDeProjetil.Text = projetilObject.ValorTotal.ToString();
                ValorTotalDeOutros.Text = outrosObject.ValorTotal.ToString();
            }
            catch (Exception)
            {

            }
        }

        private async void SalvarDados()
        {
            try
            {
                Espoleta espoleta = new Espoleta
                {
                    QuantidadeTotal = int.Parse(QuantidadeTotalDeEspoleta.Text),
                    ValorTotal = double.Parse(ValorTotalDeEspoleta.Text),
                };

                Estojo estojo = new Estojo
                {
                    QuantidadeTotal = int.Parse(QuantidadeTotalDeEstojo.Text),
                    ValorTotal = double.Parse(ValorTotalDeEstojo.Text),
                };

                Polvora polvora = new Polvora
                {
                    QuantidadeTotal = int.Parse(QuantidadeTotalDePolvora.Text),
                    ValorTotal = double.Parse(ValorTotalDePolvora.Text),
                };

                Projetil projetil = new Projetil
                {
                    QuantidadeTotal = int.Parse(QuantidadeTotalDeProjetil.Text),
                    ValorTotal = double.Parse(ValorTotalDeProjetil.Text),
                };

                Outros outros = new Outros
                {
                    QuantidadeTotal = int.Parse(QuantidadeTotalDeOutros.Text),
                    ValorTotal = double.Parse(ValorTotalDeOutros.Text),
                };

                string JsonEspoleta = JsonConvert.SerializeObject(espoleta);
                string JsonEstojo = JsonConvert.SerializeObject(estojo);
                string JsonPolvora = JsonConvert.SerializeObject(polvora);
                string JsonProjetil = JsonConvert.SerializeObject(projetil);
                string JsonOutros = JsonConvert.SerializeObject(outros);

                await GerenciadorDeArquivo.SalvarArquivo("JsonEspoleta.json", JsonEspoleta);
                await GerenciadorDeArquivo.SalvarArquivo("JsonEstojo.json", JsonEstojo);
                await GerenciadorDeArquivo.SalvarArquivo("JsonPolvora.json", JsonPolvora);
                await GerenciadorDeArquivo.SalvarArquivo("JsonProjetil.json", JsonProjetil);
                await GerenciadorDeArquivo.SalvarArquivo("JsonOutros.json", JsonOutros);

                await DisplayAlert("Dados Cadastrados com Sucesso!", AlertMessageSuccess(espoleta.QuantidadeTotal, espoleta.ValorTotal, estojo.QuantidadeTotal, estojo.ValorTotal, polvora.QuantidadeTotal, polvora.ValorTotal, projetil.QuantidadeTotal, projetil.ValorTotal, outros.QuantidadeTotal, outros.ValorTotal), "OK");
            }
            catch (Exception)
            {
                await DisplayAlert("Preenchimento Inválido!", "Todos os campos devem ser preenchidos corretamente.", "OK");
            }
        }
    }
}