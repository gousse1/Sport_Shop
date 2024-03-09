using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sport_Shop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var currentUser = db.User.FirstOrDefault(p => p.login == Login1.Text && p.password == Password1.Password);

                if (currentUser != null)
                {
                    if (currentUser.type_user == "Admin" || currentUser.type_user == "admin" || currentUser.type_user == "Administrator" || currentUser.type_user == "administrator"
                        || currentUser.type_user == "Админ" || currentUser.type_user == "Администратор" || currentUser.type_user == "админ" || currentUser.type_user == "администратор")
                    {
                        DataGrid task = new DataGrid();
                        task.Show();
                        this.Close();
                    }
                    else
                    {
                        ListView task = new ListView();
                        task.Show();
                        this.Close();
                    }
                }
            }
        }

        private void BtnRegistr_Click(object sender, RoutedEventArgs e)
        {
            Registration taskWindow = new Registration();
            taskWindow.Show();
            this.Close();
        }
    }
}