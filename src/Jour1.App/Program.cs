for (int i = 0; i <= 100; i += 10)
{
    Console.Write($"\rChargement {i}%   ");
    Thread.Sleep(500); // pause de 500 ms
}
Console.WriteLine();
