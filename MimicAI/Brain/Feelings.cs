using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MimicAI.Brain
{
    public class Fellings
    {
        public static void Inicialization()
        {
            Console.WriteLine("Iniciando Sentimentos...");
            MimicFunctions.GetDataset("Brain", "FeelingsData.json");
        }
    }
}