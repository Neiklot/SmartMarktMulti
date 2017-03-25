using System.Threading.Tasks;

namespace SmartMarkt
{
    public interface IQrCodeScanningService
    {
        Task<string> ScanAsync();
    }
}