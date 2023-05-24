using System.Text.Json.Serialization;

namespace Biblioteca.Api.Domain
{
    public class Author
    {
        [JsonPropertyName("id_author")]
        public long ID { get; set; }

        [JsonPropertyName("nome")]
        public string Name { get; set; }

        [JsonPropertyName("bibliografia")]
        public string Bibliography { get; set; }

        [JsonPropertyName("nome_art")]
        public string ArtisticName { get; set; }

        [JsonPropertyName("editora")]
        public string Publisher { get; set; }

        [JsonPropertyName("numero_edicao")]
        public string EditionNumber { get; set; }

    }
}
