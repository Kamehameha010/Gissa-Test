using GissaWeb.Models;
using GissaWeb.Models.ViewModel;
using GissaWeb.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;

namespace GissaWeb.Controllers
{
    public class RegisterController : Controller
    {
        private readonly TestGissaContext _context;
        private readonly DataTable dtPhone;
        private readonly DataTable dtSkill;
        public RegisterController(TestGissaContext context)
        {
            _context = context;

            dtPhone = new DataTable();
            dtPhone.Columns.Add("phoneId", typeof(int));
            dtPhone.Columns.Add("userId", typeof(int));
            dtPhone.Columns.Add("phoneNumber", typeof(int));

            dtSkill = new DataTable();
            dtSkill.Columns.Add("userSkillId", typeof(int));
            dtSkill.Columns.Add("userId", typeof(int));
            dtSkill.Columns.Add("softSkillId", typeof(int));
        }
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserRegister model)
        {
            int i = 0;
            foreach (var phone in model.Phones)
            {
                dtPhone.Rows.Add(i, i, phone.PhoneNumber);
                i++;
            }
            foreach (var skill in model.TestUserSkills)
            {
                dtPhone.Rows.Add(i, i, skill.SofSkill);
                i++;
            }
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Fullname", model.FullName),
                new SqlParameter("@CardId", model.CardId),
                new SqlParameter("@Username", model.Username),
                new SqlParameter("@Password", Encrypt.EncryptSha256(model.Password)),
                new SqlParameter("@Email", model.Email),
                new SqlParameter("@Rol", model.Rol),
                new SqlParameter("@TypeID", model.TypeId),
                new SqlParameter("@Phones", SqlDbType.Structured)
                {
                    Value = dtPhone,
                    TypeName = "dbo.test_type_phone"
                },
                new SqlParameter("@UserSkills", SqlDbType.Structured)
                {
                    Value = dtSkill,
                    TypeName = "dbo.test_type_user_skills"
                }
        };

            _context.Database.ExecuteSqlRaw(@"test_user_register @Fullname, @CardId, @Username,
                @Password,@Email,@Rol,@TypeID,@Phones,@UserSkills", parameters);

            return Ok();

        }


        [HttpPost]
        public IActionResult Update([FromBody] UserRegister model)
        {
            int i = 0;
            foreach (var phone in model.Phones)
            {
                dtPhone.Rows.Add(phone.PhoneId, model.UserId, phone.PhoneNumber);
                i++;
            }
            foreach (var skill in model.TestUserSkills)
            {
                dtPhone.Rows.Add(skill.UserSkillId, model.UserId, skill.SofSkill);
                i++;
            }
            var parameters = new SqlParameter[]
            {

                new SqlParameter("@UserId", model.UserId),
                new SqlParameter("@Fullname", model.FullName),
                new SqlParameter("@CardId", model.CardId),
                new SqlParameter("@Username", model.Username),
                new SqlParameter("@Password", Encrypt.EncryptSha256(model.Password)),
                new SqlParameter("@Email", model.Email),
                new SqlParameter("@Phones", SqlDbType.Structured)
                {
                    Value = dtPhone,
                    TypeName = "dbo.test_type_phone"
                },
                new SqlParameter("@Rol", model.Rol),
                new SqlParameter("@TypeID", model.TypeId),
                new SqlParameter("@IsActive", model.IsActive),
                new SqlParameter("@UserSkills", SqlDbType.Structured)
                {
                    Value = dtSkill,
                    TypeName = "dbo.test_type_user_skills"
                }
        };

            _context.Database.ExecuteSqlRaw(@"test_user_update @UserId @Fullname, @CardId, @Username,
                @Password,@Email,@¨Phones,@Rol,@TypeID,@IsActive,@UserSkills", parameters);
            return Ok();
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var param = new SqlParameter("@UserId", id);

            _context.Database.ExecuteSqlRaw(@"test_user_delete @UserId", param);

            return Ok();
        }

    }
}
