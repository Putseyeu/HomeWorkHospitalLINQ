using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkHospitalLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hospital hospital = new Hospital();
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine("\n1 - Список пациентов." +
                    " \n2 - Отсортировать всех больных по Фамилии." +
                    " \n3 - Отсортировать всех больных по возрасту." +
                    " \n4 - Вывести больных с определенным заболеванием." +
                    " \n5 - Выход.");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        hospital.ShowAllSick();
                        break;

                    case "2":
                        hospital.SortBySurname();
                        break;

                    case "3":
                        hospital.SortByAge();
                        break;

                    case "4":
                        hospital.ShowPatientsByDisease();
                        break;

                    case "5":
                        isWork = false;
                        break;
                }
            }
        }
    }

    class Hospital
    {
        private List<Sick> _sicks = new List<Sick>();

        public Hospital()
        {
            CreateList();
        }

        public void SortBySurname()
        {
            _sicks = _sicks.OrderBy(sicks => sicks.Surname).ToList();
        }

        public void SortByAge()
        {
            _sicks = _sicks.OrderBy(_sicks => _sicks.Age).ToList();
        }

        public void ShowAllSick()
        {
            ShowListSick(_sicks);
        }

        public void ShowPatientsByDisease()
        {
            Console.Write("Введите заболевание: ");
            string disease = Console.ReadLine();
            var sicksSortByDisease = _sicks.Where(sicks => sicks.Disease.ToLower() == disease.ToLower()).ToList();

            if (sicksSortByDisease.Count == 0)
            {
                Console.WriteLine("Пациентов c такой болезнью нету.");
            }
            else
            {
                ShowListSick(sicksSortByDisease);
            }
        }

        private void ShowListSick(List<Sick> sicks)
        {
            foreach (var sick in sicks)
            {
                sick.ShowInfo();
            }
        }

        private void CreateList()
        {
            _sicks.Add(new Sick("Евгений", "Жыкавец", "Анатольевичь", 18, "астма"));
            _sicks.Add(new Sick("Николай", "Акавец", "Петровичь", 22, "бронхит"));
            _sicks.Add(new Sick("Виктория", "Пукавец", "Ивановна", 62, "оспа"));
            _sicks.Add(new Sick("Мария", "Кукавец", "Ивановна", 45, "ветрянка"));
            _sicks.Add(new Sick("Светлана", "Вукавец", "Ивановна", 40, "перелом"));
            _sicks.Add(new Sick("Никита", "Бикитин", "Никитич", 22, "гангрена"));
            _sicks.Add(new Sick("Елена", "Лукавец", "Ивановна", 53, "оспа"));
            _sicks.Add(new Sick("Лариса", "Гедотава", "Сергеевна", 63, "ковид"));
            _sicks.Add(new Sick("Евгений", "Фыкавец", "Петровичь", 19, "геморой"));
            _sicks.Add(new Sick("Илья", "Дебедев", "Петровичь", 121, "гайморит"));
        }
    }

    class Sick
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Patronymic { get; private set; }
        public int Age { get; private set; }
        public string Disease { get; private set; }

        public Sick(string name, string surname, string patronymic, int age, string disease)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Age = age;
            Disease = disease;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"ФИО : {Name} {Surname} {Patronymic} | Возвраст - {Age} | Заболевание - {Disease}");
        }
    }
}
