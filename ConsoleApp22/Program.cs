using System;
using ConsoleApp9.MyPoint.test;
using sot.point;
using static System.Console;

namespace ConsoleApp9
{
    namespace MyPoint
    {
        namespace test
        {
            delegate void MyDelegate();
            class SourceEvent
            {
                public event MyDelegate ev;
                public void GeneratorEvent()
                {
                    Console.WriteLine("Произошло событие!");
                    ev?.Invoke();
                }
            }

            class Event
            {
                public void Put(int sum)
                {
                    Sum += sum;
                    ev?.Invoke($"На счет поступило: {sum}");  
                }
                public void Take(int sum)
                {
                    if (Sum >= sum)
                    {
                        Sum -= sum;
                        ev?.Invoke($"Со счета снято: {sum}");   
                    }
                    else
                    {
                        ev?.Invoke($"Недостаточно денег на счете. Текущий баланс: {Sum}"); ;
                    }
                }
                public void PIN()
                {
                    Console.WriteLine($"PIN: {P}");
                }
                public string P
                {
                    set
                    {
                        string pin = value;
                    }
                    get
                    {
                        return P;
                    }
                }
            }

            
            class Money
            {
                public int X { get; set; } = 1;

                public Money() { }
                public Money(int x)
                {
                    X = x;

                }
                public override string ToString()
                {
                    return $"Увеличено зарплату: {X}";
                }

                public static Money operator +(int a, Money b)
                {
                    return new Money(b.X + a);
                }
                public static Money operator -(int a, Money b)
                {
                    return new Money(b.X - a);
                }
                public static bool operator >(Money a, int b)
                {
                    if (a.X > 1000)
                    {
                        return true;
                    }
                    return false;
                }
                public static bool operator <(Money a, int b)
                {
                    return !(a > 1000);
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SourceEvent s = new SourceEvent();

            Event obj1 = new Event();
            Event obj2 = new Event();
            Event obj3 = new Event();

            s.ev += new MyDelegate(obj1.Put);
            s.ev += new MyDelegate(obj2.Take);
            s.ev += new MyDelegate(obj3.PIN);
            s.GeneratorEvent();

            Money m = new Money(1000);
            DateTime dt = new DateTime(2023, 09, 02);
            Credit cre = new Credit();
            String t = cre.fio;
            String[] words = t.Split(new char[] { ' ', ',' });
            Console.WriteLine("Запоните данные:");

            Console.Write("Введите номер каарты:");
            try
            {
                string n = cre.Number = Convert.ToString(Console.ReadLine());
                if (n.Length != 16)
                {
                    throw new Exception("Неверно введён номер карты");
                }
            }
            catch (Exception s)
            {
                Console.WriteLine(s.Message);
            }

            Console.Write("Введите ФИО владельца:");
            try
            {
                string f = cre.Fio = Convert.ToString(Console.ReadLine());
                if (words != 3)
                {
                    throw new Exception("Неверно введено ФИО");
                }
            }
            catch (Exception f)
            {
                Console.WriteLine(f.Message);
            }

            Console.Write("Введите CVC:");
            try
            {
                string c = cre.Cvc = Convert.ToString(Console.ReadLine());
                if (c.Length == 3)
                {
                    throw new Exception("Неверно введено cvc");
                }
            }
            catch (Exception c)
            {
                Console.WriteLine(c.Message);
            }

            Console.Write("Введите дату окончания работы карты:");
            try
            {
                string d = cre.Date = Convert.ToString(Console.ReadLine());
                if (d >= dt)
                {
                    throw new Exception("Неверно введена дата");
                }

            }
            catch (Exception d)
            {
                Console.WriteLine(d.Message);
            }

            cre.printcredit();
            WriteLine($"Затпрата: {m}");
        }
    }
    class Credit
    {
        public void printcredit()
        {
            Console.WriteLine($"Номер карты: {number}");
            Console.WriteLine($"ФИО владельца: {fio}");
            Console.WriteLine($"CVC: {cvc}");
            Console.WriteLine($"Дата завершения работы карты: {date}");
        }
        public string number = "0000000000000000";
        public string fio = "F I O";
        public string cvc = "000";
        public string date = "01.01.2000";

        public string Number
        {
            set
            {
                number = value;
            }
            get
            {
                return number;
            }
        }
        public string Fio
        {
            set
            {
                fio = value;
            }
            get
            {
                return fio;
            }
        }
        public string Cvc
        {
            set
            {
                cvc = value;
            }
            get
            {
                return cvc;
            }
        }
        public string Date
        {
            set
            {
                date = value;
            }
            get
            {
                return date;
            }
        }
    }
}
namespace sot
{
    namespace point
    {
        class money
        {
            public int X { get; set; } = 1;

            public money() { }
            public money(int x)
            {
                X = x;

            }
            public override string ToString()
            {
                return $"Увеличено зарплату: {X}";
            }

            public static money operator +(int a, money b)
            {
                return new money(b.X + a);
            }
            public static money operator -(int a, money b)
            {
                return new money(b.X - a);
            }
            public static bool operator >(money a, int b)
            {
                if (a.X > 1000)
                {
                    return true;
                }
                return false;
            }
            public static bool operator <(money a, int b)
            {
                return !(a > 1000);
            }
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        money m = new money(1000);
        FIO Fio = new FIO();
        Fio.printfio();

        WriteLine($"Затпрата: {m}");
    }
}
class FIO
{
    public void printfio()
    {
        Console.WriteLine($"ФИО: {fio}");
        Console.WriteLine($"Дата рождения: {date}");
        Console.WriteLine($"Телефон: {phone}");
        Console.WriteLine($"e-mail: {email}");
        Console.WriteLine($"Должность: {title}");
        Console.WriteLine($"Служебные обязаности: {resp}");
    }
    public string fio = "F I O";
    public string date = "01.01.1999";
    public string phone = "09315986257";
    public string email = "E-mail.com";
    public string title = "Job title";
    public string resp = "responsibilities";

    public string Fio
    {
        set
        {
            fio = value;
        }
        get
        {
            return fio;
        }
    }
    public string Date
    {
        set
        {
            date = value;
        }
        get
        {
            return date;
        }
    }
    public string Phone
    {
        set
        {
            phone = value;
        }
        get
        {
            return phone;
        }
    }
    public string Email
    {
        set
        {
            email = value;
        }
        get
        {
            return email;
        }
    }
    public string Title
    {
        set
        {
            title = value;
        }
        get
        {
            return title;
        }
    }
    public string Resp
    {
        set
        {
            resp = value;
        }
        get
        {
            return resp;
        }
    }
}
}
