using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebUI.Model;

namespace ZAlpha.Infrastructure.Repositories;
public interface IAccountRepository
{
    public Task<IdentityResult> SignUpAsync(SignUpModel model);
    public Task<string> SignInAsync(SignInModel model);

}
