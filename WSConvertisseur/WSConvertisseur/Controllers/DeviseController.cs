using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSConvertisseur.Models;

namespace WSConvertisseur.Controllers
{
    /// <summary>
    /// Gestion des devises
    /// </summary>
    [Route("api/Devise")]
    public class DeviseController : Controller
    {
        /// <summary>
        /// Liste des dévises 
        /// </summary>
        protected List<Devise> ListeDevises { get; set; }

        /// <summary>
        /// Initialise le controller en créant une liste de devises à gérer
        /// </summary>
        public DeviseController()
        {
            ListeDevises = new List<Devise>
            {
                new Devise(1, "Dollar", 1.08),
                new Devise(2, "Franc Suisse", 1.07),
                new Devise(3, "Yen", 120)
            };
        }

        /// <summary>
        /// Obtenir toutes les devises existantes
        /// </summary>
        /// <remarks>GET: api/Devise</remarks>
        /// <returns>HTTP Response: Liste des devises<returns>
        /// <response code="200">Liste des devises</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Devise>), 200)]
        public async Task<List<Devise>> GetAll()
        {
            return ListeDevises;
        }

        /// <summary>
        /// Obtenir la devise correspondant en utilisant un id
        /// </summary>
        /// <remarks>GET: api/Devise/5</remarks>
        /// <returns>HTTP Response: Devise<returns>
        /// <param name="id">id de la devise souhaitée</param>
        /// <response code="200">Si la devise souhaitée existe</response>
        /// <response code="404">Si la devise souhaitée n'a pas été trouvée</response>
        [HttpGet("{id}", Name = "GetDevise")]
        [ProducesResponseType(typeof(Devise), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetId(int id)
        {
            Devise devise = ListeDevises.FirstOrDefault((d) => d.Id == id);

            if (devise == null)
            {
                return NotFound();
            }

            return Ok(devise);
        }

        /// <summary>
        /// Ajouter une nouvelle devise à la liste
        /// </summary>
        /// <remarks>POST: api/Devise</remarks>
        /// <returns>HTTP Response: Nouvelle devise<returns>
        /// <response code="200">Si la devise a été créée correctement</response>
        /// <response code="400">Si la requête a mal été formulée</response>
        [HttpPost]
        [ProducesResponseType(typeof(Devise), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody]Devise devise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ListeDevises.Add(devise);

            return CreatedAtRoute("GetDevise", new { id = devise.Id }, devise);
        }

        /// <summary>
        /// Mettre à jour une devise existante
        /// </summary>
        /// <remarks>PUT: api/Devise/5</remarks>
        /// <returns>HTTP Response<returns>
        /// <param name="id">id de la devise souhaitée</param>
        /// <response code="204">Si la devise a été mise à jour correctement</response>
        /// <response code="400">Si la requête a mal été formulée</response>
        /// <response code="404">Si la devise n'a pas été trouvée</response>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Put(int id, [FromBody] Devise devise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != devise.Id)
            {
                return BadRequest();
            }

            int index = ListeDevises.FindIndex((d) => d.Id == id);

            if (index < 0)
            {
                return NotFound();
            }

            ListeDevises[index] = devise;

            return NoContent();
        }

        /// <summary>
        /// Supprimer une devise existante
        /// </summary>
        /// <remarks>DELETE: api/Devise/5</remarks>
        /// <returns>HTTP Response: Devise supprimée<returns>
        /// <param name="id">id de la devise souhaitée</param>
        /// <response code="200">Si la devise a bien été supprimée</response>
        /// <response code="404">Si la devise n'a pas été trouvée</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Devise), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            Devise devise = ListeDevises.FirstOrDefault((d) => d.Id == id);

            if (devise == null)
            {
                return NotFound();
            }

            ListeDevises.Remove(devise);

            return Ok(devise);
        }
    }
}
