using Entities.Entities;
using System;

namespace HowVI.Arguments
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public bool IsAutenticado { get; set; }
        public DateTime Validade { get; set; }
        public Vendedor vendedor { get; set; }
    }
}
