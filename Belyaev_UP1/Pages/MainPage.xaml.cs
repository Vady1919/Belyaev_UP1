using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
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
using ZXing;

namespace Belyaev_UP1.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        Worker worker;
        public MainPage(Worker worker)
        {
            InitializeComponent();

            this.worker = worker;

            if (worker.WorkerRole == 1)
            {
                lblUserRole.Content = "Текущая роль: менеджер";
            }
            else
            {
                lblUserRole.Content = "Текущая роль: пользователь";
            }

            try
            {
                System.Drawing.Image img = null;
                BitmapImage bimg = new BitmapImage();
                using (var ms = new MemoryStream())
                {
                    BarcodeWriter writer;
                    writer = new ZXing.BarcodeWriter() { Format = BarcodeFormat.QR_CODE };
                    writer.Options.Height = 80;
                    writer.Options.Width = 280;
                    writer.Options.PureBarcode = true;
                    img = writer.Write("https://otzovik.com");
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    ms.Position = 0;
                    bimg.BeginInit();
                    bimg.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    bimg.CacheOption = BitmapCacheOption.OnLoad;
                    bimg.UriSource = new Uri("https://otzovik.com");
                    bimg.StreamSource = ms;
                    bimg.EndInit();
                    this.imgbarcode.Source = bimg;// return File(ms.ToArray(), "image/jpeg");  
                    //this.tbkbarcodecontent.Text = tbkbarcodecontent.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void AddApplication_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddAppPage(worker));
        }

        private void EditApplication_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditAppPage(worker));
        }

        private void TrackingApplication_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TrackingAppStatusPage());
        }

        private void Statistic_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StatisticPage());
        }
    }
}


