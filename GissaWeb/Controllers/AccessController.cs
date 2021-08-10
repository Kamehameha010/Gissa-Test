using GissaWeb.Models;
using GissaWeb.Models.ViewModel;
using GissaWeb.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GissaWeb.Controllers
{
    public class AccessController : Controller
    {
        private readonly TestGissaContext _context;
        public AccessController(TestGissaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUser model)
        {
            var t = Encrypt.EncryptSha256("123");
            Response response = new Response
            {
                Data = await _context.TestUsers.Where(x => x.Username.Contains(model.Username) && x.Password.Contains(Encrypt.EncryptSha256(model.Password))).FirstOrDefaultAsync()
            };
            
            return Ok(response);
        }




    }
}
