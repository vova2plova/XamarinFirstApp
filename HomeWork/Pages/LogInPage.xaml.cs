using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeWork
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogInPage : ContentPage
    {
        private readonly LogInViewModel _vm = new LogInViewModel();
        public LogInPage()
        {
            InitializeComponent();
            BindingContext = _vm;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            _vm.RedirectToMainPage();
        }
    }
}