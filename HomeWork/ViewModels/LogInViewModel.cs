using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeWork
{
    public class LogInViewModel
    {
        public async void RedirectToMainPage()
        {
            using (IProgressDialog progress = UserDialogs.Instance.Progress("Проверка данных", null, null, true, MaskType.Black))
            {
                for (int i = 0; i < 100; i++)
                {
                    progress.PercentComplete = i;
                   /* await Task.Delay(20);*/
                }
            }
            await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
        }

    }
}
