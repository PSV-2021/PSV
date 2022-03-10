using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital.Service
{
    public class TokenGenerator
    {
        private String token { get; set; }
        private static Random random = new Random();

        public TokenGenerator() { }

        public String getNewToken() {

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 10)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        
        }
    }
}
