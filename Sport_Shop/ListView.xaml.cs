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
    /// Логика взаимодействия для ListView.xaml
    /// </summary>
    public partial class ListView : Window
    {
        public ListView()
        {
            InitializeComponent();
            using (ApplicationContext db = new ApplicationContext())
            {
                var currentList = db.Product.ToList();
                LView.ItemsSource = currentList;
            }
        }

        private void TBox_Search(object sender, TextChangedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var currentMovies = db.Product.ToList();
                currentMovies = currentMovies.Where(p => p.category.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
                LView.ItemsSource = currentMovies.OrderBy(p => p.id_product).ToList();

            }
        }

        private void BtnFiltration_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var currentProduct = db.Product.ToList();
                currentProduct = currentProduct.Where(p => p.category.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
                LView.ItemsSource = currentProduct.OrderBy(p => p.price).ToList();
            }
        }

        private void BtnFiltration2_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var currentProduct = db.Product.ToList();
                currentProduct = currentProduct.Where(p => p.category.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
                LView.ItemsSource = currentProduct.OrderByDescending(p => p.price).ToList();
            }
        }

        private void BtnReservation_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
