using MultyMessager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MultyMessager.ViewModels
{
    class DefaultPageViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
                
        private Message selectedMessage;
        public Message SelectedMessage { get => selectedMessage; set { selectedMessage = value; OnPropretyChanged(nameof(SelectedMessage)); } }

        BindingList<Message> Messages;

        public DefaultPageViewModel()
        {

        }

        private void OnPropretyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
