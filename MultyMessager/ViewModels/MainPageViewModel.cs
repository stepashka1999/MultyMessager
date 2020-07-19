using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using TLSharp.Core;
using MultyMessager.Views;

namespace MultyMessager.ViewModels
{
    class MainPageViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // Pages
        #region Pages

        private Page DefaulltPage;
        private Page SettingsPage;
        private Page TgPage;

        #endregion




        // Clients
        #region Clients

        private TelegramClient tgClient;
        
        //TODO
        //
        // vkClient
        // wspClient
        // fbClient
        // another one

        #endregion



        private Page currentPage;
        public Page CurrentPage { get => currentPage; set { currentPage = value; OnPropertyChanged(nameof(CurrentPage)); } }
 

        public MainPageViewModel()
        {
            DefaulltPage = new Views.DefaultPage();
            SettingsPage = new Views.SettignsPage();
            TgPage = new Views.TgPage(tgClient);
        }

        //-------- Methods

        private void SetTgClient()
        {
            //Api_ID and Api_Hash
            var apiId = 1423015;
            var apiHash = "77382dc23a1bf4e4fe359e1e9c49db84";

            tgClient = new TelegramClient(apiId, apiHash);

            tgClient.ConnectAsync();
        }
    

        //-------- Commands

        public ICommand DefaultPageCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    CurrentPage = DefaulltPage;
                });
            }
        }

        public ICommand SettingsPageCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    CurrentPage = SettingsPage;
                });
            }
        }
        public ICommand TgPageCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if(tgClient == null)
                    {
                        SetTgClient();
                        CurrentPage = new TgAuthPage(tgClient);
                    }
                    else  CurrentPage = new TgPage(tgClient);

                });
            }
        }


        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
