using AirTiquiciaAPP.Shared;
using System.Threading.Tasks;

namespace AirTiquiciaAPP.Server.Services
{
    public interface IEmailSenderService
    {
        Task<int> SendEmailAsync(DatosCorreo datosCorreo);
    }
}
