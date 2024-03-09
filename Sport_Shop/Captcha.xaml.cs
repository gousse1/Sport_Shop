using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sport_Shop
{
    /// <summary>
    /// Логика взаимодействия для Captcha.xaml
    /// </summary>
    public partial class Captcha : Window
    {
        public event System.EventHandler CaptchaRefreshed;
        public Captcha()
        {
            InitializeComponent();
            CreateCaptcha();
        }

        private void CreateCaptcha()
        {
            string allowchar = string.Empty;
            allowchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            allowchar += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z";
            allowchar += "1,2,3,4,5,6,7,8,9,0";
            char[] a = { ',' };
            string[] ar = allowchar.Split(a);
            string pwd = string.Empty;
            string temp = string.Empty;
            System.Random r = new System.Random();

            for (int i = 0; i < 6; i++)
            {
                temp = ar[(r.Next(0, ar.Length))];

                pwd += temp;
            }
            CaptchaText.Text = pwd;
            CaptchaRefreshed?.Invoke(this, System.EventArgs.Empty);
        }


        private void ResetCaptchaButton_Click(object sender, RoutedEventArgs e)
        {
            CreateCaptcha();
        }

        private async void LoginCaptcha_Click(object sender, RoutedEventArgs e)
        {

            if (txtcaptcha.Text == CaptchaText.Text)
            {
                ListView task = new ListView();
                task.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Капча введена неправильно, кнопка войти заблокирована на 5 секунд!");
                LoginCaptcha.IsEnabled = false;
                int i = 5;
                while (true)
                {
                    timertick.Content = Convert.ToString(i);
                    await Task.Delay(1000);
                    i -= 1;
                    if (i <= 0)
                    {
                        LoginCaptcha.IsEnabled = true;
                        timertick.Content = "";
                        break;
                    }
                }
            }
        }
    }
}