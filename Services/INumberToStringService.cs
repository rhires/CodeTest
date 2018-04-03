using codeTest.Models;

namespace codeTest.Services
{
    public interface INumberToStringService
    {
         NumberModel ConvertNumberToString(string startingNumber);
    }
}