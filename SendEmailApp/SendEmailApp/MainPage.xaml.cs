using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SendEmailApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnSend_Clicked(object sender, EventArgs e)
        {
            List<string> toAddress = new List<string>();
            toAddress.Add(txtTo.Text);
            await SendEmail(txtSubject.Text, txtBody.Text, toAddress);
        }

        public async Task SendEmail(string subject, string body, List<string> recipients)
        {
            try
            {
                var message = new EmailMessage
                {
                    Subject = subject,
                    Body = body,
                    To = recipients,
                };
                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException fbsEx)
            {
                DisplayAlert("Error", fbsEx.ToString(), "Ok");
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.ToString(), "Ok");
            }
        }
    }
}
