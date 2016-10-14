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
using System.Windows.Shapes;

namespace SimpleClientServer
{
    /// <summary>
    /// Interaction logic for Chatroom.xaml
    /// </summary>
    public partial class Chatroom : Window
    {
        private string username;
        Window creatingForm;
        public Chatroom()
        {
            InitializeComponent();
        }

        public Chatroom(string username)
        {
            InitializeComponent();
            this.username = username;
        }
        public Window setCreatingForm
        {
            get { return creatingForm; }
            set { creatingForm = value; }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (creatingForm != null)
                creatingForm.Close();
        }
    }
}
