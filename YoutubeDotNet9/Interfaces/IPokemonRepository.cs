using YoutubeDotNet9.Models;

namespace YoutubeDotNet9.Interfaces
{
    public interface IPokemonRepository
    {
        Task<Pokemon> CreatePokemon(Pokemon pokemon);
        Task<bool> DeletePokemon(int pokemonId);
        Task<Pokemon> EditPokemon(Pokemon pokemon);
        Task<List<Pokemon>> GetPokemons();
        Task<Pokemon?> GetPokemonById(int pokemonId);
    }
}
