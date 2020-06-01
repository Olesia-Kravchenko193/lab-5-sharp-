using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5_sharp_
{
    class Program
    {
        public static List<Transport> list = new List<Transport>();
        delegate void Delegate();
        static Delegate deleg;
        public static Interface_Add edit;
        public static Interface_Delete delete = new Transport();
        static void Main(string[] args)
        {
            int item;
            do
            {
                Console.WriteLine("Выберите пункт:\n 1 - Добавить \n 2 - Удалить\n 3 - Просмотреть весь список\n 0 - Ввыход\n Введите: ");
                item = Convert.ToInt32(Console.ReadLine());
                Console.Write("\n");
                if (item == 1)
                {
                    do
                    {
                        Console.WriteLine("Добавить:\n 1 - Транспортное средство\n 2 - Автомобиль\n 3 - Поезд\n 4 - Экспресс\n 5 - Меню\n 0 - Выход\n Введите: ");
                        item = Convert.ToInt32(Console.ReadLine());
                        switch (item)
                        {
                            case 1:
                                edit = new Transport();
                                deleg = edit.Add;
                                deleg += Output;
                                deleg();
                                break;
                            case 2:
                                edit = new Car();
                                deleg = edit.Add;
                                deleg += Output;
                                deleg();
                                break;
                            case 3:
                                edit = new Train();
                                deleg = edit.Add;
                                deleg += Output;
                                deleg();
                                break;
                            case 4:
                                edit = new Express();
                                deleg = edit.Add;
                                deleg += Output;
                                deleg();
                                break;
                            case 5:
                                Console.Write("\n");
                                break;
                            case 0:
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Неверный ввод!\n");                               
                                break;                             
                        }
                    } while (item != 5);
                }
                if (item == 2)
                {
                    if(list.Count == 0)
                    {
                        Console.WriteLine("Список пуст!\n");
                    }
                    else
                    {
                        deleg = delete.Delete;
                        deleg();
                        if (list.Count>0)
                        {
                            Output();
                        }
                    }
                }
                if (item == 3)
                {
                    if (list.Count == 0)
                    {
                        Console.WriteLine("Список пуст!\n");
                    }
                    else
                    {                        
                       Output();
                    }
                }
                if (item == 0)
                {
                    Environment.Exit(0);
                }
                else if (item !=1 && item != 2 && item != 3 && item != 0 && item != 5)
                {
                    Console.WriteLine("Ошибка!\n");
                }
            } while (item != 0);
            Console.ReadKey();
        }
        public static void Output()
        {
            Console.WriteLine("Вся информация: \n");
            foreach (var action in list)
                Console.WriteLine(action);
            Console.Write("\n");
        }
    }
    interface Interface_Add
    {
        void Add();
    }
    interface Interface_Delete
    {
        void Delete();
    }

    class Transport : Interface_Add, Interface_Delete
    {
        private protected int Price { get; set; }
        private protected int Amount { get; set; }

        public Transport()
        {

        }
        public Transport(int price, int amount)
        {
            Price = price;
            Amount = amount;
        }
        void Interface_Add.Add()
        {
            Console.Write("Введите цену поездки: ");
            Price = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите количество мест: ");
            Amount = Convert.ToInt32(Console.ReadLine());
            Addition(Price, Amount);
        }
        void Interface_Delete.Delete()
        {
            int number;
            do
            {
                Console.WriteLine("Введите номер элемента, который хотите удалить: ");
                number = Convert.ToInt32(Console.ReadLine());
                
            } while (number < 0 || number >= Program.list.Count);
            Program.list.RemoveAt(number);
            Console.WriteLine("Удалено!\n");
        }
        public void Addition(int price, int amount)
        {
            Program.list.Add(new Transport(price, amount));
        }
        public override string ToString()
        {
            return $"Цена: {Price} грн, Количество: {Amount} мест";
        }
    }




    class Car : Transport, Interface_Add
    {
        private protected int Speed { get; set; }
        public Car()
        {

        }
        public Car( int price, int amount, int speed) : base(price,amount)
        {
            Speed = speed;
        }

        void Interface_Add.Add()
        {
            Console.Write("Введите цену поездки: ");
            Price = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите количество мест: ");
            Amount = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите скорость: ");
            Speed = Convert.ToInt32(Console.ReadLine());
            Addition(Price, Amount, Speed);
        }

        virtual public void Addition(int price, int amount, int speed)
        {
            Program.list.Add(new Car(price, amount, speed));
        }

        public override string ToString()
        {
            return base.ToString()+ $", Скорость: {Speed} км/ч";
        }
    }



    class Train : Car, Interface_Add
    {
        private protected int Time { get; set; }
        public Train()
        {

        }
        public Train(int price, int amount, int speed, int time) : base(price,amount,speed)
        {
            Time = time;
        }
        void Interface_Add.Add()
        {
            Console.Write("Введите цену поездки: ");
            Price = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите количество мест: ");
            Amount = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите скорость: ");
            Speed = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите время поездки: ");
            Time = Convert.ToInt32(Console.ReadLine());
            Addition(Price, Amount, Speed,Time);
        }
        public virtual void Addition(int price, int amount, int speed, int time)
        {
            Program.list.Add(new Train(price, amount, speed, time));
        }
        public override string ToString()
        {
            return base.ToString() + $", Время поездки: {Time} ч";
        }
    }



    class Express : Train, Interface_Add
    {
        private string Route { get; set; }
        public Express()
        {

        }
        public Express(int price, int amount, int speed, int time, string route) : base(price, amount, speed, time)
        {
            Route = route;
        }
        void Interface_Add.Add()
        {
            Console.Write("\nВведите цену поездки: ");
            Price = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите количество мест: ");
            Amount = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите скорость: ");
            Speed = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите время поездки: ");
            Time = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите маршрут: ");
            Route = Console.ReadLine();
            Additoin(Price, Amount, Speed, Time, Route);
        }
        public void Additoin(int price, int amount, int speed, int time, string route)
        {
            Program.list.Add(new Express( price, amount, speed, time, route));
        }
        public override string ToString()
        {
            return base.ToString() + $", Маршрут: {Route}";
        }
    }
}
