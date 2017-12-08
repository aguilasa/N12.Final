using N12.Ultimo.Models;
using N12.Ultimo.Services;
using N12.Ultimo.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace N12.Ultimo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnResponder_Clicked(object sender, EventArgs e)
        {
            PerguntasService service = new PerguntasService();
            List<Pergunta> perguntas = await service.GetPerguntas();

            await Navigation.PushAsync(new Question(perguntas));
        }

        private async void BtnResultados_Clicked(object sender, EventArgs e)
        {
            PerguntasService service = new PerguntasService();

            List<Pergunta> perguntas = await service.GetResultados();
            if (perguntas.Count == 0)
            {
                await Navigation.PushAsync(new EmptyContent(2));
            } else
            {
                await Navigation.PushAsync(new Result(perguntas));
            }
        }
    }
}
