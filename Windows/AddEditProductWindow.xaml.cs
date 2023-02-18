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

using CoffeeHouse9_14.ClassHelper;
using static CoffeeHouse9_14.ClassHelper.EFClass;
using CoffeeHouse9_14.Windows;

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
            cmbCategory.DisplayMemberPath = "Title";
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
            string ext = Path.GetExtension(pathPhoto);
            MessageBox.Show(ext);
            for (int i = 0; i < tbTitle.Text.Length; i++)
            {
                if (tbTitle.Text[i] >= '0')
                {
                    MessageBox.Show("В наименовании товаре не должно быть цифр");
                    break;
                }
            }
            for (int i = 0; i < tbCost.Text.Length; i++)
            {
                if (tbCost.Text[i] >= 'A')
                {
                    MessageBox.Show("Неверно введена цена");
                    break;
                }
            }
            if (string.IsNullOrWhiteSpace(tbCost.Text))
            {
                MessageBox.Show("Цена не можеет быть пустой");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbTitle.Text))
            {
                MessageBox.Show("Название товара не можеет быть пустым");
                return;

            }
          
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
