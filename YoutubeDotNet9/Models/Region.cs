namespace YoutubeDotNet9.Models
{
    public class Region
    {
        public int RegionId { get; set; }
        public string? RegionName { get; set; }
        public virtual ICollection<Pokemon> Pokemons { get; set; } = new List<Pokemon>();
    }
}
