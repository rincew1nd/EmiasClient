using System;
using System.Text;

namespace EmiasClient.API.Helpers
{
    public static class Generators
    {
        private static Random _rnd = new Random(Guid.NewGuid().GetHashCode());
        
        public static string GenerateJsonRpcV2Id()
        {
            var id = new StringBuilder();
            for (var i = 0; i < 21; i++)
            {
                switch (_rnd.Next(0, 5))
                {
                    case 0:
                        id.Append((char) _rnd.Next(48, 58));
                        break;
                    case 1:
                        id.Append((char) _rnd.Next(65, 91));
                        break;
                    case 2:
                        id.Append((char) _rnd.Next(97, 123));
                        break;
                    case 3:
                        id.Append('-');
                        break;
                    case 4:
                        id.Append('_');
                        break;
                }
            }
            return id.ToString();
        }
    }
}