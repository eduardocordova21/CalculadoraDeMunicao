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
                // Pegando os valores dos campos de Valor Unitário
                double valorUnitarioDeEspoleta = double.Parse(ValorUnitarioDeEspoletaEntry.Text);
                double valorUnitarioDeEstojos = double.Parse(ValorUnitarioDeEstojosEntry.Text);
                double valorUnitarioDePolvora = double.Parse(ValorUnitarioDePolvoraEntry.Text);
                double valorUnitarioDeProjetil = double.Parse(ValorUnitarioDeProjetilEntry.Text);
                double valorUnitarioDeOutros = double.Parse(ValorUnitarioDeOutrosEntry.Text);

                // Pegando os valores dos campos de Quantidade Unitária
                int quantidadeUnitáriaDeEspoleta = int.Parse(QuantidadeUnitáriaDeEspoleta.Text);
                int quantidadeUnitáriaDeEstojo = int.Parse(QuantidadeUnitáriaDeEstojo.Text);
                double quantidadeUnitáriaDePolvora = double.Parse(QuantidadeUnitáriaDePolvora.Text);
                int quantidadeUnitáriaDeProjetil = int.Parse(QuantidadeUnitáriaDeProjetil.Text);

                // Fazendo a soma das Quantidades Unitárias para conseguir a Quantidade Unitária de Outros 
                double quantidadeTotalDeOutros = quantidadeUnitáriaDeEspoleta + quantidadeUnitáriaDeEstojo + quantidadeUnitáriaDePolvora + quantidadeUnitáriaDeProjetil;
                QuantidadeUnitáriaDeOutros.Text = quantidadeTotalDeOutros.ToString();

                // Calculando o Valor por Recarga de cada campo
                double valorPorRecargaEspoleta = Math.Round(valorUnitarioDeEspoleta * quantidadeUnitáriaDeEspoleta, 4);
                double valorPorRecargaEstojo = Math.Round(valorUnitarioDeEstojos / quantidadeUnitáriaDeEstojo, 4);
                double valorPorRecargaPolvora = Math.Round(valorUnitarioDePolvora * quantidadeUnitáriaDePolvora, 4);
                double valorPorRecargaProjetil = Math.Round(valorUnitarioDeProjetil * quantidadeUnitáriaDeProjetil, 4);
                double valorPorRecargaOutros = Math.Round(valorUnitarioDeOutros * quantidadeTotalDeOutros, 4);

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

                ValorUnitarioDeEspoletaEntry.Text = Math.Round(espoletaObject.ValorUnitário, 4).ToString();
                ValorUnitarioDeEstojosEntry.Text = Math.Round(estojoObject.ValorUnitário, 4).ToString();
                ValorUnitarioDePolvoraEntry.Text = Math.Round((polvoraObject.ValorUnitário / 10), 4).ToString();
                ValorUnitarioDeProjetilEntry.Text = Math.Round(projetilObject.ValorUnitário, 4).ToString();
                ValorUnitarioDeOutrosEntry.Text = Math.Round(outrosObject.ValorUnitário, 4).ToString();
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