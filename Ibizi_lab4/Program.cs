using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ibizi_lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            const int SIZE = 5;
            var k = 0;

            WriteLine("Введите сообщение для шифрования");
            var strBuf = ReadLine();
            WriteLine();
            var grid = new int[SIZE, SIZE]
          {
                {1, 0, 1, 0, 0},
                {1, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 1, 0, 1, 0},
                {0, 1, 0, 0, 0}
          };
            string[] alfkir =
             {
"а", "б", "в", "г","д", "е",
"ё", "ж", "з", "и", "к", "л",
"м", "н", "о", "п", "р", "с",
"т", "у", "ф", "х", "ч", "щ",
};
            for (int i = 0; i < grid.Length; i++)
            {
                Random rnd = new Random();
              int  b =  rnd.Next(0, 16);
                while (strBuf.Length < SIZE * SIZE) strBuf += alfkir[ rnd.Next(0,20)];

            }

            var buf = new string[SIZE];
          

            //прямой обход решетки
            for (var i = 0; i < SIZE; i++)
                for (var j = 0; j < SIZE; j++)
                    if (grid[i, j] == 1)
                    {
                        buf[i] += strBuf[k];
                        k++;
                    }

            //поворот решетки на 90
            for (var i = 0; i < SIZE; i++)
                for (var j = 0; j < SIZE; j++)
                    if (grid[SIZE - j - 1, i] == 1)
                    {
                        buf[i] += strBuf[k];
                        k++;
                    }

            // поворот решетки на 180
            for (var i = 0; i < SIZE; i++)
                for (var j = 0; j < SIZE; j++)
                    if (grid[SIZE - i - 1, SIZE - j - 1] == 1)
                    {
                        buf[i] += strBuf[k];
                        k++;
                    }

            // поворот решетки на 270
            for (var i = 0; i < SIZE; i++)
                for (var j = 0; j < SIZE; j++)
                    if (grid[j, SIZE - i - 1] == 1)
                    {
                        buf[i] += strBuf[k];
                        k++;
                    }

            WriteLine("Зашифрованное сообщение:");
            for (var i = 0; i < SIZE; i++)
                Write(buf[i]);
            ReadKey();
        }
    }
}
