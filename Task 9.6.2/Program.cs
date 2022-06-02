using System;


namespace Task_9._6._2
{
    class Program
    {
        static void Main(string[] args)
        {
            NumberReader numberReader = new NumberReader();
            numberReader.NumberEnteredEvent += SortMas;

            try
            {
                numberReader.Read();
            }

            catch (FormatException)
            {
                Console.WriteLine("Введено некорректное значение");
            }

            static void SortMas(int number)
            {
                string[] Name = new string[5];
                for (int i = 0; i < Name.Length; i++)
                {
                    Console.WriteLine("Введите имя"); 
                    Name[i] = Console.ReadLine();
                }

                switch (number)
                {
                    case 1:
                        
                            Array.Sort(Name, StringComparer.InvariantCulture);
                            
                        break;

                    case 2:
                        Array.Sort(Name, StringComparer.InvariantCulture);
                        Array.Reverse(Name);
                        Array.ForEach(Name, x => Console.WriteLine(x));
                        break;

                }
            }
        }
    }
    class NumberReader
    {
        public delegate void NumberEnteredDelegate(int number);
        public event NumberEnteredDelegate NumberEnteredEvent;

        public void Read()
        {
            Console.WriteLine("Сортировать А-Я, нажмите 1");
            Console.WriteLine("Сортировать Я-А, нажмите 2");

            int number = Convert.ToInt32(Console.ReadLine());

            if (number != 1 && number != 2) throw new FormatException();

            NumberEntered(number);
        }

        protected virtual void NumberEntered(int number)
        {
            NumberEnteredEvent?.Invoke(number);
        }
    }
    
}
