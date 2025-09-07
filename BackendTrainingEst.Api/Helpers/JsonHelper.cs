namespace BackendTrainingEst.Api.Helpers
{
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public static class JsonHelper
    {
        public static string ToJson(object obj)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true, // Formatea el JSON
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            return JsonSerializer.Serialize(obj, options);
        }
    }
}
