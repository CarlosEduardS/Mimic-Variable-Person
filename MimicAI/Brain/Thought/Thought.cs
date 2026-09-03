using System;
using System.Collections.Generic;
using System.Text;


namespace MimicAI.Brain
{
    public class Thought
    {
        public static void Inicialization()
        {
            Console.WriteLine("Iniciando Pensamentos...");
            var Vocab = MimicFunctions.GetDataset("Brain\\Thought", "ThoughtData.json");
            //Console.WriteLine(Vocab[0]);

            int VocabSize = 2;
            int OutLayerSize = 1;
            var NeoSize = VocabSize.InitHiddenLayer(ExpRate: 0.5);

            var  Ws = new List<double[,]>();
            var  Bs = new List<double[]> ();

            foreach (var Size in NeoSize)
            {
                (var W, var B) = VocabSize.InitWeights(Size);
                Ws.Add(W);
                Bs.Add(B);
            }

            int linhas = Ws[0].GetLength(0);
            int colunas = Ws[0].GetLength(1);

            for (int i = 0; i < linhas; i++)
            {
                double[] linhaAtual = new double[colunas];
                for (int j = 0; j < colunas; j++)
                {
                    linhaAtual[j] = Ws[0][i, j];
                }
                Console.WriteLine($"  [ {string.Join(", ", linhaAtual)} ]");
            }

            Console.WriteLine("Vieses (Bs):");
            Console.WriteLine($"  [ {string.Join(", ", Bs[0])} ]\n");

            Console.WriteLine("Apresentando os pesos da camada de saida:");
            (var OW, var OB) = NeoSize[^1].InitWeights(OutLayerSize);

            Console.WriteLine("Pesos da camada de saída (OW):");
            for (int i = 0; i < OW.GetLength(0); i++)
            {
                double[] linhaAtual = new double[OW.GetLength(1)];
                for (int j = 0; j < OW.GetLength(1); j++)
                {
                    linhaAtual[j] = OW[i, j];
                }
                Console.WriteLine($"  [ {string.Join(", ", linhaAtual)} ]");
            }
            Console.WriteLine("Biases da camada de saída (OB):");
            Console.WriteLine($"  [ {string.Join(", ", OB)} ]\n");
        }
    }
}