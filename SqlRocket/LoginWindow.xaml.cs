using SqlRocket.Login.Classes;
using System.Windows;

namespace SqlRocket
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private MainWindow? _mainWindow;

        public LoginWindow()
        {
            WindowStyle = WindowStyle.None;
            ResizeMode = ResizeMode.NoResize;

            InitializeComponent();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            var Token = LoginHandler.VerifyUser(TbxUsername.Text, TbxPassword.Password);

            if (Token is not null)
            {
                _mainWindow = new MainWindow(TbxUsername.Text, TbxPassword.Password, (int)Token);

                _mainWindow.Show();

                Close();
            }
        }
    }
}
