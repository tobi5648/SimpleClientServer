namespace SimpleClientServer
{

    #region Usings
    using Controllers;
    using Entities;
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
    #endregion
    /// <summary>
    /// Interaction logic for LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        public LogInWindow()
        {
            InitializeComponent();
            
        }

        #region Fields
        LogOnController logon; 
        #endregion

        private void button_Click(object sender, RoutedEventArgs e)
        {
            logon = new LogOnController(txtUsername.Text, txtPassword.Text);

        }
    }
}
