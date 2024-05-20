using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D00_Utility;

namespace E10_InsertPerson_Methods
{
    internal class PersonUtility
    {
        // Todo MRS: o método Menu está a fazer mais do que devia, tens de separar em métodos.
        public void Menu()
        {
            // Todo MRS: istoo SetUnicodeConsole() deve estar no Main() e não aqui.
            Utility.SetUnicodeConsole();
            
            Utility.WriteTitle("Menu Insert Person");

            // Todo MRS: no dicionário deves colocar as opções do menu e não teres 1 método para dizer opção 1, opção 2, ...
            Dictionary<int, Action> menuOptions = new Dictionary<int, Action>
            {
                { 1, ShowOption1 },
                { 2, ShowOption2 },
                { 3, ShowOption3 },
                { 4, ShowOption4 },
                { 5, ShowOption5 },
                { 6, ShowOption6 },
                { 7, ShowOption7 },
                { 8, ShowOption8 }
            };

            while (true)
            {
                Utility.WriteMessage("Escolha uma Opção:","\n");
                Utility.WriteMessage("1. Adicionar Pessoa", "");
                Utility.WriteMessage("2. Inserir Pessoa na Posição", "");
                Utility.WriteMessage("3. Encontrar Pessoa pelo ID", "");
                Utility.WriteMessage("4. Remover Pessoa pelo ID", "");
                Utility.WriteMessage("5. Ordenar Lista pelo ID", "");
                Utility.WriteMessage("6. Ordenar Lista pelo Nome", "");
                Utility.WriteMessage("7. Listar Pessoas", "");
                Utility.WriteMessage("8. Sair", "");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (menuOptions.ContainsKey(choice))
                    {
                        menuOptions[choice].Invoke();
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida. Tente novamente.");
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Tente novamente.");
                }
            }
        }

        // Todo MRS: estes métodos do menu deviam ser métodos da classe Person.
        static void ShowOption1()
        {
            // Todo MRS: evitar mandar mensagens ao user que não acrescentam valor
            Console.WriteLine("Você escolheu a Opção 1.");
            Person.AddPerson();
        }

        static void ShowOption2()
        {
            Console.WriteLine("Você escolheu a Opção 2.");
            Person.InsertPosition();
        }

        static void ShowOption3()
        {
            Console.WriteLine("Você escolheu a Opção 3.");
            Person.FindPersonById();
        }

        static void ShowOption4()
        {
            Console.WriteLine("Você escolheu a Opção 4.");
            Console.Write("Digite o ID da pessoa a ser removida: ");
            if (int.TryParse(Console.ReadLine(), out int idParaRemover))
            {
                Person.RemovePerson(idParaRemover);
            }
            else
            {
                Console.WriteLine("ID inválido. Certifique-se de inserir um número inteiro.");
            }
        }

        static void ShowOption5()
        {
            Console.WriteLine("Você escolheu a Opção 5 SortListById.");
            Person.SortListById();
        }

        static void ShowOption6()
        {
            Console.WriteLine("Você escolheu a Opção 6.");
            Person.SortListByName();
        }

        static void ShowOption7()
        {
            Console.WriteLine("Você escolheu a Opção 7.");
            Person.ListPerson();
        }

        static void ShowOption8()
        {
            Console.WriteLine("Você escolheu a Opção 8. Saindo do programa...");
            // Todo MRS: não usar Thread.Sleep(2000)
            Thread.Sleep(2000); // tempo para ler a mensagem
            Environment.Exit(0); // Encerra o programa
        }
    }
}
