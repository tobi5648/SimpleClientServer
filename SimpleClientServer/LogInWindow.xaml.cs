namespace SimpleClientServer
{

    #region Usings
    using Controllers;
    using System.Windows;
    #endregion

    /// <summary>
    /// Interaction logic for LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        /// <summary>
        /// What happens when the window is opened
        /// </summary>
        public LogInWindow()
        {
            InitializeComponent();
            
        }

        #region Fields
        /// <summary>
        /// Used to access the controls for logon
        /// </summary>
        LogOnController logon;
        #endregion

        #region Button Clicks
        /// <summary>
        /// What happens when the logon button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            logon = new LogOnController(txtUsername.Text, txtPassword.Text);
        } 
        #endregion
    }
}
