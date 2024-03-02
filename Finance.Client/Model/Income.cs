using System.ComponentModel.DataAnnotations;

namespace Finance.Client.Model;

public class Income
{
    public int Id { get; set; }

	[Required]
	[Range(1, 2000000 )]
	public decimal Amount { get; set; }

	public DateOnly Date { get; set; }
	
	[Required]
	[MaxLength(50)]
	public required string Category { get; set; }

	[Required]
	[MaxLength(50)]
	public required string Currency { get; set; } 
}
