using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MimicAI;
internal class DatasetModel
{
    [JsonPropertyName("versao")]
    internal string Versao { get; set; }

    [JsonPropertyName("intents")]
    internal List<IntentModel> Intents { get; set; } = new List<IntentModel>();
}

internal class IntentModel
{
    [JsonPropertyName("intent")]
    internal string Intent { get; set; }

    [JsonPropertyName("subintents")]
    internal List<SubintentModel> Subintents { get; set; }
}

internal class SubintentModel
{
    [JsonPropertyName("subintent")]
    internal string Subintent { get; set; }

    [JsonPropertyName("inputs")]
    internal List<TextoModel> Inputs { get; set; }

    [JsonPropertyName("outputs")]
    internal List<TextoModel> Outputs { get; set; }
}

internal class TextoModel
{
    [JsonPropertyName("var")]
    internal string Vars { get; set; }
}

internal static class MimicFunctions
{
    internal static List<string> GetDataset(string Folder, string FileName)
    {
        try
        {
            string ArcPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Folder, FileName);
            if (File.Exists(ArcPath))
            {
                string json = File.ReadAllText(ArcPath);
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var Data = JsonSerializer.Deserialize<DatasetModel>(json, options);

                //Console.WriteLine(Data.Versao ?? "Versão não especificada");
                List<string> VocabList = new List<string>();

                foreach (var intent in Data.Intents)
                {
                    foreach (var subintent in intent.Subintents)
                    {
                        List<string> ListInputsSelected = new List<string>();
                        List<string> ListOutputsSelected = new List<string>();

                        foreach (var pergunta in subintent.Inputs)
                        {
                            if (!ListInputsSelected.Contains(pergunta.Vars))
                            {
                                var Inputs = pergunta.Vars;
                                ListInputsSelected.Add(Inputs);
                            }
                        }

                        foreach (var resposta in subintent.Outputs)
                        {
                            if (!ListOutputsSelected.Contains(resposta.Vars))
                            {
                                var Outputs = resposta.Vars;
                                ListOutputsSelected.Add(Outputs);
                            }
                        }
                        VocabList.Add(String.Join(" ", ListInputsSelected) + " @pros " + String.Join(" ", ListOutputsSelected));
                    }
                }

                return VocabList;
            }
            else
            {
                throw new Exception($"Arquivo {FileName} não encontrado.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro em inicializar o JSON {FileName}: {ex.Message}");
            throw;
        }
    }
    internal static int[] InitHiddenLayer(this int VocabSize, double ExpRate = 0.3)
    {
        int HiddenLayerSize = (int)Math.Max(Math.Round(Math.Pow(Math.Log10(VocabSize), 1.5) - 3.5), 1);
        int[] ListNeoHL = new int[HiddenLayerSize];

        for (int i = 0; i < HiddenLayerSize; ++i)
        {
            int NeoHL = (int)Math.Max(Math.Round(Math.Pow(Math.Log2(VocabSize), 2.2) * (1.5 + (ExpRate * i))), 1);
            ListNeoHL[i] = NeoHL;
        }
        return ListNeoHL;
    }
    internal static (double[,], double[]) InitWeights(this int InputSize, int OutputSize)
    {
        double[,] Weights = new double[InputSize, OutputSize];
        double[] Biases = new double[OutputSize];
        Array.Fill(Biases, 0.0);

        for (int x = 0; x < InputSize; ++x)
        {
            for (int y = 0; y < OutputSize; ++y)
            {
                Weights[x, y] = Random.Shared.NextDouble();
            }
        }
        return (Weights, Biases);
    }
}   