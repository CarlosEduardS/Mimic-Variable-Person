using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MimicAI.Brain
{
    internal class Fellings
    {
        internal static void Inicialization()
        {
            Console.WriteLine("Iniciando Sentimentos...");
            MimicFunctions.GetDataset("Brain", "ThoughtData.json");
        }
    }
}