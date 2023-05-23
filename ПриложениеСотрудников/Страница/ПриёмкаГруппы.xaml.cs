using Programm.База;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
    /// Логика взаимодействия для ПриёмкаГруппы.xaml
    /// </summary>
    public partial class ПриёмкаГруппы : Page
    {
        private UsersPrivateActivity текуший = new UsersPrivateActivity();


        private User profile = new User();
        public ПриёмкаГруппы(UsersPrivateActivity выбранный)
        {
           
            InitializeComponent();
            cmbPodr.ItemsSource = new string[] { "Клиентское подразделение", "Подразделение заявок", "Подразделение приёмки" };
            cmbCel.ItemsSource = new string[] { "Познание", "Обучение", "Хобби" };
            if (выбранный != null)
            {
                текуший = выбранный;
                DataContext = текуший;
            }
            if (выбранный != null)
            {
                текуший = выбранный;
                DataContext = текуший;
                cmbCel.Text = выбранный.ЦельПосещения;
                cmbPodr.Text = выбранный.Подразделение;
                string паспорт = "";
                string числоПаспорт = текуший.Профиль.ToString();
                for (int i = 0; i < числоПаспорт.Length; i++)
                {
                    if (i == 4)
                        паспорт += " ";
                    паспорт += числоПаспорт[i];
                }

                profile = AppConnect.model0db.Users.FirstOrDefault(x => x.ДанныеПаспорта == паспорт);
                if (profile != null)
                {

                    famil.Text = profile.ФИО.Split(' ')[0];
                    ima.Text = profile.ФИО.Split(' ')[1];
                    otchestvo.Text = profile.ФИО.Split(' ')[2];
                    tel.Text = profile.НомерТелефона;
                    email.Text = profile.Email;
                    num.Text = profile.ДанныеПаспорта.Split(' ')[1];
                    ser.Text = profile.ДанныеПаспорта.Split(' ')[0];
                    dateRojd.Text = profile.ДатаРождения.ToString();
                    org.Text = profile.Организация;

                }
            }
            try
            {
                var blackList = AppConnect.model0db.BlackLists.FirstOrDefault(x => x.IDUser == profile.ID);
                if (blackList != null)
                {
                    MessageBox.Show("Клиент в чёрном списке! отказ записи");
                    текуший.Статус = "Отказ";
                    try
                    {
                        текуший.Профиль = int.Parse(ser.Text + num.Text);


                        UserEntities.GetContext().SaveChanges();
                        


                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                        {
                            MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());
                            MessageBox.Show("");
                            foreach (DbValidationError err in validationError.ValidationErrors)
                            {
                                MessageBox.Show(err.ErrorMessage + "");
                            }
                        }
                    }
                    AppFrame.frameMain.Navigate(new СтраницаОбщегоОтдела());
                }
            }
            catch
            {

            }
            
        }

        private void ima_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void famil_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            текуший.Статус = "Отказ";
            try
            {
                текуший.Профиль = int.Parse(ser.Text + num.Text);


                UserEntities.GetContext().SaveChanges();



            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());
                    MessageBox.Show("");
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        MessageBox.Show(err.ErrorMessage + "");
                    }
                }
            }
            AppFrame.frameMain.Navigate(new СтраницаОбщегоОтдела());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                var blackList = AppConnect.model0db.BlackLists.FirstOrDefault(x => x.IDUser == profile.ID);
                if (blackList != null)
                {
                    MessageBox.Show("Клиент в чёрном списке! отказ записи");
                    текуший.Статус = "Отказ";
                    try
                    {
                        текуший.Профиль = int.Parse(ser.Text + num.Text);


                        UserEntities.GetContext().SaveChanges();



                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                        {
                            MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());
                            MessageBox.Show("");
                            foreach (DbValidationError err in validationError.ValidationErrors)
                            {
                                MessageBox.Show(err.ErrorMessage + "");
                            }
                        }
                    }
                    AppFrame.frameMain.Navigate(new СтраницаОбщегоОтдела());
                }
                else
                {
                    текуший.Статус = "Принято";
                    try
                    {
 

                        UserEntities.GetContext().SaveChanges();



                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                        {
                            MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());
                            MessageBox.Show("");
                            foreach (DbValidationError err in validationError.ValidationErrors)
                            {
                                MessageBox.Show(err.ErrorMessage + "");
                            }
                        }
                    }
                    AppFrame.frameMain.Navigate(new СтраницаОбщегоОтдела());
                }
            }
            catch
            {

            }
        }

        private void cmbCel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmbPodr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
