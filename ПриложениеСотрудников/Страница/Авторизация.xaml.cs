using Programm.База;
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
using ПриложениеСотрудников.База;

namespace ПриложениеСотрудников.Страница
{
    /// <summary>
    /// Логика взаимодействия для Авторизация.xaml
    /// </summary>
    public partial class Авторизация : Page
    {
        public Авторизация()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = AppConnect.model0db.Сотрудники.FirstOrDefault(x => x.Логин == txbLogin.Text && x.Пароль == psbPassword.Text);
                if (userObj == null)
                {
                    MessageBox.Show("Такого пользователя нет!", "Ошибка при авторизации!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    Профиль.профиль = userObj;
                    switch (userObj.Подразделение.ToString())
                    {
                        case "Охрана":
                            AppFrame.frameMain.Navigate(new СтраницаОхранника());
                            break;
                        case "Общий отдел":
                            AppFrame.frameMain.Navigate(new СтраницаОбщегоОтдела());
                            break;
                        case "Подразделение":
                            AppFrame.frameMain.Navigate(new СтраницаПодразделений());
                            break;
                        case "Администратор":
                            AppFrame.frameMain.Navigate(new СтраницаАдминистратора());
                            break;
                        default:
                            MessageBox.Show("Ваше подразделение не опознано! Обратитесь в службу поддержки","Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
                            break;
                    }
                   
                    MessageBox.Show("Здраствуйте " + userObj.ФИО + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                 


                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка" + Ex.Message.ToString() + "Критическая работа приложения!",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void txbLogin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
