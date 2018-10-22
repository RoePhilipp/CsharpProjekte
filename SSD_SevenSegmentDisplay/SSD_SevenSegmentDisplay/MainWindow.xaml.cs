using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
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
using System.Threading;

namespace SSD_SevenSegmentDisplay
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        byte[] ssdCodes;
        public MainWindow()
        {
            InitializeComponent();
            ssdCodes = new byte[]{ 0x7E,  0x30, 0x6D, 0x79, 0x33, 0x5B, 0x5F, 0x70, 0x7F, 0x7B};
        }

        void SetVals(byte val)
        {
            //ERKLÄRUNG: Color.FromRgb(0, 0, 0) = Schwarz; Color.FromRgb(255, 0, 0) = Rot
            //0x30 in binär = 0110000, 0x30 >> 6 = 0, 0 & 1 = 0, 0*255 ist null also farbe bleibt schwarz,
            //anders bei 0x30 >> 5 = 1, 1 & 1 = 1, 1*255 = 255 also farbe rot, dadurch werden die einzelnen segmente "beleuchtet"
            a.Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(255 * (val >> 6 & 1)), 0, 0));
            b.Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(255 * (val >> 5 & 1)), 0, 0));
            c.Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(255 * (val >> 4 & 1)), 0, 0));
            d.Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(255 * (val >> 3 & 1)), 0, 0));
            e.Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(255 * (val >> 2 & 1)), 0, 0));
            f.Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(255 * (val >> 1 & 1)), 0, 0));
            g.Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(255 * (val >> 0 & 1)), 0, 0));
         }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            SetVals(ssdCodes[1]);
        }

        private async void btnStartCUp_Click(object sender, RoutedEventArgs e)
        {
            bool loop = true;
            int count = 0;
            while (loop)
            {
                if(count > 9)
                {
                    count = 0;
                }
                SetVals(ssdCodes[count]);
                count++;
                await Task.Delay(1000);
            }
                
        }
    }
}
