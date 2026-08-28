using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace MimicAI.Brain
{
    internal class Thought
    {
        internal static void Inicialization()
        {
            Console.WriteLine("Iniciando Pensamentos...");
            MimicFunctions.GetDataset("ThoughtData.json");
        }
    }
}