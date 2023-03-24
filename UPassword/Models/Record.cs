using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UPassword.Models;
    //класс, описывающий одну запись в хранилище (Storage)
    //ВНИМАНИЕ!!! Этот класс ещё не используется в проде.
    //Прод работает на старом XmlHelper

    [DataContract] // контракт данных для сериализации
    internal class Record
    {
        //ИМЯ ЗАПИСИ
        [DataMember]
        private string _recordName;
        public string RecordName
        {
            get => _recordName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Название записи не может быть пустым!");

                _recordName = value;
            }
        } // ИМЯ ЗАПИСИ

        //ЛОГИН
        [DataMember]
        private string _login;
        public string Login
        {
            get => _login;
            set
            {
                _recordName = value;
            }
        } //ЛОГИН

        //ПАРОЛЬ
        [DataMember]
        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
            }
        } //ПАРОЛЬ

        //EMAIL
        [DataMember]
        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
            }
        } //EMAIL

        //НОМЕР ТЕЛЕФОНА
        [DataMember]
        private string _phone;
        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
            }
        } //НОМЕР ТЕЛЕФОНА

        //ДОПОЛНИТЕЛЬНАЯ ИНФОРМАЦИЯ
        [DataMember]
        private string _additional;
        public string Additional
        {
            get => _additional;
            set
            {
                _additional = value;
            }
        } //ДОПОЛНИТЕЛЬНАЯ ИНФОРМАЦИЯ

        //АДРЕС САЙТА
        [DataMember]
        private string _url;
        public string Url
        {
            get => _url;
            set
            {
                _url = value;
            }
        } //АДРЕС САЙТА

    //_______________конструкторы_________________________

    // валидируем данные при создании объекта
    public Record(string recordName, string login, string password, string phoneNumber, string email, string siteUrl, string addtionalInfo)
        {
            RecordName = recordName;
            Login = login;
            Password = password;
            Email = email;
            Phone = phoneNumber;
            Url= siteUrl;
            Additional = addtionalInfo;
        } // Record - конструктор

    }// Record - класс, представляющий одну запись

