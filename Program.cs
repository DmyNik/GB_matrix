// Тема: Двумерные массивы.
// --- Начало программы ----------------/\---/\------------------------------------------------
// --------------------------------------*---*-------------------------------------------------
// ---------------------------------------\*/--------------------------------------------------


// --- Блок методов ---------------------------------------------------------------------------
// --------------------------------------------------------------------------------------------

static void ExitProgram() { // Досрочное завершение работы программы
    
    Console.Write("> Работа программы завершена досрочно!\n");
    System.Environment.Exit(1);

}
    
static int ReadInt(string text) // Прочитать целое число с консоли
{
    string? str;
    bool check = false;

    System.Console.Write(text);
    str = Console.ReadLine();

    //check = (Int32.TryParse(str, out int num) == false) ? false : true;
    check = Int32.TryParse(str, out int num) != false;

    while (check == false) {
        
        Console.Write("> Неудалось обнаружить число во введенной строке.\n");
        Console.Write("> Повторите ввод или введите символ 'q' для выхода из программы.\n");
        
        System.Console.Write(text);
        str = Console.ReadLine();

        check = Int32.TryParse(str, out num) != false;

        // str = str == null ? "" : str; // до первого упрощения
        // str = str ?? "";              // до второго упрощения

        str ??= "";

        if ((int)str[0] == 113 || (int)str[0] == 81) { ExitProgram(); }     

    }
    
    return num;

}

static string ReadStr(string text) // Прочитать строку с консоли
{
    
    string? str;
    
    System.Console.Write(text);
    str = Console.ReadLine();
 
    return str ?? "";

}

static int[,] GenerateMatrix(int row, int col, int leftRange = 1, int rightRange = 100) // Сгенерировать новую матрицу с заданными диапазонами
{
    int[,] tempMatrix = new int[row, col];
    Random rand = new();

    for (int i = 0; i < tempMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < tempMatrix.GetLength(1); j++)
        {
            tempMatrix[i, j] = rand.Next(leftRange, rightRange + 1);
        }
    }

    return tempMatrix;
}

static void ShowMatrix(int[,] matrixForPrint)
{
    for (int i = 0; i < matrixForPrint.GetLength(0); i++)
    {
        for (int j = 0; j < matrixForPrint.GetLength(1); j++)
        {
            System.Console.Write(matrixForPrint[i, j] + "\t");
        }
        System.Console.WriteLine();
    }
}

static string FindElementInMatrix(int[,] mtx, int m, int n) {

    string str = "Указанный элемент находится не в границах данной мастрицы.";

    if (m > 0 && n > 0) {
        if (m < mtx.GetLength(0) && n < mtx.GetLength(1)) {
            str = mtx[m, n].ToString();
        }
    }

    return str;

}

static void ExchangeStringInMatrix(int[,] mtx) {

    int rows = mtx.GetLength(0);
    int cols = mtx.GetLength(1);
    
    int[] arrayF = new int[cols];
    int[] arrayL = new int[cols];
    
    for ( int j = 0; j < cols; j++ ) {
        arrayF[j] = mtx[0, j];
    }

    for ( int j = 0; j < cols; j++ ) {
        arrayL[j] = mtx[rows-1, j];
    }

    for ( int j = 0; j < cols; j++ ) {
        mtx[0, j] = arrayL[j];
    }

    for ( int j = 0; j < cols; j++ ) {
        mtx[rows-1, j] = arrayF[j];
    }

}

static void FindStrThisMinSummInMatrix(int[,] mtx) { // Поиск строки с наименьшей суммой в матрице

    int rows = mtx.GetLength(0);
    int cols = mtx.GetLength(1);
    
    int min1 = 0;
    int min2 = 0;

    int indxOfString = 0;

    for ( int j = 0; j < cols; j++ ) {
        min1 += mtx[0, j];
    }

    indxOfString = 0;
    
    for ( int i = 1; i < rows; i++ ) {
        for ( int j = 0; j < cols; j++ ) {
            min2 += mtx[i, j];           
        }
        if ( min2 < min1 ) { 
            min1 = min2;
            indxOfString = i; 
        }
        min2 = 0;
    }

    Console.WriteLine("> Индекс строки с наименьшей суммой: " + indxOfString);

}

