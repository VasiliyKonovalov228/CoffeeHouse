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
using static CoffeeHouse9_14.ClassHelper.EFClass;
using CoffeeHouse9_14.Windows;
using CoffeeHouse9_14.DB;

namespace CoffeeHouse9_14.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProductListWindow.xaml
    /// </summary>
    public partial class ProductListWindow : Window
    {
        public ProductListWindow()
        {
            InitializeComponent();
            GetProduct();
        }
        private void GetProduct()
        {
            List<Product> ProdList = new List<Product>();

            ProdList = context.Product.ToList();

            LvProductList.ItemsSource = ProdList;
        }
    }
}
