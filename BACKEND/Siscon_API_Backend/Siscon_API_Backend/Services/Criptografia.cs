using System.Text;

namespace Siscon_API_Backend.Services
{
    public class Criptografia
    {
        public static string StringToBase64(string texto)
        {
            byte[] textoBytes = Encoding.UTF8.GetBytes(texto);
            string base64Texto = Convert.ToBase64String(textoBytes);
            return base64Texto;
        }

        public static string Base64ToString(string base64Texto)
        {
            byte[] base64Bytes = Convert.FromBase64String(base64Texto);
            string textoDecodificado = Encoding.UTF8.GetString(base64Bytes);
            return textoDecodificado;
        }
    }
}
