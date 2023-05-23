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
using ПриложениеСотрудников.Страница;

namespace ПриложениеСотрудников
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            int minutes = 5;
            DateTime tek = DateTime.Now;
            InitializeComponent();
            таймер.starting(minutes);
            AppConnect.model0db = new UserEntities();
            AppFrame.frameMain = FrmMain;

            FrmMain.Navigate(new Авторизация());
            label.Content = DateTime.Now.AddMinutes(minutes);
        }
    }
}
