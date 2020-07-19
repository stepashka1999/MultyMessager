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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TLSharp.Core;
using MultyMessager.Views;
using MultyMessager.ViewModels;

namespace MultyMessager.Views
{
    /// <summary>
    /// Логика взаимодействия для TgAuthPage.xaml
    /// </summary>
    public partial class TgAuthPage : Page
    {
        public TgAuthPage(TelegramClient client)
        {
            InitializeComponent();
            DataContext = new TgAuthViewModel(client);
        }
    }
}
