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

namespace Language.UCs
{
    /// <summary>
    /// Логика взаимодействия для MainMenuUC.xaml
    /// </summary>
    public partial class MainMenuUC : UserControl
    {
        public MainMenuUC()
        {
            InitializeComponent();
        }

        private void ClientB_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.ChangeUC(mainWindow.Clients);
        }
    }
}
