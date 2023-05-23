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
    /// Логика взаимодействия для СтраницаАдминистратора.xaml
    /// </summary>
    public partial class СтраницаАдминистратора : Page
    {
        public СтраницаАдминистратора()
        {
            InitializeComponent();
           
            DGridSotr.ItemsSource = UserEntities.GetContext().Сотрудники.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Сотрудники hotelsForRemoving = (Сотрудники)DGridSotr.SelectedItems[0];

            hotelsForRemoving.Одобрено = true;
            try
            {
                UserEntities.GetContext().SaveChanges();
            }
            catch
            {

            }
        }
    }
}
