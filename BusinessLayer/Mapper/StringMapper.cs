using System;

namespace BusinessLayer.Mapper
{
    public static class StringMapper
    {
        public static byte[] ToBytes(this string base64)
        {
            return Convert.FromBase64String(base64);
        }
    }
}
