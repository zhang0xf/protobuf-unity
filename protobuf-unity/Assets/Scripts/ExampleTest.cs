using UnityEngine;
using Google.Protobuf.Examples.AddressBook;
using System.IO;
using Google.Protobuf;
using System;

public class ExampleTest : MonoBehaviour
{
    byte[] bytes;

    // Start is called before the first frame update
    void Start()
    {
        // Create a new person
        Person person = new Person
        {
            Id = 1,
            Name = "Foo",
            Email = "foo@bar",
            Phones = { new Person.Types.PhoneNumber { Number = "555-1212" } }
        };

        // using ��䶨��һ����Χ���ڴ˷�Χ��ĩβ���ͷŶ���
        // �ö������̳�IDisposable()�ӿ�
        using (MemoryStream stream = new MemoryStream())
        {
            // Save the person to a stream
            person.WriteTo(stream);
            bytes = stream.ToArray();
        }

        // д���ļ�
        using (var file = File.Create("Assets/Resources/Person.dat"))
        {
            person.WriteTo(file);
        }

        // ��ȡ�ļ�
        using (var file = File.OpenRead("Assets/Resources/Person.dat"))
        {
            Person person1 = Person.Parser.ParseFrom(file);

            // ��ӡ��Ϣ
            Debug.LogFormat("ID = {0}", person1.Id);
            Debug.LogFormat("Name = {0}", person1.Name);
            Debug.Log("-------------------------");
        }

        Person copy = Person.Parser.ParseFrom(bytes);

        AddressBook book = new AddressBook
        {
            People = { copy }
        };
        bytes = book.ToByteArray();

        // And read the address book back again
        AddressBook restored = AddressBook.Parser.ParseFrom(bytes);

        // The message performs a deep-comparison on equality:
        if (restored.People.Count != 1 || !person.Equals(restored.People[0]))
        {
            throw new Exception("There is a bad person in here!");
        }
        else 
        {
            foreach (Person _person in restored.People)
            {
                Debug.LogFormat("ID = {0}", _person.Id);
                Debug.LogFormat("Name = {0}", _person.Name);

                // Repeat PhoneNumber
                foreach (Person.Types.PhoneNumber phoneNumber in _person.Phones)
                {
                    switch (phoneNumber.Type)
                    {
                        case Person.Types.PhoneType.Mobile:
                            Debug.LogFormat("  Mobile phone #: {0}", phoneNumber.Number);
                            break;
                        case Person.Types.PhoneType.Home:
                            Debug.LogFormat("  Home phone #: {0}", phoneNumber.Number);
                            break;
                        case Person.Types.PhoneType.Work:
                            Debug.LogFormat("  Work phone #: {0}", phoneNumber.Number);
                            break;
                    }
                }
            }
        }
    }
}
