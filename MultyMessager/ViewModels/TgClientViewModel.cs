using MultyMessager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TeleSharp.TL;
using TeleSharp.TL.Messages;
using TLSharp.Core;

namespace MultyMessager.ViewModels
{
    class TgClientViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        
        private TelegramClient tgClient;


        private TLImportedContact selectedContact;
        public TLImportedContact SelectedContact { get => selectedContact; set { selectedContact = value; OnPropertyChanged(nameof(SelectedContact)); } }


        public BindingList<TLAbsChat> Dialogs { get; set; }


        /// <summary>
        /// Конструктор ТГ-ВьюМодели 
        /// </summary>
        /// <param name="client">Авторизованный аккаунт клиента</param>
        public TgClientViewModel(TelegramClient client)
        {
            tgClient = client;

            FillDialogs();

            //tgClient.GetHistoryAsync(peer)
        }

        private void FillDialogs()
        {
            var dialogs = (TLDialogs)tgClient.GetUserDialogsAsync().Result;

            Dialogs = new BindingList<TLAbsChat>();
            foreach (var dialog in dialogs.Chats)
            {
                Dialogs.Add(dialog);
            }
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        //------------------ Commands ----------------------

    }
}
