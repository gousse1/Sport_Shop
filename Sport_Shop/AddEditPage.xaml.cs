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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Window
    {
        private Product product = new Product();
        public AddEditPage(Product selectedProduct)
        {
            InitializeComponent();

            if (selectedProduct != null)
            {
                product = selectedProduct;
            }
            DataContext = product;
        }


        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Product product_ = DataContext as Product;
                if (product_ != null)
                {
                    db.Product.Update(product_);
                    db.SaveChanges();
                    MessageBox.Show("Сохранено");
                    DataGrid win = new DataGrid();
                    win.Show();
                    this.Close();
                }
            }
        }
        private void BtnCancel2_Click(object sender, RoutedEventArgs e)
        {
            DataGrid task = new DataGrid();
            task.Show();
            this.Close();
        }
    }
}
