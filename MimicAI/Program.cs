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

            Console.WriteLine("Mimic esta acordando!!!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            throw;
        }
    }
}