using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("GetPokemon")]
        public async Task<IActionResult> GetPokemon()
        {
            var x = await _pokemonRepository.GetPokemon();

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
