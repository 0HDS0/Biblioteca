using System.Text.Json.Serialization;

namespace Biblioteca.Api.Domain
{
    public class Genre
    {
        [JsonPropertyName("id_genero")]
        public long ID { get; set; }

        [JsonPropertyName("classificação")]
        public string Classification { get; set; }

        [JsonPropertyName("description")]
        public string Description { get;set; }

    }
}
