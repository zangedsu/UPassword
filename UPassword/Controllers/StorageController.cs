using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UPassword.Models;
using Newtonsoft.Json;
using System.IO;

namespace UPassword.Controllers;
//Это класс - контроллер для управления хранилищем данных (Класс Storage)
    internal class StorageController
    {
    //объект класса хранилища для обработки
    private Storage _storage;

    //свойство
    public Storage Storage
    {
        get => _storage;
        private set => _storage = value;
    } // ХРАНИЛИЩЕ

    //имя файла для хранения данных
    public string DataFileName { get; set; }

    //_______________конструкторы_________________________

    public StorageController(Storage storage, string fileName) 
    {
    _storage= storage;
    DataFileName= fileName;
    }//ctor

    //ЗАПРОСЫ:

    // Запрос на упорядочивание коллекции по названию
    public void OrderByRecordName() => Storage.OrderBy((t1, t2) =>
        t1.RecordName.CompareTo(t2.RecordName));

    // Запрос на выборку в коллекцию записей с заданным URL
    public List<Record> SelectWhereUrl(string siteUrl) =>
        _storage.Filter(t => t.Url == siteUrl);

    // список сайтов
    public List<string> GetUrls()
    {
        Dictionary<string, int> urls = new Dictionary<string, int>();

        _storage.Records.ForEach(t => urls[t.Url] = 0);

        return urls.Keys.ToList();
    } // GetUrls

    // -----------------------------------------------------------------------------------

    // сериализация данных в формате JSON - реализация NewtonSoft
    public void SerializeData()
    {
        // Формирование строки JSON
        string jsonData = JsonConvert.SerializeObject(_storage, Newtonsoft.Json.Formatting.Indented);

        // Запись объекта в JSON-файл
        File.WriteAllText(DataFileName, jsonData, Encoding.UTF8);
    } // SerializeDataNs

    // десериализация данных из формата JSON - реализация NewtinSoft
    public void DeserializeData()
    {
        // прочитать в строку из текстового файла
        string jsonData = File.ReadAllText(DataFileName, Encoding.UTF8);

        // парсинг в коллекцию из JSON-строки
        // ! в конце строки означает подавление предупреждения компилятора 
        // о возможном NullReference
        _storage = JsonConvert.DeserializeObject<Storage>(jsonData)!;
    } // DeserializeDataNs
}

