using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MimicAI.Brain;
internal class MemoryModel
{
    [JsonPropertyName("argmax")]
    int[,,] ArgMax { get; set; }
}

public static class Memory
{
    public static void Inicialization()
    {
        Console.WriteLine("Iniciando Memória...");
        var Vocab = MimicFunctions.GetDataset("Brain/Memory", "MemoryData.json");

        string ArcPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Brain/Memory", "MemoryConsolidation.json");

        if (File.Exists(ArcPath))
        {
            var Data = Evocation<MemoryModel>(ArcPath);
        }
    }
    public static MemoryModel Evocation<MemoryModel>(string Locate = "")
    {
        if (string.IsNullOrEmpty(Locate))
        {
            Locate = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Brain/Memory", "MemoryConsolidation.json");
        }

        string json = File.ReadAllText(Locate);
        var Data = JsonSerializer.Deserialize<MemoryModel>(json);

        return Data;
    }

    public static void Memorize<MemoryModel>(this MemoryModel backup)
    {

    }
}
