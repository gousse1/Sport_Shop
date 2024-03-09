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

namespace Sport_Shop
{
    /// <summary>
    /// Логика взаимодействия для DataGrid.xaml
    /// </summary>
    public partial class DataGrid : Window
    {
        public DataGrid()
        {
            InitializeComponent();
            using (ApplicationContext context = new ApplicationContext())
            {
                DGrid.ItemsSource = context.Product.ToList();
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEditPage taskWindow = new AddEditPage(null);
            taskWindow.Show();
            this.Close();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var ProductDel = DGrid.SelectedItems.Cast<Product>().ToList();
                {
                    if (MessageBox.Show("Вы уверены, что хотите удалить?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        db.Product.RemoveRange(ProductDel);
                        db.SaveChanges();
                        DGrid.ItemsSource = db.Product.ToList();
                    }
                }
            }

        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                AddEditPage taskWindow = new AddEditPage((sender as Button).DataContext as Product);
                taskWindow.Show();
                this.Close();
            }
        }
    }
}
