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

namespace Programm.Страницы
{
    /// <summary>
    /// Логика взаимодействия для ВыборПользователя.xaml
    /// </summary>
    public partial class ВыборПользователя : Page
    {
        public ВыборПользователя()
        {
            InitializeComponent();
        }

        

        private void ButtonLichnoe(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new СтрЛичногоПосещения(null));
        }

        private void BtnGroupe(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new СтрГруппы(null));
        }
    }
}
