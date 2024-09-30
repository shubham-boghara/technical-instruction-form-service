using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using technical_instruction_form_service.Models;
using technical_instruction_form_service.Models.Dtos;
using technical_instruction_form_service.Services.Interfaces;

namespace technical_instruction_form_service.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class TechnicalInstructionController : ControllerBase
    {
        private readonly ITechnicalInstructionService _technicalInstructionService;

        public TechnicalInstructionController(ITechnicalInstructionService technicalInstructionService)
        {
            _technicalInstructionService = technicalInstructionService;
        }

        
        [HttpGet("list")]
        public async Task<IActionResult> GetAllTechnicalSheets()
        {
            var technicalSheets = await _technicalInstructionService.GetListCreateTechnicalInstruction();
            return Ok(technicalSheets);
        }

        // GET: api/technicalinstruction/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult> GetTechnicalInstruction(int id)
        {
            var instruction = await _technicalInstructionService.GetTechnicalInstruction(id);

            if (instruction == null)
            {
                return NotFound();
            }

            return Ok(instruction);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTechnicalInstruction([FromBody] CreateTechnicalInstructionDTO dto)
        {
            var result = await _technicalInstructionService.CreateTechnicalInstruction(dto);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateTechnicalInstruction([FromBody] UpdateTechnicalInstructionDTO dto)
        {
            var result = await _technicalInstructionService.UpdateTechnicalInstruction(dto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTechnicalInstruction(int id)
        {
            var instruction = await _technicalInstructionService.DeleteTechnicalInstruction(id);

            if (instruction == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