static int[,] GenerateNewMatrix(int[,] mtx) // Сгенерировать новую матрицу на основе приянятой в параметре
{
    int rows = mtx.GetLength(0);
    int cols = mtx.GetLength(1);

    int m = 0;
    int n = 0;

    int[,] newMatrix = new int[rows-1, cols-1];

    int min = mtx[0, 0];
    
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            if ( mtx[i, j] < min ) 
            { 
                min = mtx[i, j];
                m = i;
                n = j;
            }
        }
    }

    int ii = 0;
    int jj = 0;
    
    for (int i = 0; i < rows-1; i++)
    {
        
        if ( i == m ) { ii++; }
        
        jj = 0;

        for (int j = 0; j < cols-1; j++)
        {
               
            if ( j == n ) { jj++; }

            newMatrix[i, j] = mtx[ii, jj];

            jj++;

        }

        ii++;

    }

    return newMatrix;
}

// --- end ------------------------------------------------------------------------------------



// --- Основной блок --------------------------------------------------------------------------
// --------------------------------------------------------------------------------------------

int rows; // Число строк в матрице
int cols; // Число столбцов в матрице
int m; // Индекс строки в матрице
int n; // Индекс столбца в матрице
string anyKey = "";

// Задача 1: Напишите программу, которая на вход принимает позиции элемента в
// двумерном массиве, и возвращает значение этого элемента или 
// же указание, что такого элемента нет.

Console.WriteLine("> Задача 1.");

rows = ReadInt("> Введите количество строк в матрице: ");
cols = ReadInt("> Введите количество столбцов в матрице: ");
int[,] matrix = GenerateMatrix(rows, cols, 0, 100);

m = ReadInt("> Введите искомый индекс строки: ");
n = ReadInt("> Введите искомый индекс столбца: ");

Console.WriteLine("Значение указанного элемента: " + FindElementInMatrix(matrix, m, n));

ShowMatrix(matrix);

anyKey = ReadStr("Для продолжения введите любой символ... ");

// Задача 2: Задайте двумерный массив. Напишите программу, которая поменяет
// местами первую и последнюю строку массива.

Console.WriteLine("> Задача 2.");

ExchangeStringInMatrix(matrix);

ShowMatrix(matrix);

anyKey = ReadStr("Для продолжения введите любой символ... ");

// Задача 3: Задайте прямоугольный двумерный массив. Напишите программу, которая 
// будет находить строку с наименьшей суммой элементов.

Console.WriteLine("> Задача 3.");

Array.Clear(matrix, 0, matrix.Length);

matrix = GenerateMatrix(5, 5, 0, 100);

FindStrThisMinSummInMatrix(matrix);

ShowMatrix(matrix);

// Задача 4*(не обязательная): Задайте двумерный массив из целых чисел. 
// Напишите программу, которая удалит строку и столбец, на пересечении которых 
// расположен наименьший элемент массива. Под удалением понимается создание нового 
// двумерного массива без строки и столбца

Console.WriteLine("> Задача 4.");

rows = ReadInt("> Введите количество строк в матрице: ");
cols = ReadInt("> Введите количество столбцов в матрице: ");

Array.Clear(matrix, 0, matrix.Length);
matrix = GenerateMatrix(rows, cols, 0, 100);

Console.WriteLine("> Исходная матрица.");
ShowMatrix(matrix);

int[,] newMatrix = GenerateNewMatrix(matrix);

Console.WriteLine("> Новая матрица.");
ShowMatrix(newMatrix);

anyKey = ReadStr("\nРабота программы завершена. Для продолжения введите любой символ... ");
