using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace N12.Ultimo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmptyContent : ContentPage
    {
        public EmptyContent(int type)
        {
            InitializeComponent();
            switch(type)
            {
                case 1:
                    break;
                case 2:
                    LblInfo.Text = "Nenhum resultado encontrado.";
                    break;
            }
        }
    }
}