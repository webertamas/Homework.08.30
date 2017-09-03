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

namespace WpfApplication4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly List<Product> _products = new List<Product>();
        public MainWindow()
        {
            InitializeComponent();
            _products.Add(new Product
            {
                Name = "Tojás",
                Price = 40
            });
            productsListView.ItemsSource = _products;
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            var addProductWindow = new AddProductWindow();
            if(addProductWindow.ShowDialog() == true)
            {
                _products.Add(addProductWindow.ProductResult);
                productsListView.Items.Refresh();
            }

        }

        private void RemoveClick(object sender, RoutedEventArgs e)
        {

            if (productsListView.SelectedItem != null && MessageBox.Show(
            "Biztosan szeretnéd törölni?",
            "Törlés",
            MessageBoxButton.YesNo) ==
            MessageBoxResult.Yes)
            {
                _products.Remove(
                    (Product)productsListView.SelectedItem
                    );
                productsListView.Items.Refresh();
            }

            else
            {
                MessageBox.Show("Nincs semmi kiválasztva");
            }
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            var selectedItem = (Product)productsListView.SelectedItem;

            var editProductWindow = new EditProductWindow();
            editProductWindow.nameTextBox.Text = selectedItem.Name;
            editProductWindow.priceTextBox.Text = selectedItem.Price.ToString();

            if (editProductWindow.ShowDialog() == true)
            {
                //selectedItem = editProductWindow.ProductResult;
                //productsListView.SelectedItem = selectedItem;

                _products.Remove((Product)productsListView.SelectedItem);
                _products.Add(editProductWindow.ProductResult);
                
                productsListView.Items.Refresh();
            }
        }

        private void DeleteAllButtonClick(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Biztosan szeretnéd törölni?", "Törlés", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _products.Clear();
                productsListView.Items.Refresh();
            }
        }
    }
}
