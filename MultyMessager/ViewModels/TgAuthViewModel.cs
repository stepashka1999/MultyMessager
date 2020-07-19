using MultyMessager.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TLSharp;
using TLSharp.Core;

namespace MultyMessager.ViewModels
{
    class TgAuthViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        private TelegramClient client;
        private Frame frame;


        private string error;
        public string Error { get => error; set { error = value; OnPropertyChanged(nameof(Error)); } }


        private string phone;
        public string Phone { get => phone; set { phone = value; OnPropertyChanged(nameof(Phone)); } }


        private string code;
        public string Code { get => code; set { code = value; OnPropertyChanged(nameof(Code)); } }
        

        private string hash;

        public TgAuthViewModel(TelegramClient client, Frame frame)
        {
            this.frame = frame;
            this.client = client;
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        //-------- Methods

        public long PhoneParse(string text)
        {
            string tempRes = "";

            foreach(var symbol in text)
            {
                if(char.IsDigit(symbol))
                {
                    tempRes += symbol;
                }
            }

            return long.Parse(tempRes);
        }

        private bool VerifyNumber()
        {
            if (string.IsNullOrEmpty(Phone) || Phone.Length != 18)
            {
                Error = "Проверьте правильность введенного номера телефона.";
                return false;
            }
            return true;
        }

        private async void SendCodeRequest()
        {
            try
            {
                if(VerifyNumber())  hash = await client.SendCodeRequestAsync(Phone)t;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private bool MakeAuth()
        {
            try
            {
                var user = client.MakeAuthAsync(Phone, hash, Code).Result;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

            return true;
        }


        //-------- Commands

        public ICommand SendCodeRequestCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    SendCodeRequest();
                });
            }
        }

        public ICommand AunteficateCommand
        {
            get
            {
                return new RelayCommand( obj =>
                {
                    if(MakeAuth())
                    {
                        frame.Navigate(new TgPage(client));
                    }
                });
            }
        }
    }
}
