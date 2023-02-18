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

namespace CoffeeHouse9_14.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void tblReg_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AuthorizationWindow auth = new AuthorizationWindow();
            this.Close();
            auth.Show(); ;
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < tbFname.Text.Length; i++)
            {
                if (tbFname.Text[i] >= '0' )
                {
                    MessageBox.Show("В имени не должно быть цифр");
                    break;
                }
            }
            if (string.IsNullOrWhiteSpace(tbLogin.Text))
            {
                MessageBox.Show("Логин не может быть пустым");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbFname.Text))
            {
                MessageBox.Show("Имя не может быть пустым");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbLname.Text))
            {
                MessageBox.Show("Фамилия не может быть пустым");
                return;
            }
            if (string.IsNullOrWhiteSpace(pbPass.Password))
            {
                MessageBox.Show("Пароль не может быть пустым");

                return;
            }
            if (string.IsNullOrWhiteSpace(dpBirthDay.Text))
            {

                MessageBox.Show("Дата не может быть пустой");
                return;
            }

            var authUser = context.Account.ToList()
                .Where(i => i.Login == tbLogin.Text && i.Password == pbPass.Password)
                .FirstOrDefault();
            if (authUser != null)
            {
                MessageBox.Show("Логин занят");
                return ;
            }
            DB.Account acc = new DB.Account();
            acc.Login = tbLogin.Text;
            acc.Password = pbPass.Password;
            acc.FirstName = tbFname.Text;
            acc.LastName = tbLname.Text;
            acc.Phone = tbPhone.Text;
            acc.Patronymic=tbPatronymic.Text;
            acc.BirthDay = dpBirthDay.SelectedDate.Value;
            context.Account.Add(acc);
            context.SaveChanges();
            MessageBox.Show("Ok");

        }
    }
    
}
