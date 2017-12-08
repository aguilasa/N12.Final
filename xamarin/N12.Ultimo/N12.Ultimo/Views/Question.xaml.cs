using N12.Ultimo.Models;
using N12.Ultimo.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace N12.Ultimo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Question : ContentPage
    {
        private List<Pergunta> perguntas;
        private int index;
        private int total = 0;
        private bool ultima = false;
        private ObservableCollection<ItemResposta> listaRespostas { get; set; }
        private ItemResposta atual = null;
        private List<ItemResposta> items = new List<ItemResposta>();
        
        public Question(List<Pergunta> perguntas, int index)
        {
            this.perguntas = perguntas;
            this.index = index;
            total = perguntas.Count;
            listaRespostas = new ObservableCollection<ItemResposta>();
            InitializeComponent();

            lstPerguntas.ItemsSource = listaRespostas;

            checaUltima();
            setarTextoPergunta();
            addItems();           
        }

        private void setarTextoPergunta()
        {
            lbPergunta.Text = perguntas[index].Texto;
        }

        private void checaUltima()
        {
            ultima = (perguntas.Count - 1) == index;
        }

        private void addItems()
        {
            listaRespostas.Clear();
            if (perguntas.Count > 0 && perguntas[index].Respostas.Count > 0)
            {
                var p = perguntas[index];
                var respostas = p.Respostas;
                foreach (var r in respostas)
                {
                    listaRespostas.Add(new ItemResposta() { Id = r.Id, Texto = r.Texto, resposta = r, pergunta = p });
                }
            }
        }

        private void lstPerguntas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            atual = (ItemResposta) e.SelectedItem;
        }

        private void BtnProxima_Clicked(object sender, EventArgs e)
        {
            if (atual == null)
            {
                this.DisplayAlert("AVISO", "Selecione uma resposta", "OK");
            } else
            {
                items.Add(atual);
                atual = null;
                proximaPergunta();
            }
        }

        private void proximaPergunta()
        {
            if (index < total)
            {
                index++;
                checaUltima();
                checarBotoes();
                setarTextoPergunta();
                addItems();
            }
        }

        private void checarBotoes()
        {
            if (ultima)
            {
                BtnFinalizar.IsVisible = true;
                BtnProxima.IsVisible = false;
            }
        }

        private async void BtnFinalizar_Clicked(object sender, EventArgs e)
        {
            if (atual == null)
            {
                await this.DisplayAlert("AVISO", "Selecione uma resposta", "OK");
            }
            else
            {
                PerguntasService service = new PerguntasService();
                items.Add(atual);
                foreach (var item in items)
                {
                    await service.PostResponder(item.pergunta, item.resposta);
                }

                await Navigation.PushAsync(new MainPage());
            }
        }
    }

    public class ItemResposta
    {
        public int Id { get; set; }
        public string Texto { get; set; }        
        public Resposta resposta { get; set; }
        public Pergunta pergunta { get; set; }
    }
}