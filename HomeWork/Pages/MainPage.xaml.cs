using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HomeWork
{
    public partial class MainPage : ContentPage
    {
        private int image;
        MainPageViewModel _vm = new MainPageViewModel();

        public MainPage()
        {
            image = 0;
            InitializeComponent();
            BindingContext = _vm;
        }

        protected override async void OnAppearing()
        {
            ObservableCollection<Posts> posts;
            posts = await _vm.LoadPost();
            int i = 0;
            foreach (var post in posts)
            {
                using (HttpClient client = new HttpClient())
                {
                    if (!post.download_url.Trim().StartsWith("https", StringComparison.OrdinalIgnoreCase))
                        throw new Exception("iOS and Android Require Https");
                    byte[] bytes = await client.GetByteArrayAsync(post.download_url);
                    Xamarin.Essentials.Preferences.Set($"image{i}", Convert.ToBase64String(bytes));
                    var image = Xamarin.Essentials.Preferences.Get($"image{i}", string.Empty);
                    post.image = ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(image)));
                }
                i++;
            }
            BindableLayout.SetItemsSource(Post_list, posts);
            base.OnAppearing();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (await Dialog() == true)
            {
                if (image == 0)
                {
                    image = 1;
                    ProfileImage.Source = ImageSource.FromFile("image1");
                }
                else
                {
                    image = 0;
                    ProfileImage.Source = ImageSource.FromFile("image");
                }
            }

            Toast("Фотография изменена");
        }   

        private static void Toast(string message)
        {
            ToastConfig toastConfig = new ToastConfig(message);
            toastConfig.SetDuration(100);
            toastConfig.SetBackgroundColor(Color.LightYellow);
            toastConfig.SetMessageTextColor(Color.Black);
            UserDialogs.Instance.Toast(toastConfig);
        }

        private Task<bool> Dialog()
        {
            ConfirmConfig confirm = new ConfirmConfig();
            confirm.OkText = "Да";
            confirm.CancelText = "Нет";
            confirm.Message = "Вы уверены?";
            return (UserDialogs.Instance.ConfirmAsync(confirm));
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Alert("Вова 14 лет, пошлый💅💅💅");
        }

        private static void Alert(string message)
        {
            AlertConfig alertConfig = new AlertConfig();
            alertConfig.SetMessage(message);
            UserDialogs.Instance.Alert(alertConfig);
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Alert("Применение к этой кнопке ещё не придумали");
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            Status.Text = ((await Promt()).Value.ToString());
        }

        private Task<PromptResult> Promt()
        {
            PromptConfig promptConfig = new PromptConfig();
            promptConfig.SetMessage("Введите новый статус");
            return (UserDialogs.Instance.PromptAsync(promptConfig));
        }
    }
}
