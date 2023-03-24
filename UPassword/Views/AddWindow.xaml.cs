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
using UPassword.Models;

namespace UPassword.Views
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        private XmlHelper _helper;
        public AddWindow()
        {
            InitializeComponent();
            _helper = new XmlHelper();
        }

        private void CmdSave(object sender, RoutedEventArgs e)
        {
            try
            {
                string siteUrl = ProtocolSelector.Text + UrlInput.Text;
                _helper.CheckDoubles(NameInput.Text);
                _helper.CheckName(NameInput.Text);
                // if (InProcessInput.Text == "") InProcessInput.Text = "Без статуса";
                _helper.AddRecord(NameInput.Text, LoginInput.Text, PasswordInput.Text, PhoneInput.Text, EmailInput.Text, siteUrl, AdditionalInput.Text);
                this.Close();
            }
            catch (Exception ex)
            { MessageBox.Show($"{ex.Message}"); }
            

        }

        private void ClickCancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
