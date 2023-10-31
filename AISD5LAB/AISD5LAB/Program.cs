using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace AISD5LAB
{
    class KeyValue
    {
        public int Key { get; set; }
        public string Value { get; set; }
        public KeyValue(int k, string str)
        {
            Key = k;
            Value = str;
        }
    }
    public class HStable
    {
        int N = 20;// размер хеш таблицы
        KeyValue[] arr; // массив пар хеш-таблицы ключ-значение
        public HStable()
        {
             arr =  new KeyValue[N]; //создание массива значений для хеш-таблицы
        }
        public void Insert(int key, string val)// метод ввода данных в хеш-таблицу
        {
            int hash = key % N;// хеш-функция, деление ключа на размероность хеш-таблицы(метод линейного опробования)
            while(arr[hash]!=null && arr[hash].Key!=key)// поиск свободной ячейки для хеш-таблицы(есть ли значение и сравнивает сам ключ)
            {
                hash = (hash + 1) % N;// вычисление адреса очередного элемента
            }
            arr[hash] = new KeyValue(key, val);// выполнение вставки элемента в хеш-таблицу
        }
        public string Search(int key)
        {

            int hash = key % N; //хеш - функция, деление ключа на размероность хеш - таблицы(метод линейного опробования)
            while (arr[hash] != null && arr[hash].Key+1 != key)// поиск свободной ячейки для хеш-таблицы(есть ли значение и сравнивает сам ключ)
            {
                hash = (hash + 1) % N;// вычисление адреса очередного элемента
            }

                return arr[hash].Value;// возвращает найденное значение 
        }
        public void Print()
        {
            for (int i = 0 ;i<N;++i)
            {
                if(arr[i]!=null)
                {
                    Console.WriteLine($"Ключ: {arr[i].Key+1} , Значение: {arr[i].Value}");
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int N = 15;
                int min = 12000;
                int max = 34000;
                int[] arr = new int[N];
                Random rnd = new Random();
                for (int i = 0; i < arr.Length; ++i)
                {
                    arr[i] = rnd.Next(min, max + 1);
                }
                Console.WriteLine("Массив");
                for (int i = 0; i < arr.Length; ++i)
                {
                    Console.Write(arr[i] + " ");
                }
                HStable a = new HStable();
                int j = 0;
                for (int i = 0; i < 20; ++i)
                {
                    a.Insert(i, Convert.ToString(arr[j]));
                    ++j;
                    if(j>=arr.Length)
                    {
                        j = 0;
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Результат поискать по ключу 20");
                string val = a.Search(20);
                Console.WriteLine(val);
                a.Print();
                Console.ReadLine();
            }
            catch { Console.WriteLine("Что-то пошло не так"); }
            Console.ReadLine();
            

        }
    }
}
