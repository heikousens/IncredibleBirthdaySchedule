using IncredibleBirthdaySchedule.Domain.Entities;
using IncredibleBirthdaySchedule.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IncredibleBirthdaySchedule.Infrastructure.Repositories
{
    public class TextFileRepository : IPersonRepository
    {

        private static List<Person> People = new List<Person>();
        public void Create(Person person)
        {
            var file = new StreamWriter(FilePath(), true);
            file.WriteLine(person.Id + ";" + person.FirstName + ";" + person.LastName + ";" + person.Birthday);
            file.Close();
        }

        public void Delete(Guid id)
        {
            var people = ListAll();
            List<Person> listPeople = new List<Person>();
            foreach (var person in people)
            {
                if (id != person.Id)
                {
                    listPeople.Add(person);
                }
            }
            DeleteAndCreateNew(listPeople);
        }

        public void DeleteAndCreateNew(List<Person> listPeople)
        {
            string fileName = FilePath();
            File.Delete(FilePath());
            FileStream file;
            if (!File.Exists(fileName))
            {
                file = File.Create(fileName);
                file.Close();
            }

            foreach (var person in listPeople)
            {
                Save(person);
            }
        }

        public void Save(Person person)
        {
            Create(person);
        }

        public IEnumerable<Person> ListAll()
        {
            var people = new List<Person>();

            string ifFileExists = FilePath();

            FileStream newFile;
            if (!File.Exists(ifFileExists))
            {
                newFile = File.Create(ifFileExists);
                newFile.Close();
            }
            var file = new StreamReader(FilePath());
            var line = file.ReadLine();

            while (line != null && line != "")
            {
                var peopleFields = line.Split(';');
                var person = new Person();

                person.Id = Guid.Parse(peopleFields[0]);
                person.FirstName = peopleFields[1];
                person.LastName = peopleFields[2];
                person.Birthday = DateTime.Parse(peopleFields[3]);

                people.Add(person);

                line = file.ReadLine();
            }
            file.Close();

            return people;
        }

        public void Update(Person person)
        {
            var allPeople = ListAll();
            List<Person> listPeople = new List<Person>();
            foreach (var p in allPeople)
            {
                if (person.Id == p.Id)
                {
                    listPeople.Add(person);
                }
                else
                {
                    listPeople.Add(p);
                }
            }
            DeleteAndCreateNew(listPeople);
        }

        public string FilePath()
        {
            var filepath = Environment.SpecialFolder.Desktop;

            string fileDesktop = Environment.GetFolderPath(filepath);
            string fileName = @"\AnaCarolina_MeloPereira_AT.csv";

            return fileDesktop + fileName;
        }
    }
}
