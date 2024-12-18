using System;

namespace ClassLibrary
{
    public class Worker
    {
        public string FullName { get; set; }
        public string HomeCity { get; set; }
        public DateTime StartDate { get; set; }
        public Company WorkPlace { get; set; }

        public decimal BonusInUAH { get; private set; }

        public Worker() { }

        public Worker(string fullName, string homeCity, DateTime startDate, Company workPlace)
        {
            FullName = fullName;
            HomeCity = homeCity;
            StartDate = startDate;
            WorkPlace = workPlace;
        }

        public Worker(Worker other)
        {
            FullName = other.FullName;
            HomeCity = other.HomeCity;
            StartDate = other.StartDate;
            WorkPlace = new Company(other.WorkPlace);
            BonusInUAH = other.BonusInUAH;
        }

        public int GetWorkExperience()
        {
            return (DateTime.Now.Year - StartDate.Year) * 12 + DateTime.Now.Month - StartDate.Month;
        }

        public bool LivesNotFarFromTheMainOffice()
        {
            return string.Equals(HomeCity, WorkPlace.MainOfficeCity, StringComparison.OrdinalIgnoreCase);
        }

        public void SetBonus()
        {
            Console.WriteLine("\nОберіть валюту для введення премії:");
            Console.WriteLine("1 - Гривні (UAH)");
            Console.WriteLine("2 - Долари (USD)");
            Console.WriteLine("3 - Євро (EUR)");
            Console.Write("Ваш вибір: ");
            int choice = int.Parse(Console.ReadLine() ?? "1");

            Console.Write("Введіть суму премії: ");
            decimal bonus = decimal.Parse(Console.ReadLine() ?? "0");

            switch (choice)
            {
                case 2: 
                    BonusInUAH = bonus * 36.6m; 
                    break;
                case 3: 
                    BonusInUAH = bonus * 39.2m; 
                    break;
                default: 
                    BonusInUAH = bonus;
                    break;
            }
        }

        public void PrintBonusInAllCurrencies()
        {
            decimal bonusInUSD = BonusInUAH / 36.6m;
            decimal bonusInEUR = BonusInUAH / 39.2m;

            Console.WriteLine($"\nПремія для {FullName}:");
            Console.WriteLine($"- Гривні: {BonusInUAH:F2} UAH");
            Console.WriteLine($"- Долари: {bonusInUSD:F2} USD");
            Console.WriteLine($"- Євро: {bonusInEUR:F2} EUR");
        }

        public override string ToString()
        {
            return $"\nІм'я: {FullName}\n" +
                   $"Місто проживання: {HomeCity}\n" +
                   $"Дата початку роботи: {StartDate.ToShortDateString()}\n" +
                   $"Компанія: {WorkPlace.Name}\n" +
                   $"Головний офіс: {WorkPlace.MainOfficeCity}\n" +
                   $"Посада: {WorkPlace.Position}\n" +
                   $"Зарплата: {WorkPlace.Salary}\n" +
                   $"Повний робочий день: {(WorkPlace.IsFullTimeEmployee ? "Так" : "Ні")}\n" +
                   $"Стаж роботи (місяців): {GetWorkExperience()}\n" +
                   $"Проживає поруч із головним офісом: {(LivesNotFarFromTheMainOffice() ? "Так" : "Ні")}\n" +
                   $"Премія (грн): {BonusInUAH:F2}";
        }
    }
}
