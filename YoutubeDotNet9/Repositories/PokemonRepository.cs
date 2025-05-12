using Microsoft.EntityFrameworkCore;
using YoutubeDotNet9.Interfaces;
using YoutubeDotNet9.Models;

namespace YoutubeDotNet9.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        public readonly SampleDatabaseContext _databaseContext;
        public PokemonRepository(SampleDatabaseContext dbContext)
        {
            _databaseContext = dbContext;
        }
        public async Task<Pokemon> CreatePokemon(Pokemon pokemon)
        {
            _databaseContext.Pokemons.Add(pokemon);
            await _databaseContext.SaveChangesAsync();

            return pokemon;
        }

        public async Task<bool> DeletePokemon(int pokemonId)
        {
            var rows = await _databaseContext.Pokemons.Where(x => x.PokemonId == pokemonId).ExecuteDeleteAsync();

            return true;
        }

        public async Task<Pokemon> EditPokemon(Pokemon pokemon)
        {
            var rows = await _databaseContext.Pokemons.Where(x => x.PokemonId == pokemon.PokemonId)
                .ExecuteUpdateAsync(x => x.SetProperty(x => x.Name, pokemon.Name));

            return pokemon;
        }

        public async Task<Pokemon?> GetPokemonById(int pokemonId)
        {
            var result = await _databaseContext.Pokemons.Include(x => x.Region).Include(x => x.Type).Where(x => x.PokemonId == pokemonId)
                .Select(x => new Pokemon
                {
                    PokemonId = x.PokemonId,
                    Name = x.Name,
                    PokedexNumber = x.PokedexNumber,
                    Region = x.Region,
                    Type = x.Type,
                    RegionId = x.RegionId,
                    TypeId = x.TypeId,
                }).FirstOrDefaultAsync();

            return result;
        }

        public async Task<List<Pokemon>> GetPokemons()
        {
            var result = await _databaseContext.Pokemons.Include(x => x.Region).Include(x => x.Type)
                .Select(x => new Pokemon
                {
                    PokemonId = x.PokemonId,
                    Name = x.Name,
                    PokedexNumber = x.PokedexNumber,
                    Region = x.Region,
                    Type = x.Type,
                    RegionId = x.RegionId,
                    TypeId = x.TypeId,
                }).ToListAsync();

            return result;
        }
    }
}