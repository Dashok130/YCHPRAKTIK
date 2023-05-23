using Microsoft.Win32;
using Programm.База;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
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

namespace Programm.Страницы
{
    /// <summary>
    /// Логика взаимодействия для СтрГруппы.xaml
    /// </summary>
    public partial class СтрГруппы : Page
    {
        private UsersGroupActivity текущееПосещение = new UsersGroupActivity();

        private User profile = new User();
        private string Phototext = "";
        private string FileText = "";
        
        public СтрГруппы(UsersGroupActivity выбранноеПосещение)
        {
            InitializeComponent();
            cmbPodr.ItemsSource = new string[] { "Клиентское подразделение", "Подразделение заявок", "Подразделение приёмки" };
            cmbCel.ItemsSource = new string[] { "Познание", "Обучение", "Хобби" };
            if (выбранноеПосещение != null)
            {
                текущееПосещение = выбранноеПосещение;
                DataContext = текущееПосещение;
                cmbCel.Text = выбранноеПосещение.ЦельПосещения;
                cmbPodr.Text = выбранноеПосещение.Подразделение;
                profile = AppConnect.model0db.Users.FirstOrDefault(x => x.ID == текущееПосещение.Профиль);
                if (profile != null)
                {

                    famil.Text = profile.ФИО.Split(' ')[0];
                    ima.Text = profile.ФИО.Split(' ')[1];
                    otchestvo.Text = profile.ФИО.Split(' ')[3];
                    tel.Text = profile.НомерТелефона;
                    email.Text = profile.Email;
                    num.Text = profile.ДанныеПаспорта.Split(' ')[1];
                    ser.Text = profile.ДанныеПаспорта.Split(' ')[0];
                    dateRojd.Text = profile.ДатаРождения.ToString();
                    org.Text = profile.Организация;

                }
            }
            if (текущееПосещение.GroupID == 0)
                UserEntities.GetContext().UsersGroupActivities.Add(текущееПосещение);
           
            
        }
        
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FileText = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                FileText = openFileDialog.FileName;

            myFile.Content = FileText;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            startDate.Text = "";
            stopDate.Text = "";
            cmbCel.Text = "";
            cmbPodr.Text = "";
            FIO.Text = "";
            famil.Text = "";
            ima.Text = "";
            otchestvo.Text = "";
            tel.Text = "";
            email.Text = "";
            org.Text = "";
            prim.Text = "";
            dateRojd.Text = "";
            ser.Text = "";
            num.Text = "";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                UserEntities.GetContext().Users.Add(profile);
                profile.ФИО = famil.Text + " " + ima.Text + " " + otchestvo.Text;
                profile.НомерТелефона = tel.Text;
                profile.ДанныеПаспорта = ser.Text + " " + num.Text;
                profile.ДатаРождения = Convert.ToDateTime(dateRojd.Text);
                profile.Email = email.Text;
                profile.Организация = org.Text;
                profile.Фото = Phototext;

                UserEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация Профиля сохранена!");

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






            

            try
            {
                текущееПосещение.Профиль = int.Parse(ser.Text + num.Text);
                текущееПосещение.Статус = "Создано";
                текущееПосещение.ДатаВыезда = Convert.ToDateTime(startDate.Text);
                текущееПосещение.ДатаОкончания = Convert.ToDateTime(stopDate.Text);
                текущееПосещение.ДатаФормирования = DateTime.Now;
                текущееПосещение.ЦельПосещения = cmbCel.Text;
                текущееПосещение.Подразделение = cmbPodr.Text;
                текущееПосещение.Файл = myFile.Content.ToString();
                текущееПосещение.ФИОСотрудника = FIO.Text;
                текущееПосещение.Примечание = prim.Text;
                UserEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");

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
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
