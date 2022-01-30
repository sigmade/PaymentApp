using Application.MoblieProviders;

namespace Application.Models
{
    public class ProviderResponse
    {
        public Provider Provider { get; set; }
        public ResponseStatus Status { get; set; } 
    }

    public enum ResponseStatus
    {
        Success,
        Cancelled
    }
}
