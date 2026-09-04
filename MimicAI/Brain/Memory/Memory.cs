using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace MimicAI.Brain;
internal class MemoryModel
{
    [JsonPropertyName("parschar")]
    double[,] ParsChar { get; set; }
    [JsonPropertyName("listnumbers")]
    double[] ListNumbers { get; set; }
    [JsonPropertyName("listdecimal")]
    double[] ListDecimal { get; set; }
    [JsonPropertyName("listdouble")]
    double[] ListDouble { get; set; }
    [JsonPropertyName("listbooleans")]
    double[] ListBool { get; set; }
}

public static class Memory
{
    private static string ProjectDirectory => Path.GetFullPath(
        Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));

    public static void Inicialization()
    {
        Console.WriteLine("Iniciando Memória...");
        var Vocab = MimicFunctions.GetDataset("Brain\\Memory", "MemoryData.json");

        string ArcPath = Path.Combine(ProjectDirectory, "Brain", "Memory", "MemoryConsolidation.json");

        if (File.Exists(ArcPath))
        {
            var Data = Evocation<MemoryModel>(ArcPath);
        }
    }
    public static MemoryModel Evocation<MemoryModel>(string Locate = "")
    {
        if (string.IsNullOrEmpty(Locate))
        {
            Locate = Path.Combine(ProjectDirectory, "Brain", "Memory", "MemoryConsolidation.json");
        }

        string json = File.ReadAllText(Locate);
        var Data = JsonSerializer.Deserialize<MemoryModel>(json);

        return Data;
    }

    public static void Memorize<T>(this T ArgVal)
    {
        string path = Path.Combine(ProjectDirectory, "Brain", "Memory", "MemoryConsolidation.json");
        var json = File.Exists(path) ? File.ReadAllText(path) : "{}";
        var root = JsonNode.Parse(json) as JsonObject ?? new JsonObject();

        switch (ArgVal)
        {
            case int i:
                var EmbNum = new double[64];
                for (int j = 0; j < EmbNum.Length; ++j)
                {
                    EmbNum[j] = Random.Shared.NextDouble();
                }

                var ListNumbers = root["listnumbers"] as JsonArray ?? new JsonArray();

                ListNumbers.Add(JsonSerializer.SerializeToNode(EmbNum));

                root["listnumbers"] = ListNumbers;
                File.WriteAllText(path, root.ToJsonString(new JsonSerializerOptions { WriteIndented = true }));

                break;

            case string s:
                var Pars = new List<char[]>();
                for (int idx = 0; idx < s.Length; idx += 2)
                {
                    if (idx + 1 < s.Length)
                    {
                        Pars.Add(new char[] { s[idx], s[idx + 1] });
                    }
                    else
                    {
                        Pars.Add(new char[] { s[idx] });
                    }
                }

                double[][] EmbPars = new double[Pars.Count][];
                for (int i = 0; i < EmbPars.Length; ++i)
                {
                    EmbPars[i] = new double[32];
                    for (int j = 0; j < EmbPars[i].Length; ++j)
                    {
                        EmbPars[i][j] = Random.Shared.NextDouble();
                    }
                }

                var parsChar = root["parschar"] as JsonArray ?? new JsonArray();

                foreach (var embPar in EmbPars)
                {
                    parsChar.Add(JsonSerializer.SerializeToNode(embPar));
                }

                root["parschar"] = parsChar;
                File.WriteAllText(path, root.ToJsonString(new JsonSerializerOptions { WriteIndented = true }));

                break;

            case decimal dec:
                var EmbDec = new double[128];
                for (int j = 0; j < EmbDec.Length; ++j)
                {
                    EmbDec[j] = Random.Shared.NextDouble();
                }

                var ListDecimal = root["listdecimal"] as JsonArray ?? new JsonArray();

                ListDecimal.Add(JsonSerializer.SerializeToNode(EmbDec));

                root["listdecimal"] = ListDecimal;
                File.WriteAllText(path, root.ToJsonString(new JsonSerializerOptions { WriteIndented = true }));

                break;

            case double dbl:
                var EmbDou = new double[86];
                for (int j = 0; j < EmbDou.Length; ++j)
                {
                    EmbDou[j] = Random.Shared.NextDouble();
                }

                var ListDouble = root["listdouble"] as JsonArray ?? new JsonArray();

                ListDouble.Add(JsonSerializer.SerializeToNode(EmbDou));

                root["listdouble"] = ListDouble;
                File.WriteAllText(path, root.ToJsonString(new JsonSerializerOptions { WriteIndented = true }));

                break;

            case bool b:
                var EmbBool = new double[16];
                for (int j = 0; j < EmbBool.Length; ++j)
                {
                    EmbBool[j] = Random.Shared.NextDouble();
                }

                var ListBools = root["listbooleans"] as JsonArray ?? new JsonArray();

                ListBools.Add(JsonSerializer.SerializeToNode(EmbBool));

                root["listbooleans"] = ListBools;
                File.WriteAllText(path, root.ToJsonString(new JsonSerializerOptions { WriteIndented = true }));

                break;

            default:
                break;
        }
    }
}
