using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TLSharp;
using TLSharp.Core;

namespace MultyMessager.ViewModels
{
    class TgAuthViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        private TelegramClient client;


        private string error;
        public string Error { get => error; set { error = value; OnPropertyChanged(nameof(Error)); } }


        private string phone;
        public string Phone { get => phone; set { phone = value; OnPropertyChanged(nameof(Phone)); } }


        private string code;
        public string Code { get => code; set { code = value; OnPropertyChanged(nameof(Code)); } }
        

        public TgAuthViewModel(TelegramClient client)
        {
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
            if ( string.IsNullOrEmpty(Phone) || Phone.Length != 18) return false;

            return true;
        }

        private void SendCodeRequest()
        {
            try
            {
                client.SendCodeRequestAsync(Phone);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
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

        public ICommand Aunteficate
        {
            get
            {
                return new RelayCommand( obj =>
                { 
                    
                });
            }
        }
    }
}
