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

namespace WpfApplication4
{
    /// <summary>
    /// Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        public Product ProductResult { get; private set; }


        public AddProductWindow()
        {
            InitializeComponent();
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("A név megadása kötelező");
                return;
            }
            if (string.IsNullOrEmpty(priceTextBox.Text))
            {
                MessageBox.Show("Az ár megadása kötelező");
                return;
            }
            var name = nameTextBox.Text;
            double price;
            if (!double.TryParse(priceTextBox.Text, out price))
            {
                MessageBox.Show("Az árnak egy valós számnak kell lennie");
                return;
            }

            ProductResult = new Product
            {
                Name = name,
                Price = price
            };

            DialogResult = true;
        }
    }
}
