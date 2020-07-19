using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MultyMessager.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        
        private Page currentPage;
        public Page CurrentPage { get => currentPage; set { currentPage = value; OnPropertyChanged(nameof(CurrentPage)); } }


        private Page MainPage;
        private Page SignInPage;
        private Page SignUpPage;


        public MainWindowViewModel()
        {
            MainPage = new Views.MainPage();

            CurrentPage = MainPage;
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
