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
using System.Windows.Navigation;

namespace MultyMessager.ViewModels
{
    class MainPageViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        
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
                    CurrentPage = new DefaultPage();
                });
            }
        }

        public ICommand SettingsPageCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    CurrentPage = new SettignsPage();
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
                        CurrentPage = new TgAuthPage(tgClient, (obj as Frame));
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
