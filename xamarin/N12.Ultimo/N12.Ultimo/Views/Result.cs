using Microcharts;
using Microcharts.Forms;
using N12.Ultimo.Models;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace N12.Ultimo.Views
{
	public class Result : ContentPage
	{
        public static readonly SKColor[] cores = { SKColor.Parse("#266489"), SKColor.Parse("#68B9C0"), SKColor.Parse("#90D585"), SKColor.Parse("#e77e23") };

        private List<Pergunta> perguntas;

        public Result(List<Pergunta> perguntas)
		{
            this.perguntas = perguntas;
            Title = "Resultados";

            var mainStack = new StackLayout();
            mainStack.Padding = 20;

            int contador = 0;

            foreach (var item in perguntas)
            {
                contador++;
                Label lblTitulo = new Label
                {
                    Text = item.Texto,
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    HorizontalOptions = LayoutOptions.Center
                };

                int cor = 0;
                List<Microcharts.Entry> entries = new List<Microcharts.Entry>();
                foreach (var res in item.Resultados)
                {
                    var entry = new Microcharts.Entry(res.Total)
                    {
                        Label = res.Texto,
                        ValueLabel = res.Total.ToString(),
                        Color = cores[cor++]
                    };
                    entries.Add(entry);
                }

                var chartView = new ChartView()
                {
                    HeightRequest = 300,
                    Chart = GetChart(entries, contador)
                };


                var stack = new StackLayout
                {
                    Padding = new Thickness(5, 5),
                    Children =
                    {
                        lblTitulo,
                        chartView
                    }
                };

                mainStack.Children.Add(stack);
            }

            Content = new ScrollView { Content = mainStack };
        }

        private Chart GetChart(List<Microcharts.Entry> entries, int contador)
        {
            switch(contador)
            {
                case 1:
                    return new Microcharts.BarChart()
                    {
                        Entries = entries,
                        LabelTextSize = 30,
                    };
                case 2:
                    return new Microcharts.DonutChart()
                    {
                        Entries = entries,
                        LabelTextSize = 30,
                    };
                default:
                    return new Microcharts.RadialGaugeChart()
                    {
                        Entries = entries,
                        LabelTextSize = 30,
                    };
            }
        }
	}

}