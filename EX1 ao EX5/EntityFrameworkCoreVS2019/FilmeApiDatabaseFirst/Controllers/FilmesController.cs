using FilmeApiDatabaseFirst.Context;
using FilmeApiDatabaseFirst.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace FilmeApiDatabaseFirst.Controllers
{
    [Route("api/v{version:apiVersion}/filmes")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private readonly FilmeContext _filmeContext;

        public FilmesController(FilmeContext filmeContext)
        {
            _filmeContext = filmeContext;
        }
        /// <summary>
        /// Requisição de Lista mocada de filmes
        /// </summary>
        /// <returns>Retorna uma Lista mocada de filmes</returns>
        /// <response code = "200">Sucesso no retorno da lista mocada de filmes!</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _filmeContext.Filmes.ToListAsync().ConfigureAwait(true));
        }

        /// <summary>
        /// Requisição do item de uma lista mocada
        /// </summary>
        /// <param name="id">Id do filme</param>
        /// <returns>Retorno do objeto Filme</returns>
        /// <response code="404">Id inválido !</response>
        /// <response code="200">Sucesso no retorno do objeto filme!</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> Get(int id)
        {
            var filme = await _filmeContext.Filmes.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(true);

            if (filme is null)
            {
                return NotFound();
            }
            return Ok(filme);
        }

        /// <summary>
        /// Postando um novo filme na lista
        /// </summary>
        /// <param name="filme">Objeto FIlme</param>
        /// <returns>Criação do Filme</returns>
        /// <response code= "201">Objeto Filme postado na lista! </response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody] Filme filme)
        {
            _filmeContext.Filmes.Add(filme);

            await _filmeContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = filme.Id }, filme);

        }

        /// <summary>
        /// Atualização de um filme da lista
        /// </summary>
        /// <param name="id">Id do Filme</param>
        /// <param name="filme">Objeto com as novas caracteristicas do filme</param>
        /// <returns>Atualização do Filme</returns>
        /// <response code="404">Id não encontrado !</response>
        /// <response code="204">Atualização do filme realizada com sucesso !</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] Filme filme)
        {
            bool existeFilme = await _filmeContext.Filmes.AnyAsync(x => x.Id == id).ConfigureAwait(true);

            if (!existeFilme)
            {
                return NotFound();
            }

            _filmeContext.Entry(filme).State = EntityState.Modified;
            await _filmeContext.SaveChangesAsync();

            return NoContent();

        }

        /// <summary>
        /// Remoção de um filme
        /// </summary>
        /// <param name="id">Id do filme</param>
        /// <returns>Remoção do filme da lista !</returns>
        /// <reponse code="404">Filme não encontrado</reponse>
        /// <reponse code="204">Filme removido com sucesso</reponse>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            var filme = await _filmeContext.Filmes
                                .FirstOrDefaultAsync(x => x.Id == id)
                                .ConfigureAwait(true);

            if (filme is null)
            {
                return NotFound();
            }

            _filmeContext.Filmes.Remove(filme);

            await _filmeContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
