using CoffeeHouse9_14.DB;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using CoffeeHouse9_14.ClassHelper;
using static CoffeeHouse9_14.ClassHelper.EFClass;
using CoffeeHouse9_14.Windows;
using CoffeeHouse9_14.DB;
using Microsoft.Win32;
using System.IO;


namespace CoffeeHouse9_14.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditProductWindow.xaml
    /// </summary>
    public partial class AddEditProductWindow : Window
    {
        private string pathPhoto = null;
        public AddEditProductWindow()
        {
            InitializeComponent();
            cmbCategory.SelectedIndex = 0;
            cmbCategory.DisplayMemberPath = "TypeName";
            cmbCategory.ItemsSource = context.Category.ToList();  
        }     

        private void btnChooseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                imgProduct.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                pathPhoto = openFileDialog.FileName;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            product.Title = tbTitle.Text;
            product.Cost = Convert.ToDecimal(tbCost.Text);
            product.IdCategory = (cmbCategory.SelectedItem as Category).Id;
            if (pathPhoto != null)
            {
                product.Image = File.ReadAllBytes(pathPhoto);
            }

            context.Product.Add(product);

            context.SaveChanges();
            MessageBox.Show("OK");
        }
    }
}
