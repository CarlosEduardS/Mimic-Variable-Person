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

    [JsonPropertyName("perguntas")]
    public List<TextoModel> Perguntas { get; set; }

    [JsonPropertyName("respostas")]
    public List<TextoModel> Respostas { get; set; }
}

public class TextoModel
{
    [JsonPropertyName("texto")]
    public string Texto { get; set; }
}

public class MimicFunctions
{
    public static void GetDataset(string FileName)
    {
        try
        {
            string ArcPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Brain", FileName);
            if (File.Exists(ArcPath))
            {
                string json = File.ReadAllText(ArcPath);
                var Data = JsonSerializer.Deserialize<DatasetModel>(json);

                Console.WriteLine(Data.Versao ?? "Versão não especificada");
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