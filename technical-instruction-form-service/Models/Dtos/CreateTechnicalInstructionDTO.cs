namespace technical_instruction_form_service.Models.Dtos
{
    public class CreateTechnicalInstructionDTO
    {
        public DateTime? IssueDate { get; set; }
        public string? IssuedBy { get; set; }
        public string? Title { get; set; }
        public string? CTINumber { get; set; }
        public string? Purpose { get; set; }
        public string? ProductType { get; set; }
        public decimal? Quantity { get; set; }
        public string? Outline { get; set; }
        public DateTime? TISApplicabilityDate { get; set; }
        public string? LotNo { get; set; }
        //public List<IFormFile> RelatedDocuments { get; set; }
        //public List<string> Equipment { get; set; }
    }
}
