using Microsoft.EntityFrameworkCore;
using System;
using technical_instruction_form_service.Data;
using technical_instruction_form_service.Models;
using technical_instruction_form_service.Models.Dtos;
using technical_instruction_form_service.Services.Interfaces;

namespace technical_instruction_form_service.Services
{
    public class TechnicalInstructionService : ITechnicalInstructionService
    {
        private readonly AppDbContext _context;
        //private readonly IWebHostEnvironment _environment;

        public TechnicalInstructionService(AppDbContext context)
        {
            _context = context;
           // _environment = environment;
        }

        public async Task<TechnicalInstruction> CreateTechnicalInstruction(CreateTechnicalInstructionDTO dto)
        {
            var technicalInstruction = new TechnicalInstruction
            {
                IssueDate = dto.IssueDate,
                IssuedBy = dto.IssuedBy,
                Title = dto.Title,
                CTINumber = dto.CTINumber,
                Purpose = dto.Purpose,
                ProductType = dto.ProductType,
                Quantity = dto.Quantity,
                Outline = dto.Outline,
                TISApplicabilityDate = dto.TISApplicabilityDate,
                LotNo = dto.LotNo,
                ApplicationDate = DateTime.Now, // Current date
                //Equipment = dto.Equipment
            };

            // Handle file uploads
            /*if (dto.RelatedDocuments != null)
            {
                technicalInstruction.RelatedDocuments = new List<string>();
                foreach (var file in dto.RelatedDocuments)
                {
                    var filePath = Path.Combine(_environment.WebRootPath, "uploads", file.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    technicalInstruction.RelatedDocuments.Add(filePath);
                }
            }*/

            _context.TechnicalInstructions.Add(technicalInstruction);
            await _context.SaveChangesAsync();
            return technicalInstruction;
        }

        public async Task<bool> DeleteTechnicalInstruction(int id)
        {
            var instruction = await _context.TechnicalInstructions.FindAsync(id);

            if (instruction != null) {
                _context.Remove(instruction);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<TechnicalInstruction>> GetListCreateTechnicalInstruction()
        {
            var instructions = await _context.TechnicalInstructions.ToListAsync();

            return instructions;
        }

        public async Task<TechnicalInstruction> GetTechnicalInstruction(int id)
        {
            var instruction = await _context.TechnicalInstructions.FindAsync(id);

            return instruction;
        }

        public async Task<TechnicalInstruction> UpdateTechnicalInstruction(UpdateTechnicalInstructionDTO dto)
        {
            var technicalInstruction = await _context.TechnicalInstructions.FindAsync(dto.Id);
            if (technicalInstruction == null)
            {
                throw new Exception("Technical Instruction not found");
            }

            technicalInstruction.IssueDate = dto.IssueDate;
            technicalInstruction.IssuedBy = dto.IssuedBy;
            technicalInstruction.Title = dto.Title;
            technicalInstruction.CTINumber = dto.CTINumber;
            technicalInstruction.Purpose = dto.Purpose;
            technicalInstruction.ProductType = dto.ProductType;
            technicalInstruction.Quantity = dto.Quantity;
            technicalInstruction.Outline = dto.Outline;
            technicalInstruction.TISApplicabilityDate = dto.TISApplicabilityDate;
            technicalInstruction.LotNo = dto.LotNo;
            //technicalInstruction.Equipment = dto.Equipment;

            // Handle file uploads
            /*if (dto.RelatedDocuments != null)
            {
                technicalInstruction.RelatedDocuments = new List<string>();
                foreach (var file in dto.RelatedDocuments)
                {
                    var filePath = Path.Combine(_environment.WebRootPath, "uploads", file.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    technicalInstruction.RelatedDocuments.Add(filePath);
                }
            }*/

            await _context.SaveChangesAsync();
            return technicalInstruction;
        }
    }
}
