// Задача 1: Напишите программу, которая на вход принимает позиции элемента 
// в двумерном массиве, и возвращает значение этого элемента или же указание, 
// что такого элемента нет.
//-------------------------------------------------------------------------------
void GetMatrix(int[,] matrix)    // Метод заполнения двумерного массива рандомом
{
    Random rand = new Random();
    for (int i = 0; i < matrix.GetLength(0); i++)
        for (int j = 0; j < matrix.GetLength(1); j++)
            matrix[i, j] = rand.Next(0, 21); // Генерация случайного числа
}
void PrintMatrix(int[,] matrix)  // Метод вывода матрицы на экран
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
            Console.Write($"{matrix[i, j]}\t");
        Console.WriteLine();
    }
}
// int [,] matr = new int [4,5];
// GetMatrix(matr);
// Console.Write("Введите номер строки:");
// int row = Convert.ToInt32(Console.ReadLine());
// Console.Write("Введите номер столбца:");
// int column = Convert.ToInt32(Console.ReadLine());
// Console.WriteLine("В нашей матрице:");
// PrintMatrix(matr);
// if ( row < matr.GetLength(0) && column < matr.GetLength(1))
//     Console.WriteLine($"Элемент в позиции [{row}, {column}] = {matr[row, column]}");
//     else 
//         Console.WriteLine($"На позиции [{row}, {column}] эдементов не имеется");
//
//----------------------------------------------------------------------------------
// Задача 2: Задайте двумерный массив. Напишите программу, которая поменяет местами 
// первую и последнюю строку массива.
//----------------------------------------------------------------------------------
// int [,] matr = new int [3,5];
// GetMatrix(matr);
// Console.WriteLine("Начальная матрица:");
// PrintMatrix(matr);
// for (int j = 0; j < matr.GetLength(1); j++)
// {
//     int change = matr[0, j];   // Вводим переменную для замены местами двух элементов
//     matr[0, j] = matr[matr.GetLength(0)-1, j];
//     matr[matr.GetLength(0)-1, j] = change;
// }
// Console.WriteLine("Конечная матрица:");
// PrintMatrix(matr);

//--------------------------------------------------------------------------
//  Задача 3: Задайте прямоугольный двумерный массив. Напишите программу, 
//  которая будет находить строку с наименьшей суммой элементов.
//---------------------------------------------------------------------------
// int [,] matr = new int [4,4];
// GetMatrix(matr);
// Console.WriteLine("В матрице:");
// PrintMatrix(matr);
// int  minSum = 0;
// int  numbMinRow = 0;
// for (int j = 0; j < matr.GetLength(1); j++)  // Отдельно посчитаем суимму для нулевой строки, 
// {                                            // так как не могу сообразить что взять за
//        minSum += matr[0, j];                 // основу для minSum  
// }
// for (int i = 1; i < matr.GetLength(0); i++)  // Цикл со второй строки
// {
//     int rowSum = 0;
//     for (int j = 0; j < matr.GetLength(1); j++)
//         rowSum += matr[i, j];
//     if (minSum > rowSum)
//     {
//         minSum = rowSum;
//         numbMinRow = i;
//     }
// }
// Console.WriteLine($"Минимальная сумма в '{numbMinRow}' строке и равняется: '{minSum}'");

//--------------------------------------------------------------------------------
// Задача 4*(не обязательная): Задайте двумерный массив из целых чисел. 
// Напишите программу, которая удалит строку и столбец, на пересечении которых 
// расположен наименьший элемент массива. Под удалением понимается создание 
// нового двумерного массива без строки и столбца
//---------------------------------------------------------------------------------
int[,] matr = new int[4, 6];
GetMatrix(matr);
Console.WriteLine("В матрице:");
PrintMatrix(matr);
int numbMinRow = 0;
int numbMinCol = 0;
int minElement = matr[numbMinRow, numbMinCol];
for (int i = 0; i < matr.GetLength(0); i++)
{
    for (int j = 0; j < matr.GetLength(1); j++)
        if (minElement > matr[i, j])
        {
            minElement = matr[i, j];
            numbMinRow = i;
            numbMinCol = j;
        }
}
Console.WriteLine($"мтнимальный элемент {minElement} стоит на позиции [{numbMinRow}, {numbMinCol}]");
int[,] newMatr = new int[matr.GetLength(0) - 1, matr.GetLength(1) - 1];
int x = 0;                      // придется добавить еще переменных x,y для обозначения
for (int i = 0; i < newMatr.GetLength(0); i++) // индекса первоначальной матрицы
{                                              // т.к. у них разное колличество эл-ов
    int y = 0;
    if (x == numbMinRow)
        x += 1;
    for (int j = 0; j < newMatr.GetLength(1); j++)
    {
        if (y == numbMinCol)
            y += 1;
        newMatr[i, j] = matr[x, y];
        y++;
    }
    x++;
}
Console.WriteLine("Матрица после чистки:");
PrintMatrix(newMatr);