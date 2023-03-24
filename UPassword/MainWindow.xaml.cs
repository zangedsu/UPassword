using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using UPassword.Models;
using UPassword.Views;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace UPassword
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private XmlHelper _helper;
        public MainWindow()
        {
            InitializeComponent();
            _helper = new XmlHelper();
            LoadData();
           MakeBlur();
        }

        private void LoadData()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("pdata.xml");

            foreach (XmlNode node in doc.DocumentElement)
            {
                string name = node.Attributes[0].Value;
                string login = (node["Login"].InnerText);
                string password = (node["PasswordText"].InnerText);
                string phone = (node["Phone"].InnerText);
                string email = (node["Email"].InnerText);
                string url = (node["Url"].InnerText);
                string additional = (node["Additional"].InnerText);
                ListBox.Items.Add(new Password(name, login, password, phone, email, url, additional));
                //NameInput.Text, LoginInput.Text, PasswordInput.Text, PhoneInput.Text, EmailInput.Text, UrlInput.Text, AdditionalInput.Text

            }
        }

        private void MakeBlur()
        {
            BlurEffect blurEffect = new BlurEffect();
            blurEffect.Radius= 45;
            PasswordOutput.Effect= blurEffect;
            PassLabel.Effect= blurEffect;
            LoginLabel.Effect= blurEffect;
            LoginOutput.Effect= blurEffect;
            EmailLabel.Effect= blurEffect;
            EmailOutput.Effect= blurEffect;
            AdditionalLabel.Effect= blurEffect;
            AdditionalOutput.Effect= blurEffect;
            PhoneLabel.Effect= blurEffect;
            PhoneOutput.Effect= blurEffect;
            UrlLabel.Effect= blurEffect;
            UrlOutput.Effect= blurEffect;
            NameLabel.Effect= blurEffect;
            NameOutput.Effect= blurEffect;
            EditBtnCMD.Effect= blurEffect;
            DeleteBtnCMD.Effect= blurEffect;
            OpenUrlBtnCMD.Effect= blurEffect;
            PasswordOutput.IsEnabled= false;
            PassLabel.IsEnabled= false;
            LoginLabel.IsEnabled= false;
            LoginOutput.IsEnabled= false;
            EmailLabel.IsEnabled= false;
            EmailOutput.IsEnabled= false;
            AdditionalLabel.IsEnabled= false;
            AdditionalOutput.IsEnabled= false;
            PhoneLabel.IsEnabled= false;
            PhoneOutput.IsEnabled= false;
            UrlLabel.IsEnabled= false;
            UrlOutput.IsEnabled= false;
            NameLabel.IsEnabled= false;
            NameOutput.IsEnabled= false;
            EditBtnCMD.IsEnabled= false;
            DeleteBtnCMD.IsEnabled= false;
            OpenUrlBtnCMD.IsEnabled= false;
        }

        private void MakeNoBlur()
        {

            
            PassLabel.Effect = null;
            LoginLabel.Effect = null;
            LoginOutput.Effect = null;
            EmailLabel.Effect = null;
            EmailOutput.Effect = null;
            AdditionalLabel.Effect = null;
            AdditionalOutput.Effect = null;
            PhoneLabel.Effect = null;
            PhoneOutput.Effect = null;
            UrlLabel.Effect = null;
            UrlOutput.Effect = null;
            NameLabel.Effect = null;
            NameOutput.Effect= null;
            EditBtnCMD.Effect = null;
            DeleteBtnCMD.Effect = null;
            OpenUrlBtnCMD.Effect = null;
            PasswordOutput.IsEnabled = true;
            PassLabel.IsEnabled = true;
            LoginLabel.IsEnabled = true;
            LoginOutput.IsEnabled = true;
            EmailLabel.IsEnabled = true;
            EmailOutput.IsEnabled = true;
            AdditionalLabel.IsEnabled = true;
            AdditionalOutput.IsEnabled = true;
            PhoneLabel.IsEnabled = true;
            PhoneOutput.IsEnabled = true;
            UrlLabel.IsEnabled = true;
            UrlOutput.IsEnabled = true;
            NameLabel.IsEnabled = true;
            NameOutput.IsEnabled = true;
            EditBtnCMD.IsEnabled = true;
            DeleteBtnCMD.IsEnabled = true;
            OpenUrlBtnCMD.IsEnabled = true;
        }

        private void MakePanelBlur()
        {
            BlurEffect blurEffect = new BlurEffect();
            blurEffect.Radius = 15;
            MainWindow1.Effect = blurEffect;
        }

        private void MakePanelNoBlur()
        {
            MainWindow1.Effect = null;
        }




    

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox.SelectedIndex != -1)
            {
                NameOutput.Text = ListBox.SelectedItem.ToString();
                MakeNoBlur();

                XmlDocument doc = new XmlDocument();
                doc.Load("pdata.xml");

                foreach (XmlNode node in doc.DocumentElement)
                {
                    if (node.Attributes[0].Value == ListBox.SelectedItem.ToString())
                    {
                        LoginOutput.Text = node["Login"].InnerText.ToString();
                        PasswordOutput.Text = node["PasswordText"].InnerText.ToString();
                        PhoneOutput.Text = node["Phone"].InnerText.ToString();
                        EmailOutput.Text = node["Email"].InnerText.ToString();
                        UrlOutput.Text = node["Url"].InnerText.ToString();
                        AdditionalOutput.Text = node["Additional"].InnerText.ToString();
                    }//if

                }//foreach
            }//if listbox
        }

        private void ClickDelete(object sender, RoutedEventArgs e)
        {
            
            // deleteDialog.ShowDialog();5
            MakePanelBlur();
            try
            {

                string elename = ListBox.SelectedItem.ToString();

                if (elename.Equals("") || elename.Length.Equals(0)) { throw new Exception("Вы не выбрали поле для удаления"); }
                DeleteDialog deleteDialog = new DeleteDialog();
                if (deleteDialog.ShowDialog() == true)
                {
                    _helper.DeleteElement(elename);
                    // System.Windows.MessageBox.Show($"Будут удалены все елементы с именем {elename}");
                    ListBox.Items.Clear();
                    LoadData();
                    MakeBlur();

                }//if dialog
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Вы не выбрали запись для удаления");
            }
            MakePanelNoBlur();
        }

        private void ClickOpenUrl(object sender, RoutedEventArgs e)
        {
            try
            {
                if (UrlOutput.Text != "")
                {
                    Process.Start(new ProcessStartInfo { FileName = UrlOutput.Text, UseShellExecute = true });
                }
                else { throw new Exception("Адрес сайта не указан в данной записи"); }
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show("URL некорректен, пожалуйста, исправьте его" );
            }

           
        }

        private void ClickClose(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PassBoxClick(object sender, MouseButtonEventArgs e)
        {
            BlurEffect blurEffect = new BlurEffect();
            blurEffect.Radius= 100;
            PasswordOutput.Effect = blurEffect;
            PasswordOutput.Text = "ххххххххххххххххххх";
        }

        //когда курсор мыши в границах элемента - выключить размытие
        private void PassBoxMousEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            PasswordOutput.Effect = null;

        }

        //когда курсор покидает границу элемента - включить размытие
        private void PassBoxMouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            BlurEffect blurEffect = new BlurEffect();
            blurEffect.Radius = 10;
            PasswordOutput.Effect = blurEffect;
            

        }

        private void MainFormLoaded(object sender, RoutedEventArgs e)
        {

        }

        private void ClickSettings(object sender, RoutedEventArgs e)
        {
            var settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }

        private void CliclEditCmd(object sender, RoutedEventArgs e)
        {
            try
            {
                string elename = ListBox.SelectedItem.ToString();

                if (elename.Equals("") || elename.Length.Equals(0)) { throw new Exception("Вы не выбрали поле для редактирования"); }
                _helper.DeleteElement(elename);
                System.Windows.MessageBox.Show($"Запись {elename} будет изменена");

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Ошибка {ex.Message}");
            }

            try
            {
                _helper.CheckDoubles(NameOutput.Text);
                _helper.CheckName(NameOutput.Text);
                // if (InProcessInput.Text == "") InProcessInput.Text = "Без статуса";
                _helper.AddRecord(NameOutput.Text, LoginOutput.Text, PasswordOutput.Text, PhoneOutput.Text, EmailOutput.Text, UrlOutput.Text, AdditionalOutput.Text);
                ListBox.Items.Clear();
                LoadData();
            }
            catch (Exception ex)
            { System.Windows.MessageBox.Show($"{ex.Message}"); }
            MakeBlur();

        }

        private void ClickMinimize(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ClickAdd(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddWindow();
            MakePanelBlur();
            addWindow.ShowDialog();
            ListBox.Items.Clear();
            LoadData();
            MakePanelNoBlur();
        }

        private void ClickMaximiz(object sender, RoutedEventArgs e)
        {
            //WindowState = WindowState.Maximized;
            this.Width = SystemParameters.WorkArea.Width;
            this.Height = SystemParameters.WorkArea.Height;
            this.Left = 0;
            this.Top = 0;
        }





        //str
    }
}
