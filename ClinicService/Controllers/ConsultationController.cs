using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClinicService.Services;
using ClinicService.Models.Requests;
using ClinicService.Models;

namespace ClinicService.Controllers
{
    /// <summary>
    /// ДОМАШНЯЯ РАБОТА: Доработать контроллеры PetController и ConsultationController по образу и подобию контроллера ClientController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultationController : ControllerBase
    {
        private  IConsultationRepository _consultationRepository;


        public ConsultationController(IConsultationRepository consultationRepository)
        {
            _consultationRepository = consultationRepository;
        }


        [HttpPost("create")]
        public ActionResult<int> Create([FromBody] CreateConsultationRequest createConsultationRequest)
        {
            Consultation consultation = new Consultation();

            consultation.ClientId = createConsultationRequest.ClientId;
            consultation.PetId = createConsultationRequest.PetId;
            consultation.ConsultationDate = createConsultationRequest.ConsultationDate;
            consultation.Description = createConsultationRequest.Description;
            
            return Ok(_consultationRepository.Create(consultation));
        }

        [HttpPut("update")]
        public ActionResult<int> Update([FromBody] UpdateConsultationRequest updateConsultationRequest)
        {
            Consultation consultation = new Consultation();

            consultation.ConsultationId = updateConsultationRequest.ConsultationId;
            consultation.ClientId = updateConsultationRequest.ClientId;
            consultation.PetId = updateConsultationRequest.PetId;
            consultation.ConsultationDate = updateConsultationRequest.ConsultationDate;
            consultation.Description = updateConsultationRequest.Description;

            return Ok(_consultationRepository.Update(consultation));
        }


        [HttpDelete("delete")]
        public ActionResult<int> Delete(int id)
        {
            return Ok(_consultationRepository.Delete(id));
        }

        [HttpGet("get-all")]
        public ActionResult<List<Client>> GetAll()
        {
            return Ok(_consultationRepository.GetAll());
        }

        [HttpGet("get-by-id")]
        public ActionResult<Client> GetById(int id)
        {
            return Ok(_consultationRepository.GetById(id));
        }
    }
}
