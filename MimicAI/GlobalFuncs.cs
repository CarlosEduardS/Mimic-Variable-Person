using System;
using System.Collections.Generic;
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

public class MimicFunctions
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

                        foreach (var pergunta in subintent.Inputs)
                        {
                            Inputs = pergunta.Vars;
                        }

                        foreach (var resposta in subintent.Outputs)
                        {
                            Outputs = resposta.Vars;
                        }
                        VocabList.Add(Inputs + "@pros" + Outputs);
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
}