using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Language
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static UserControl actualUC;
        public static Stack<UserControl> pastUC = new Stack<UserControl>();

        public MainWindow()
        {
            InitializeComponent();
            actualUC = Menu;
            pastUC.Push(actualUC);
        }

        public void ChangeUC(UserControl newUC)
        {
            if (actualUC == null)
            {
                Menu.Visibility = Visibility.Collapsed;
                newUC.Visibility = Visibility.Visible;
            }
            else
            {
                if (newUC == actualUC)
                    newUC.Visibility = Visibility.Collapsed;
                else
                {
                    actualUC.Visibility = Visibility.Collapsed;
                    newUC.Visibility = Visibility.Visible;
                }
            }
            if (pastUC.Peek() == newUC)
                pastUC.Pop();
            else
                pastUC.Push(actualUC);
            CheckStack();
            actualUC = newUC;
        }

        public static UserControl getPastUC()
        {
            return pastUC.Peek();
        }

        public static void CheckStack()
        {
            Trace.WriteLine("---------------");
            foreach (UserControl uc in pastUC)
            {
                Trace.WriteLine(uc.ToString());
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeUC(pastUC.Peek());
        }

        private void ClientB_Click(object sender, RoutedEventArgs e)
        {
            ChangeUC(Clients);
        }
    }
}
