using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using CoffeeHouse9_14.ClassHelper;
using static CoffeeHouse9_14.ClassHelper.EFClass;

namespace CoffeeHouse9_14.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void tblAuth_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RegistrationWindow reg = new RegistrationWindow();
            this.Close();
            reg.Show();
            
            
        }

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            var authUser = context.Account.ToList()
                .Where(i => i.Login== tbLogin.Text && i.Password== pbPass.Password)
                .FirstOrDefault();
            if (authUser != null)
            {
               MainWindow main=new MainWindow();
                
                main.Show();

            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }


        }
    }
}
