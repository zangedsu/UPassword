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
using System.Windows.Shapes;
using System;
using System.Diagnostics;

namespace UPassword.Views
{
    /// <summary>
    /// Логика взаимодействия для SettingsForm.xaml
    /// </summary>
    public partial class SettingsForm : Window
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsFormLoaded(object sender, RoutedEventArgs e)
        {
            string procPath = null!;
            string osVer = Environment.OSVersion.Version.ToString();
            string usrName = Environment.UserName.ToString();
            OsVerText.Text = osVer;
            UsrNameText.Text = usrName;
            procPath = Environment.ProcessPath;
            if (procPath!=null)
            {
                ProcPathText.Text = procPath.ToString();
            }
            
        }

        private void ClickSaveAndClose(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClickCheckUpdate(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Сервер обновлений недоступен!!! Запросите файлы обновления у разработчика");
        }

        private void ClickWriteToDeveloper(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = "https://t.me/FDV_photo", UseShellExecute = true });
        }
    }
}
