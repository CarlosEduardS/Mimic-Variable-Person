using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MimicAI;
public class DatasetModel
{
    [JsonPropertyName("versao")]
    public string Versao { get; set; }

    [JsonPropertyName("intents")]
    public List<IntentModel> Intents { get; set; }
}

public class IntentModel
{
    [JsonPropertyName("intent")]
    public string Intent { get; set; }

    [JsonPropertyName("subintents")]
    public List<SubintentModel> Subintents { get; set; }
}

public class SubintentModel
{
    [JsonPropertyName("subintent")]
    public string Subintent { get; set; }

    [JsonPropertyName("inputs")]
    public List<TextoModel> Inputs { get; set; }

    [JsonPropertyName("outputs")]
    public List<TextoModel> Outputs { get; set; }
}

public class TextoModel
{
    [JsonPropertyName("var")]
    public string Vars { get; set; }
}

public static class MimicFunctions
{
    public static List<string> GetDataset(string Folder, string FileName)
    {
        try
        {
            string ArcPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Folder, FileName);
            if (File.Exists(ArcPath))
            {
                string json = File.ReadAllText(ArcPath);
                var Data = JsonSerializer.Deserialize<DatasetModel>(json);

                //Console.WriteLine(Data.Versao ?? "Versão não especificada");
                List<string> VocabList = new List<string>();
                string Inputs = "";
                string Outputs = "";

                foreach (var intent in Data.Intents)
                {
                    foreach (var subintent in intent.Subintents)
                    {
                        List<string> ListInputsSelected = new List<string>();
                        List<string> ListOutputsSelected = new List<string>();

                        foreach (var pergunta in subintent.Inputs)
                        {
                            if (ListInputsSelected.Contains(pergunta.Vars))
                            {
                                Inputs = pergunta.Vars;
                                ListInputsSelected.Add(Inputs);
                            }
                        }

                        foreach (var resposta in subintent.Outputs)
                        {
                            if (ListOutputsSelected.Contains(resposta.Vars))
                            {
                                Outputs = resposta.Vars;
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
    public static (int hl, int[] neo) InitHiddenLayer(this int VocabSize, double ExpRate = 0.3)
    {
        int HiddenLayerSize = (int)Math.Max(Math.Round(Math.Pow(Math.Log10(VocabSize), 1.5) - 3.5), 1);
        int[] ListNeoHL = new int[HiddenLayerSize];

        for (int i = 0; i < HiddenLayerSize; ++i)
        {
            int NeoHL = (int)Math.Max(Math.Round(Math.Pow(Math.Log2(VocabSize), 2.2) * (1.5 + (ExpRate * i)) ), 1);
            ListNeoHL[i] = NeoHL;
        }
        return (HiddenLayerSize, ListNeoHL);
    }
    public static double[] InitWeights(this int size)
    {
        double[] Weights = new double[size];
        for (int x = 0; x < size; ++x)
        {
            Weights[x] = Random.Shared.NextDouble();
        }
        return Weights;
    }
}