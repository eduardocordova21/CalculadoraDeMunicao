﻿using CalculoDeMunicao.Models;
using System;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using Android.Content.Res;

namespace CalculoDeMunicao.Views
{
    public partial class ValoresPage : ContentPage
    {
        public ValoresPage()
        {
            InitializeComponent();
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
            try
            {
                Espoleta espoleta = new Espoleta
                {
                    QuantidadeTotal = int.Parse(QuantidadeTotalDeEspoleta.Text),
                    ValorTotal = double.Parse(ValorTotalDeEspoleta.Text),
                    ValorUnitário = double.Parse(ValorTotalDeEspoleta.Text) / int.Parse(QuantidadeTotalDeEspoleta.Text)
                };

                Estojo estojo = new Estojo
                {
                    QuantidadeTotal = int.Parse(QuantidadeTotalDeEstojo.Text),
                    ValorTotal = double.Parse(ValorTotalDeEstojo.Text),
                    ValorUnitário = double.Parse(ValorTotalDeEstojo.Text) / int.Parse(QuantidadeTotalDeEstojo.Text)
                };

                Polvora polvora = new Polvora
                {
                    QuantidadeTotal = int.Parse(QuantidadeTotalDePolvora.Text),
                    ValorTotal = double.Parse(ValorTotalDePolvora.Text),
                    ValorUnitário = double.Parse(ValorTotalDePolvora.Text) / int.Parse(QuantidadeTotalDePolvora.Text)
                };

                Projetil projetil = new Projetil
                {
                    QuantidadeTotal = int.Parse(QuantidadeTotalDeProjetil.Text),
                    ValorTotal = double.Parse(ValorTotalDeProjetil.Text),
                    ValorUnitário = double.Parse(ValorTotalDeProjetil.Text) / int.Parse(QuantidadeTotalDeProjetil.Text)
                };

                Outros outros = new Outros
                {
                    QuantidadeTotal = int.Parse(QuantidadeTotalDeOutros.Text),
                    ValorTotal = double.Parse(ValorTotalDeOutros.Text),
                    ValorUnitário = double.Parse(ValorTotalDeOutros.Text) / int.Parse(QuantidadeTotalDeOutros.Text)
                };

                JObject precoDasMunicoes = new JObject(
                    new JProperty("QuantidadeTotalDeEspoleta", espoleta.QuantidadeTotal),
                    new JProperty("ValorTotalDeEspoleta", espoleta.ValorTotal),
                    new JProperty("ValorUnitarioDeEspoleta", espoleta.ValorUnitário),

                    new JProperty("QuantidadeTotalDeEstojos", estojo.QuantidadeTotal),
                    new JProperty("ValorTotalDeEstojos", estojo.ValorTotal),
                    new JProperty("ValorUnitárioDeEstojos", estojo.ValorUnitário),

                    new JProperty("QuantidadeTotalDePolvora", polvora.QuantidadeTotal),
                    new JProperty("ValorTotalDePolvora", polvora.ValorTotal),
                    new JProperty("ValorUnitárioDePolvora", polvora.ValorUnitário),

                    new JProperty("QuantidadeTotalDeProjetil", projetil.QuantidadeTotal),
                    new JProperty("ValorTotalDeProjetil", projetil.ValorTotal),
                    new JProperty("ValorUnitárioDeProjetil", projetil.ValorUnitário),

                    new JProperty("QuantidadeTotalDeOutros", outros.QuantidadeTotal),
                    new JProperty("ValorTotalDeOutros", outros.ValorTotal),
                    new JProperty("ValorUnitárioDeOutros", outros.ValorUnitário)
                );

                string fileName = "valoresDeMunicao.json";
                string path = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, fileName);

                //Salvar arquivo JSON

                DisplayAlert("Dados Cadastrados com Sucesso!", AlertMessageSuccess(espoleta.QuantidadeTotal, espoleta.ValorTotal, estojo.QuantidadeTotal, estojo.ValorTotal, polvora.QuantidadeTotal, polvora.ValorTotal, projetil.QuantidadeTotal, projetil.ValorTotal, outros.QuantidadeTotal, outros.ValorTotal), "OK");
            }
            catch (Exception)
            {
                DisplayAlert("Preenchimento Inválido!", "Todos os campos devem ser preenchidos corretamente.", "OK");
            }

        }

        private string AlertMessageSuccess(int quantidadeTotalEspoleta, double valorTotalEspoleta, int quantidadeTotalEstojo, double valorTotalEstojo, int quantidadeTotalPolvora, double valorTotalPolvora, int quantidadeTotalProjetil, double valorTotalProjetil, int quantidadeTotalOutros, double valorTotalOutros)
        {
            return "Espoleta - Qtd: " + quantidadeTotalEspoleta + " | R$ " + valorTotalEspoleta + "\n" +
                    "Estojo - Qtd: " + quantidadeTotalEstojo + " | R$ " + valorTotalEstojo + "\n" +
                    "Pólvora - Qtd: " + quantidadeTotalPolvora + " | R$ " + valorTotalPolvora + "\n" +
                    "Projétil - Qtd: " + quantidadeTotalProjetil + " | R$ " + valorTotalProjetil + "\n" +
                    "Outros - Qtd: " + quantidadeTotalOutros + " | R$ " + valorTotalOutros + "\n";
        }

    }
}