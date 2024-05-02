using System.ComponentModel.DataAnnotations;

namespace BlazorWASMPhoneBook.Shared.Models;

public class ContactModel
    {
    [Key]
    public long ContactID { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    [MaxLength(50)]
    public string Family { get; set; }

    [MaxLength(50)]
    [EmailAddress]
    public string? Email { get; set; }

    [MaxLength(13)]
    public string? PhoneNumber { get; set; }

    [MaxLength(13)]
    public string? CellphoneNumber { get; set; }

    [MaxLength(300)]
    public string? Address { get; set; }

    public string FullName => Name + " " + Family;
    }