namespace YoutubeDotNet9.Models
{
    public class Type
    {
        public int TypeId { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Pokemon> Pokemons { get; set; } = new List<Pokemon>();
    }
}
