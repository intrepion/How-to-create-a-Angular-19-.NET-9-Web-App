using Microsoft.AspNetCore.Mvc;
using YoutubeDotNet9.Interfaces;
using YoutubeDotNet9.Models;

namespace YoutubeDotNet9.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonController(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        [HttpGet("GetPokemons")]
        public async Task<IActionResult> GetPokemons()
        {
            var x = await _pokemonRepository.GetPokemons();

            return Ok(x);
        }

        [HttpGet("GetPokemonById")]
        public async Task<IActionResult> GetPokemonById(int id)
        {
            var x = await _pokemonRepository.GetPokemonById(id);

            return Ok(x);
        }

        [HttpPost("CreatePokemon")]
        public async Task<IActionResult> CreatePokemon([FromBody] Pokemon pokemon)
        {
            var pokemons = await _pokemonRepository.CreatePokemon(pokemon);

            return Ok(pokemons);
        }

        [HttpPut("EditPokemon")]
        public async Task<IActionResult> EditPokemon([FromBody] Pokemon pokemon)
        {
            var editedPokemon = await _pokemonRepository.EditPokemon(pokemon);

            return Ok(editedPokemon);
        }

        [HttpDelete("DeletePokemon")]
        public async Task<IActionResult> DeletePokemon([FromBody] int id)
        {
            var pokemon = await _pokemonRepository.DeletePokemon(id);

            return Ok(pokemon);
        }
    }
}
