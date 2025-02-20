using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusOnLife.Application.DTO.Auth
{
    public class AuthResponseDto
    {
        public bool Success { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
        public IList<string> Errors { get; set; } = new List<string>();
    }
}
