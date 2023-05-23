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
    /// Логика взаимодействия для СтраницаОхранника.xaml
    /// </summary>
    public partial class СтраницаОхранника : Page
    {
        public СтраницаОхранника()
        {
            InitializeComponent();
            DGridKlients.ItemsSource = UserEntities.GetContext().UsersPrivateActivities.ToList();
            DGridKlients2.ItemsSource = UserEntities.GetContext().UsersGroupActivities.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            UsersPrivateActivity hotelsForRemoving = (UsersPrivateActivity)DGridKlients.SelectedItems[0];
            if (hotelsForRemoving.Статус == "Принято")
            {
                hotelsForRemoving.Статус = "Проведено";
                try
                {
                    UserEntities.GetContext().SaveChanges();
                }
                catch
                {

                }
            }
            else MessageBox.Show("Посещение не принято! Необходимо дождаться рассмотрения общего отдела");
        }

        private void BtnEdit_Click2(object sender, RoutedEventArgs e)
        {
            UsersGroupActivity hotelsForRemoving = (UsersGroupActivity)DGridKlients2.SelectedItems[0];
            if (hotelsForRemoving.Статус == "Принято")
            {
                hotelsForRemoving.Статус = "Проведено";
                try
                {
                    UserEntities.GetContext().SaveChanges();
                }
                catch
                {

                }
            }
            else MessageBox.Show("Посещение не принято! Необходимо дождаться рассмотрения общего отдела");
        }
    }
}
