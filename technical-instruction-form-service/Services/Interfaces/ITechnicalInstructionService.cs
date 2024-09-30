using technical_instruction_form_service.Models;
using technical_instruction_form_service.Models.Dtos;

namespace technical_instruction_form_service.Services.Interfaces
{
    public interface ITechnicalInstructionService
    {
        Task<IEnumerable<TechnicalInstruction>> GetListCreateTechnicalInstruction();
        Task<TechnicalInstruction> GetTechnicalInstruction(int id);
        Task<TechnicalInstruction> CreateTechnicalInstruction(CreateTechnicalInstructionDTO dto);
        Task<TechnicalInstruction> UpdateTechnicalInstruction(UpdateTechnicalInstructionDTO dto);
        Task<bool> DeleteTechnicalInstruction(int id);
    }
}
