using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProfiles.Dtos
{
    public class UserProfileGetByIdDto
    {
        public int UserId { get; set; }
        public string GithubAddress { get; set; }
    }
}
