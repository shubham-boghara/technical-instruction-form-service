using System.ComponentModel.DataAnnotations;

namespace technical_instruction_form_service.Models
{
    public class TechnicalInstruction
    {
        [Key]
        public int Id { get; set; }
        public DateTime? IssueDate { get; set; }
        public string? IssuedBy { get; set; } // Requestor Name
        public string? Title { get; set; }
        public string? CTINumber { get; set; }
        public int? RevisionNo { get; set; }
        public string? Purpose { get; set; }
        public string? ProductType { get; set; }
        public decimal? Quantity { get; set; }
        public string? Outline { get; set; }
        public DateTime? TISApplicabilityDate { get; set; }
        public string? LotNo { get; set; }

        //public List<string> RelatedDocuments { get; set; } // File paths
        public DateTime? ApplicationDate { get; set; } // Auto-filled
        public string? LotNoEnd { get; set; }
        //public List<string> Equipment { get; set; }
    }
}
