using QueueTest.Collections;
using QueueTest.Models;
using System;

namespace QueueTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MyQueue<Person> persons = new MyQueue<Person>();

            int count = 0;
            bool isCorrect = false;
            while (!isCorrect)
            {
                try
                {
                    //Заполнение данных
                    isCorrect = FillQueueFromConcole(ref persons, out count);

                    //Вывод данных
                    string output = "";
                    for (int i = 0; i < count; i++)
                        output += persons.dequeue().PhoneNumber + " ";
                        Console.Write(output);
                }
                catch(Exception ex)
                {
                    isCorrect = false;
                    Console.WriteLine(ex.Message);
                }
                if (!isCorrect)
                {
                    Console.WriteLine("Вы хотите ввести данные еще раз?(y/n)");

                    if (Console.ReadLine() != "y")  return; 
                }
            }
            Console.ReadKey();
        }


        /// <summary>
        /// Заполнение данных из консоли 
        /// </summary>
        /// <param name="persons"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        static bool FillQueueFromConcole(ref MyQueue<Person> persons,out int count)
        {

            Console.WriteLine("Введите данные:");
            string[] phones = Console.ReadLine().Split(' ');

            if(!int.TryParse(phones[0],out count))
                return false;


            for (int i = 1; i < phones.Length; i++)
            {
                Person person = new Person(phones[i]);
                person.Id = i;
                persons.enqueue(person);
            }

            return true;
        }


    }





}
