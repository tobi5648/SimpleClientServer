using Controllers;
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

namespace SimpleClientServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtUsernameBox.Focus();
        }

        private void txtPasswordBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnLogIn_Click(sender, e);
            }
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            string message;
            LogOnController lc = new LogOnController(out message, txtUsernameBox.Text, txtPasswordBox.Text);
            MessageBox.Show(message, "Login message", MessageBoxButton.OK);
            Chatroom cr = new Chatroom(txtUsernameBox.Text);
            cr.setCreatingForm = this;
            cr.Show();
            Hide();
        }

        private void txtUsernameBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtPasswordBox.Focus();
            }
        }
    }
}
