using Microsoft.Win32;
using Programm.База;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
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
using static System.Net.Mime.MediaTypeNames;

namespace Programm.Страницы
{
    /// <summary>
    /// Логика взаимодействия для СтрЛичногоПосещения.xaml
    /// </summary>
    public partial class СтрЛичногоПосещения : Page
    {
        private UsersPrivateActivity текущееПосещение = new UsersPrivateActivity();
        
        private User profile = new User();
        private string Phototext = "";
        private string FileText = "";

        public СтрЛичногоПосещения(UsersPrivateActivity выбранноеПосещение)
        {

            InitializeComponent();
            cmbPodr.ItemsSource = new string[]{"Клиентское подразделение","Подразделение заявок","Подразделение приёмки" };
            cmbCel.ItemsSource = new string[] {"Познание","Обучение","Хобби" };
            
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
                    BitmapImage myBitmapImage = new BitmapImage();

                    myBitmapImage.BeginInit();
                    myBitmapImage.UriSource = new Uri(profile.Фото);


                    myBitmapImage.DecodePixelWidth = 200;
                    myBitmapImage.EndInit();



                    Picture.Source = myBitmapImage;
                }
                


            }





        }

        private void Загрузкафото(object sender, RoutedEventArgs e)
        {
            try
            {
                Phototext = "";
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == true)
                    Phototext = openFileDialog.FileName;

                System.Drawing.Image image1 = System.Drawing.Image.FromFile(Phototext);
                string result = System.IO.Path.GetFileName(Phototext);

                BitmapImage myBitmapImage = new BitmapImage();

                myBitmapImage.BeginInit();
                myBitmapImage.UriSource = new Uri(Phototext);


                myBitmapImage.DecodePixelWidth = 200;
                myBitmapImage.EndInit();



                Picture.Source = myBitmapImage;
            }
            catch
            {
                MessageBox.Show("Ошибка файла! Невозможно загрузить");
            }
            

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
            BitmapImage myBitmapImage = new BitmapImage();

            myBitmapImage.BeginInit();
            myBitmapImage.UriSource = new Uri("C:\\Users\\Хуй\\Desktop\\sourse\\Programm\\Programm\\Изображния\\1user.png");


            myBitmapImage.DecodePixelWidth = 200;
            myBitmapImage.EndInit();
            myFile.Content = "";



            Picture.Source = myBitmapImage;

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
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






            if (текущееПосещение.ID == 0)
                UserEntities.GetContext().UsersPrivateActivities.Add(текущееПосещение);

            try
            {
                текущееПосещение.Профиль = int.Parse(ser.Text+num.Text);
                текущееПосещение.Статус = "Создано";
                текущееПосещение.ДатаНачала = Convert.ToDateTime(startDate.Text);
                текущееПосещение.ДатаОкончания = Convert.ToDateTime(stopDate.Text);
                текущееПосещение.ДатаФормирования = DateTime.Now;
                текущееПосещение.ЦельПосещения = cmbCel.Text;
                текущееПосещение.Подразделение = cmbPodr.Text;
                текущееПосещение.Файл = myFile.Content.ToString();
                текущееПосещение.ФИОСотрудника =FIO.Text;
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

        private void cmbCel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            текущееПосещение.ЦельПосещения = cmbCel.Text;
        }

        private void cmbPodr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            текущееПосещение.ФИОСотрудника = cmbPodr.Text;
        }
    }
}
