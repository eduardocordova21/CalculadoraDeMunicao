using CalculadoraDeMunicao.Interfaces;
using CalculadoraDeMunicao.Models;
using Newtonsoft.Json;
using System;
using Xamarin.Forms;

namespace CalculadoraDeMunicao.Views
{
    public partial class CalculadoraPage : ContentPage
    {
        public CalculadoraPage()
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

        private void ButtonCalcular_Clicked(object sender, System.EventArgs e)
        {
            CalcularCampos();
        }

        private void ButtonLimparCampos_Clicked(object sender, EventArgs e)
        {
            LimparCamposDeQuantidadeUnitaria();
            LimparCamposDeValorPorRecarga();
        }

        private void CalcularCampos()
        {
            try
            {
                double valorPorRecargaEspoleta = Math.Round(double.Parse(ValorUnitarioDeEspoletaEntry.Text) * int.Parse(QuantidadeUnitáriaDeEspoleta.Text), 2);
                double valorPorRecargaEstojo = Math.Round((double.Parse(ValorUnitarioDeEstojosEntry.Text) * int.Parse(QuantidadeUnitáriaDeEstojo.Text) / 100), 2);
                double valorPorRecargaPolvora = Math.Round(double.Parse(ValorUnitarioDePolvoraEntry.Text) * double.Parse(QuantidadeUnitáriaDePolvora.Text), 2);
                double valorPorRecargaProjetil = Math.Round(double.Parse(ValorUnitarioDeProjetilEntry.Text) * int.Parse(QuantidadeUnitáriaDeProjetil.Text), 2);
                double valorPorRecargaOutros = Math.Round(double.Parse(ValorUnitarioDeOutrosEntry.Text) * double.Parse(QuantidadeUnitáriaDeOutros.Text), 2);

                double valorTotalPorRecarga = valorPorRecargaEspoleta + valorPorRecargaEstojo + valorPorRecargaPolvora + valorPorRecargaProjetil + valorPorRecargaOutros;

                ValorPorRecargaEspoleta.Text = valorPorRecargaEspoleta.ToString();
                ValorPorRecargaEstojo.Text = valorPorRecargaEstojo.ToString();
                ValorPorRecargaPolvora.Text = valorPorRecargaPolvora.ToString();
                ValorPorRecargaProjetil.Text = valorPorRecargaProjetil.ToString();
                ValorPorRecargaOutros.Text = valorPorRecargaOutros.ToString();

                ValorPorRecargarLabel.Text = "R$ " + valorTotalPorRecarga;
            }
            catch (Exception)
            {
                DisplayAlert("Preenchimento Inválido!", "Todos os campos devem ser preenchidos corretamente.", "OK");
            }
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

                ValorUnitarioDeEspoletaEntry.Text = Math.Round(espoletaObject.ValorUnitário, 2).ToString();
                ValorUnitarioDeEstojosEntry.Text = Math.Round(estojoObject.ValorUnitário, 2).ToString();
                ValorUnitarioDePolvoraEntry.Text = Math.Round((polvoraObject.ValorUnitário / 10), 2).ToString();
                ValorUnitarioDeProjetilEntry.Text = Math.Round(projetilObject.ValorUnitário, 2).ToString();
                ValorUnitarioDeOutrosEntry.Text = Math.Round(outrosObject.ValorUnitário, 2).ToString();
            }
            catch (Exception)
            {
                
            }
        }

        private void LimparCamposDeQuantidadeUnitaria()
        {
            QuantidadeUnitáriaDeEspoleta.Text = "";
            QuantidadeUnitáriaDeEstojo.Text = "";
            QuantidadeUnitáriaDePolvora.Text = "";
            QuantidadeUnitáriaDeProjetil.Text = "";
            QuantidadeUnitáriaDeOutros.Text = "";
        }

        private void LimparCamposDeValorPorRecarga()
        {
            ValorPorRecargaEspoleta.Text = "";
            ValorPorRecargaEstojo.Text = "";
            ValorPorRecargaPolvora.Text = "";
            ValorPorRecargaProjetil.Text = "";
            ValorPorRecargaOutros.Text = "";
            ValorPorRecargarLabel.Text = "R$ 0.00";
        }
    }
}