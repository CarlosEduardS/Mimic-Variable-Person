using MimicAI.Brain;
using System;

namespace MimicAI;
public class Program
{
    public static void Main()
    {
        try
        {
            Console.WriteLine("Iniciando configurações basicas...");
            Brain.Thought.Inicialization();
            Brain.Fellings.Inicialization();
            Brain.Memory.Inicialization();

            Console.WriteLine("Mimic esta acordando!!!");
            string exemplo1 = "Ola";     exemplo1.Memorize();
            int exemplo2 = 123;          exemplo2.Memorize();
            decimal exemplo3 = 123.45m;  exemplo3.Memorize();
            double exemplo4 = 123.45;    exemplo4.Memorize();
            bool exemplo5 = true;        exemplo5.Memorize();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            throw;
        }
    }
}