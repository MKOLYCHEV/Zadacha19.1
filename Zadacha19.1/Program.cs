using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha19._1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Computer> listComputer = new List<Computer>()
            {
                new Computer(){Code="A1B1", Name="Asus", ProcType="Intel Core i5", ProcFrequency=2.2, RAMSize=8, DiskMemorySize=512, GraphicsCardMemorySize=4, Price=87999, Amount=54},
                new Computer(){Code="C2D2", Name="Lenovo", ProcType="AMD Ryzen 5", ProcFrequency=3.3, RAMSize=16, DiskMemorySize=512, GraphicsCardMemorySize=6, Price=129999, Amount=27},
                new Computer(){Code="E3F3", Name="HP", ProcType="Intel Core i5", ProcFrequency=2.4, RAMSize=8, DiskMemorySize=256, GraphicsCardMemorySize=2, Price=79990, Amount=35},
                new Computer(){Code="G4H4", Name="Apple", ProcType="Apple M1", ProcFrequency=3.2, RAMSize=8, DiskMemorySize=512, GraphicsCardMemorySize=8, Price=149990, Amount=21},
                new Computer(){Code="I5J5", Name="Razer", ProcType="Intel Core i7", ProcFrequency=2.3, RAMSize=16, DiskMemorySize=512, GraphicsCardMemorySize=8, Price=181600, Amount=9},
                new Computer(){Code="K6L6", Name="DELL", ProcType="Intel Core i7", ProcFrequency=2.8, RAMSize=8, DiskMemorySize=512, GraphicsCardMemorySize=2, Price=84990, Amount=48}
            };

            Console.WriteLine("В наличии компьютеры со следующими типами процессоров:");
            List<string> ProcTypes = (from p in listComputer
                                      select p.ProcType)
                                      .Distinct()
                                      .ToList();
            int num = 1;
            foreach (string p in ProcTypes)
            {
                Console.WriteLine("   {0}. {1}.", num, p);
                num++;
            }
            Console.Write("Введите тип процессора (название типа целиком): ");
            string ProcTypeRead = Console.ReadLine();
            Console.WriteLine();
            List<Computer> list1 = (from l1 in listComputer
                                        where l1.ProcType == ProcTypeRead
                                        select l1).ToList();
            Console.WriteLine("С выбранным типом процессора доcтупны следующие компьютеры:");
            num = 1;
            foreach (Computer c in list1)
            {
                Console.WriteLine($"   {num}. Компьютер {c.Name} стоимостью {c.Price:N} у.е.");
                num++;
            }
            Console.WriteLine();


            Console.Write("Введите минимальный требуемый объем ОЗУ: ");
            double RUMSizeRead = Convert.ToDouble(Console.ReadLine());

            int countCompRAM = (from l2 in listComputer
                                    where l2.RAMSize >= RUMSizeRead
                                    select l2).Count();
            if (countCompRAM > 0)
            {
                List<Computer> list2 = (from l2 in listComputer
                                        where l2.RAMSize >= RUMSizeRead
                                        select l2).ToList();
                Console.WriteLine();
                Console.WriteLine("Список компьютеров с объемом ОЗУ не менее {0}:", RUMSizeRead);
                num = 1;
                foreach (Computer c in list2)
                {
                    Console.WriteLine($"   {num}. Компьютер {c.Name} стоимостью {c.Price:N} у.е. с объемом ОЗУ {c.RAMSize}.");
                    num++;
                }
            }
            else
            {
                Console.WriteLine("Компьютеры с объемом ОЗУ {0} и более не найдены", RUMSizeRead);
            }
            Console.WriteLine();


            List<Computer> list3 = (from l3 in listComputer
                                    orderby l3.Price ascending
                                    select l3).ToList();
            Console.WriteLine("Список компьютеров, отсортированный по возрастанию стоимости:");
            num = 1;
            foreach(Computer c in list3)
            {
                Console.WriteLine($"   {num}. {c.Name} стоимостью {c.Price:N} у.е.");
                num++;
            }
            Console.WriteLine();


            var list4 = (from l4 in listComputer
                                    group l4 by l4.ProcType).ToList();
            Console.WriteLine("Список компьютеров, сгруппированный по типу процессора:");
            foreach(IGrouping<string, Computer> t in list4)
            {
                Console.WriteLine($"   {t.Key}");
                num = 1;
                foreach (var c in t)
                {
                    Console.WriteLine($"     {num}. {c.Name} стоимостью {c.Price:N} у.е.");
                    num++;
                }
            }


            double minPrice = listComputer.Min(l => l.Price);
            double maxPrice = listComputer.Max(l => l.Price);
            Console.WriteLine();
            Computer min = list3.First();
            Computer max = list3.Last();
            Console.WriteLine("Компьютер {0} имеет наименьшую стоимость {1:N}.", min.Name, min.Price);
            Console.WriteLine("Компьютер {0} имеет наибольшую стоимость {1:N}.", max.Name, max.Price);
            Console.WriteLine();


            bool amount30 = listComputer.Any(a => a.Amount >= 30);
            if (amount30) Console.WriteLine("Есть компьютеры, количество которых не меньше 30 штук.");
            else Console.WriteLine("Нет компьютеров, количество которых превышает 29 штук.");

            Console.ReadKey();
        }
    }
    class Computer
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string ProcType { get; set; }
        public double ProcFrequency { get; set; }
        public double RAMSize { get; set; }
        public double DiskMemorySize { get; set; }
        public double GraphicsCardMemorySize { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
    }
}
