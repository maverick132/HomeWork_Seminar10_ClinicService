using ClinicService.Models;
using ClinicService.Models.Requests;
using ClinicService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicService.Controllers
{
    /// <summary>
    /// ДОМАШНЯЯ РАБОТА: Доработать контроллеры PetController и ConsultationController по образу и подобию контроллера ClientController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private IPetRepository _petRepository;

        public PetController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        [HttpPost("create")]
        public ActionResult<int> Create([FromBody] CreatePetRequest createPetRequest)
        {
            Pet pet = new Pet();

            pet.ClientId = createPetRequest.ClientId;
            pet.Name = createPetRequest.Name;
            pet.Birthday = createPetRequest.Birthday;
           

            return Ok(_petRepository.Create(pet));
        }

        [HttpPut("update")]
        public ActionResult<int> Update([FromBody] UpdatePetRequest updatePetRequest)
        {
            Pet pet = new Pet();

            pet.PetId = updatePetRequest.PetId;
            pet.ClientId = updatePetRequest.ClientId;
            pet.Name = updatePetRequest.Name;
            pet.Birthday = updatePetRequest.Birthday;
            
            return Ok(_petRepository.Update(pet));
        }


        [HttpDelete("delete")]
        public ActionResult<int> Delete(int id)
        {
            return Ok(_petRepository.Delete(id));
        }

        [HttpGet("get-all")]
        public ActionResult<List<Client>> GetAll()
        {
            return Ok(_petRepository.GetAll());
        }

        [HttpGet("get-by-id")]
        public ActionResult<Client> GetById(int id)
        {
            return Ok(_petRepository.GetById(id));
        }
    }
}
