using SqlRocket.Database.Classes;
using SqlRocket.Database.Records;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SqlRocket
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _username;
        private string _password;
        private int _token;

        private List<Rocket> _rockets;
        private List<LaunchSite> _launchSites;
        private List<Launch> _launches;

        private bool _isModifying = false;
        private DatabaseHandler _dbHandler = new();

        private static readonly string[] _lists = new string[] { "Raketter", "Steder", "Opsendelser" };

        public MainWindow(string username, string password, int token)
        {
            _username = username;
            _password = password;
            _token = token;

            WindowState = WindowState.Maximized;
            InitializeComponent();

            var message = _dbHandler.Connect(_username, _password, _token);

            if (message is not null)
                MessageBox.Show(message);

            _rockets = _dbHandler.GetRockets(_username, _password, _token);
            _launchSites = _dbHandler.GetLaunchSites(_username, _password, _token);
            _launches = _dbHandler.GetLaunches(_username, _password, _token);

            DgdRockets.ItemsSource = _rockets;
            DgdLaunchSites.ItemsSource = _launchSites;
            DgdLaunches.ItemsSource = _launches;

            CmxTables.ItemsSource = _lists;
        }

        private void CmxTables_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch ((string)CmxTables.SelectedItem)
            {
                case "Raketter":
                    DgdRockets.Visibility = Visibility.Visible;
                    DgdLaunchSites.Visibility = Visibility.Hidden;
                    DgdLaunches.Visibility = Visibility.Hidden;

                    GbxRocket.Visibility = Visibility.Visible;
                    GbxSite.Visibility = Visibility.Hidden;
                    GbxLaunch.Visibility = Visibility.Hidden;

                    GbxRocket.Header = "Ny Raket";
                    BtnRocket.Content = "Opret Raket";
                    break;
                case "Steder":
                    DgdRockets.Visibility = Visibility.Hidden;
                    DgdLaunchSites.Visibility = Visibility.Visible;
                    DgdLaunches.Visibility = Visibility.Hidden;

                    GbxRocket.Visibility = Visibility.Hidden;
                    GbxSite.Visibility = Visibility.Visible;
                    GbxLaunch.Visibility = Visibility.Hidden;

                    GbxSite.Header = "Ny Sted";
                    BtnSite.Content = "Opret Sted";
                    break;
                case "Opsendelser":
                    DgdRockets.Visibility = Visibility.Hidden;
                    DgdLaunchSites.Visibility = Visibility.Hidden;
                    DgdLaunches.Visibility = Visibility.Visible;

                    GbxRocket.Visibility = Visibility.Hidden;
                    GbxSite.Visibility = Visibility.Hidden;
                    GbxLaunch.Visibility = Visibility.Visible;

                    GbxLaunch.Header = "Ny Opsendelse";
                    BtnLaunch.Content = "Opret Opsendelse";
                    break;
                default:
                    break;
            }

            _isModifying = false;
        }

        private void DgdRockets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _isModifying = true;

            GbxRocket.Header = "Redigere Raket";
            BtnRocket.Content = "Redigere Raket";
        }

        private void DgdLaunchSites_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _isModifying = true;

            GbxSite.Header = "Redigere Sted";
            BtnSite.Content = "Redigere Sted";
        }

        private void DgdLaunches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _isModifying = true;

            GbxLaunch.Header = "Redigere Opsendelse";
            BtnLaunch.Content = "Redigere Opsendelse";
        }
    }
}
