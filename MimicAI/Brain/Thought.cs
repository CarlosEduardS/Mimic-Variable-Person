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
            var s = MimicFunctions.GetDataset("Brain", "ThoughtData.json");
            Console.WriteLine(s[0]);

            int VocabSize = 5675;
            var HL = VocabSize.InitHiddenLayer(ExpRate: 0.1);

            Console.WriteLine(HL.hl);
            Console.WriteLine(string.Join(", ", HL.neo));

            var Ws = VocabSize.InitWeights();
            //Console.WriteLine(string.Join(", ", Ws));
        }
    }
}