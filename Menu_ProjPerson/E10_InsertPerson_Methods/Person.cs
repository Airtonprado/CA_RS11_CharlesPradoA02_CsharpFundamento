using D00_Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace E10_InsertPerson_Methods
{
    internal class Person
    {
        private static int nextId = 1;
        private static List<Person> listPerson = new List<Person>();

        #region Properties Person

        internal int Id { get; private set; }
        internal string Name { get; set; }

        internal Person() { }

        public Person(string name)
        {
            Id = nextId++;
            Name = name;
        }
        public void DisplayInfo()
        {
           // Console.WriteLine($"ID: {Id}, Nome: {Name}");
            var listind = Person.listPerson;
           
            int index = listind.FindIndex(p => p.Name == this.Name);
            if (index != -1)
            {
                Console.WriteLine($"Indice:{index},ID: {Id},Nome: {this.Name}");
            }
            else
            {
                Console.WriteLine($"Nome: {this.Name} não encontrado na lista.");
            }
        }
        /* public void DisplayInfo()
         {
             var list = Person.listPerson;
             Utility.WriteTitle("Lista de Pessoas:", "");
             for (int i = 0; i < list.Count; i++)
             {
                 Console.WriteLine($"{i + 1}. ID: {list[i].Id}, Nome: {list[i].Name}");
             }
         }*/

        #endregion


        #region 1. Add Person
        internal static void AddPerson()
        {

            for (int i = 0; i < 5; i++)
            {
                Utility.WriteMessage("Digite o nome da pessoa: ", "\n");
                string name = Console.ReadLine();
                listPerson.Add(new Person(name));
            }

            Utility.WriteTitle("Pessoas adicionadas com sucesso!");
            ListPerson();

            Utility.PauseConsole();

        }
        #endregion

        #region 2. Insert Person at Position
        internal static void InsertPosition()
        {
            ListPerson();
            Utility.WriteMessage("Digite o nome da pessoa a ser inserida: ", "\n");
            string name = Console.ReadLine();
            Utility.WriteMessage("Digite a posição (índice) onde a pessoa deve ser inserida: ", "\n");
            if (int.TryParse(Console.ReadLine(), out int position))
            {
                if (position >= 0 && position <= listPerson.Count)
                {
                    listPerson.Insert(position, new Person(name));
                    Console.WriteLine($"Pessoa '{name}' inserida na posição {position} com sucesso!");
                }
                else
                {
                    Console.WriteLine("Posição inválida. Certifique-se de inserir um índice válido.");
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida. Certifique-se de inserir um número inteiro.");
            }
            ListPerson();

        }
        #endregion

        #region 3. Find Person by ID
        internal static void FindPersonById()
        {
            ListPerson();
            Console.Write("Digite o ID da pessoa a ser encontrada: ");
            if (int.TryParse(Console.ReadLine(), out int nextId))
            {
                Person foundPerson = listPerson.Find(person => person.Id == nextId);
                if (foundPerson != null)
                {
                    foundPerson.DisplayInfo();
                }
                else
                {
                    Console.WriteLine($"Não foi encontrada nenhuma pessoa com o ID {nextId}.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido. Certifique-se de inserir um número inteiro.");
            }
            Utility.PauseConsole();
        }
        #endregion

        #region 4. Remove Person
        internal static bool RemovePerson(int id)
        {
            Person personToRemove = listPerson.Find(person => person.Id == id);
            if (personToRemove != null)
            {
                listPerson.Remove(personToRemove);
                Console.WriteLine($"Pessoa com ID {id} removida com sucesso!");
                return true;
            }
            else
            {
                Console.WriteLine($"Não foi encontrada nenhuma pessoa com o ID {id}.");
                return false;
            }
        }
        #endregion

        #region 5. Sort List by ID
        internal static void SortListById()
        {
            listPerson.Sort((person1, person2) => person1.Id.CompareTo(person2.Id));
            Console.WriteLine("Lista ordenada por ID.");
            ListPerson();
            Utility.PauseConsole();
        }
        #endregion

        #region 6. Sort List by Name
        internal static void SortListByName()
        {
            listPerson.Sort((person1, person2) => person1.Name.CompareTo(person2.Name));
            Console.WriteLine("Lista ordenada por nome.");
            ListPerson();

        }
        #endregion

        #region 7. List Persons
        internal static void ListPerson()
        {
            foreach (Person person in listPerson)
            {
                person.DisplayInfo();
            }
            Utility.PauseConsole();
        }
        #endregion

    }
}
