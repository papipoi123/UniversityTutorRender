using System.Text.Json.Serialization;

namespace Domain.Base
{
    public class BaseEntity
    {
        [JsonPropertyOrder(1)]
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
