using System.ComponentModel.DataAnnotations;

namespace AP2_MVC_DOTNET.Models;

public class ErrorViewModel
{
    [Key]
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}