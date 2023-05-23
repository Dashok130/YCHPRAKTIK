using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;


namespace ПриложениеСотрудников.База
{
    public class таймер
    {
        static public int minutes;
        static public int last=0;
        public static void starting(int min)
        {
            minutes = min;

            for(int i = minutes*60; i > 0; i--)
            {
                DispatcherTimer timer = new DispatcherTimer();
                timer.Tick += new EventHandler(timer_Tick);
                timer.Interval = new TimeSpan(0, 0, minutes*60);
                timer.Start();
            }

            
        }
       
 
//...
 
static private void timer_Tick(object sender, EventArgs e)
        {

            Application.Current.Shutdown();

        }
        

    }
}
