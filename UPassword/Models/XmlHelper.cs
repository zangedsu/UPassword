using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;

namespace UPassword.Models
{
    internal class XmlHelper
    {
        public void DeleteElement(string TName)
        {
            XElement doc = XElement.Load("pdata.xml");
            doc.Elements("Password").Where(e => e.Attribute("name").Value == TName).Remove();
            doc.Save("pdata.xml");
        }

        //string namein, string datefromin, string datetoin, string aboutin, bool inprocessin
        public void AddRecord(string namein, string loginin, string passwordin, string phonein, string emailin, string urlin, string additionalin)
        {


            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("pdata.xml");
            XmlElement? xRoot = xDoc.DocumentElement;

            // создаем новый элемент person
            XmlElement pass = xDoc.CreateElement("Password");

            // создаем атрибут name
            XmlAttribute name = xDoc.CreateAttribute("name");

            // создаем элементы company и age
            XmlElement login = xDoc.CreateElement("Login");
            XmlElement password = xDoc.CreateElement("PasswordText");
            XmlElement phone = xDoc.CreateElement("Phone");
            XmlElement email = xDoc.CreateElement("Email");
            XmlElement url = xDoc.CreateElement("Url");
            XmlElement additional = xDoc.CreateElement("Additional");

            // создаем текстовые значения для элементов и атрибута
            XmlText nameText = xDoc.CreateTextNode(namein);
            XmlText loginText = xDoc.CreateTextNode(loginin);
            XmlText passwordText = xDoc.CreateTextNode(passwordin);
            XmlText phoneText = xDoc.CreateTextNode(phonein);
            XmlText emailText = xDoc.CreateTextNode(emailin);
            XmlText urlText = xDoc.CreateTextNode(urlin);
            XmlText additionalText = xDoc.CreateTextNode(additionalin);

            //добавляем узлы
            name.AppendChild(nameText);
            login.AppendChild(loginText);
            password.AppendChild(passwordText);
            phone.AppendChild(phoneText);
            email.AppendChild(emailText);
            url.AppendChild(urlText);
            additional.AppendChild(additionalText);


            // добавляем атрибут name
            pass.Attributes.Append(name);
            // добавляем остальные элементы
            pass.AppendChild(login);
            pass.AppendChild(password);
            pass.AppendChild(phone);
            pass.AppendChild(email);
            pass.AppendChild(url);
            pass.AppendChild(additional);

            // добавляем в корневой элемент новый элемент person
            xRoot?.AppendChild(pass);
            // сохраняем изменения xml-документа в файл
            xDoc.Save("pdata.xml");

        }

        public void CheckDoubles(string namein)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("pdata.xml");

            foreach (XmlNode node in doc.DocumentElement)
            {
                string name = node.Attributes[0].Value;
                if (name == namein)
                {
                    throw new Exception("Нельзя создать задачу с таким же именем!");
                }

            }
        }//check doubles

        public void CheckName(string namein)
        {


            if (namein == null || namein == "")
            {
                throw new Exception("Имя проекта не может быть пустым!");
            }


        }//check doubles
    }
}
