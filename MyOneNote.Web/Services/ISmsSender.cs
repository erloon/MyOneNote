using System.Threading.Tasks;

namespace MyOneNote.API.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
