using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UPassword.Models;
//Класс описывает хранилище записей
//ВНИМАНИЕ!!! Этот класс ещё не используется в проде.
//Прод работает на старом XmlHelper

[DataContract] // контракт данных для сериализации
internal class Storage
    {
    // коллекция Records - коллекция всех записей
    [DataMember]
    private List<Record> _records;
    public List<Record> Records
    {
        get => _records;
        private set => _records = value;
    } // Records - коллекция


    // Идентификатор (логин) хранилища
    [DataMember]
    private string _storageLogin;
    public string StorageLogin
    {
        get => _storageLogin;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Не корректный или пустой идентификатор хранилища");

            _storageLogin = value;
        }
    } // StorageLogin

    //_______________конструкторы_________________________

    public Storage(List<Record> records, string storageLogin) 
    { 
        Records= records;
        StorageLogin= storageLogin;
    }

    // индексатор 
    public Record this[int index]
    {
        get => _records[index];
        set => _records[index] = value;
    } // indexer

    // получить количество записей в коллекции
    public int Count => _records.Count;

    //добавление записи в коллекцию
    public void Add(Record record) => _records.Add(record);

    //удаление записи по её индексу
    public void RemoveAt(int index) => _records.RemoveAt(index);

    // упорядочивание копии коллекции по заданному компаратору
    public List<Record> OrderBy(Comparison<Record> comparison)
    {
        List<Record> ordered = new List<Record>(_records);
        ordered.Sort(comparison);
        return ordered;
    } // OrderBy

    // выборка данных из коллекции по заданному предикату
    public List<Record> Filter(Predicate<Record> predicate) =>
        _records.FindAll(predicate);
}

