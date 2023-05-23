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
    /// Логика взаимодействия для СтраницаПодразделений.xaml
    /// </summary>
    public partial class СтраницаПодразделений : Page
    {
        private BlackList клиент = new BlackList();
        public СтраницаПодразделений()
        {
            InitializeComponent();
            DGridKlient.ItemsSource = UserEntities.GetContext().Users.ToList();
            DataContext = клиент;
        }

       

        

        private void BtnEdit_Click2(object sender, RoutedEventArgs e)
        {
            User user = (User)DGridKlient.SelectedItems[0];
            
            
            
            
            try
            {
                
                
               
                UserEntities.GetContext().BlackLists.Add(клиент);
                клиент.Id = user.ID;

                UserEntities.GetContext().SaveChanges();
                MessageBox.Show("Успешно!");
            }
            catch
            {
                MessageBox.Show("Ошибка:(");
            }
           
        }
    }
}
