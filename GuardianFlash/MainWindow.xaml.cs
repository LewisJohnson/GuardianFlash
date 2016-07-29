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

namespace GuardianFlash
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            MouseDown += Window_MouseDown;
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void readButton_Click(object sender, RoutedEventArgs e)
        {
            ListWindow newWindow = new ListWindow();
            newWindow.Show();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            ReadWindow newWindow = new ReadWindow();
            newWindow.Show();
        }

        private void manageButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
