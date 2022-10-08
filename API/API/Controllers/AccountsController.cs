using API.Models;
using API.Models.ModelDBs;
using API.Models.ModelDTOs;
using API.Services;
using API.Services.IServices;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using Org.BouncyCastle.Asn1.Ocsp;

namespace API.Controllers
{
    [EnableCors("Allow CORS")]
    [Route("api/account")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;
        private readonly IStudentService _studentService;
        private readonly ITeacherService _teacherService;
        private readonly IUniversityService _universityService;

        public AccountsController(IAccountService accountService, IConfiguration configuration, IEmailService emailService, IStudentService studentService, ITeacherService teacherService, IUniversityService universityService)
        {
            this._accountService = accountService;
            this._configuration = configuration;
            this._emailService = emailService;
            _studentService = studentService;
            _teacherService = teacherService;
            _universityService = universityService;
        }
        [HttpPost("register")]
        public async Task<ActionResult> Register(AccountDTO request)
        {
            if(await _accountService.CheckExistEmail(request.Email))
            {
                return BadRequest("User Already Exist");
            }
            _accountService.CreatPasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            University university = await _universityService.GetUniversityById(request.University_Id);
            var newAccount = new Account
            {
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = request.Role,
                VerificationToken = _accountService.CreateRandomToken()
            };
            await _accountService.AddAsync(newAccount);

            if (request.Role == "Student")
            {
                var newStudent = new Student
                {
                    University = university,
                    VietnameseName = request.Full_Name,
                    Account = newAccount,
                    KatakanaName = request.Katakana_Name,
                };
                 await _studentService.AddAsync(newStudent);
               
                
            }
            else if(request.Role == "Teacher")
            {
                var newTeacher = new Teacher
                {
                    University = university,
                    Account = newAccount,
                    Teacher_Name = request.Full_Name,
                    Katakana_Name = request.Katakana_Name
                };
               await  _teacherService.AddAsync(newTeacher);

            }
            else if(request.Role == "Admin")
            {
                var newAdmin = new Admin
                {
                    Account = newAccount
                };
            }
            
            var sentEmail = new EmailDTO
            {
                To = newAccount.Email,
                Subject = "Verification Token",
                Body = newAccount.VerificationToken
            };
            _emailService.sendEmail(sentEmail);
            return Ok("Successfully created!");
        }
        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDTO request)
        {
            var loginAccount = await _accountService.GetByEmail(request.email);
            if (loginAccount != null)
            {
                if (_accountService.VerifyPasswordHash(request.password, loginAccount.PasswordHash, loginAccount.PasswordSalt))
                {
                    if (loginAccount.VerifiedAt == null)
                    {
                        return BadRequest("Not Verified");
                    }
                    string token = _accountService.CreateToken(loginAccount);
                    return Ok(token);
                }
                else
                {
                    return BadRequest("Password Is Incorrect");
                }
            }
            else
            {
                return BadRequest("User Not Found");
            }
            
        }
        [HttpPost("verify/{email}/{token}")]
        public async Task<ActionResult> Verify(string email ,string token)
        {
            var loginAccount = await _accountService.GetByEmail(email);
            if(loginAccount.VerificationToken != token)
            {
                return BadRequest("Invalid Token");
            }
            if(loginAccount.VerifiedAt != null)
            {
                return BadRequest("Already Verified");
            }
            loginAccount.VerifiedAt = DateTime.Now;
            _accountService.Update(loginAccount);
            return Ok();
        }
        [HttpPost("forgot-password/{email}")]
        public async Task<ActionResult> ForgotPassword(string email)
        {
            var loginAccount = await _accountService.GetByEmail(email);
            if(loginAccount == null)
            {
                return BadRequest("User Not Found");
            }
            loginAccount.ResetPasswordToken = _accountService.CreateRandomToken();
            loginAccount.ResetTokenExpires = DateTime.Now.AddMinutes(5);
            _accountService.Update(loginAccount);
            var sentEmail = new EmailDTO
            {
                To = email,
                Subject = "Reset Password Token",
                Body = "Your Token Will Be Expired In 5 minutes: " + loginAccount.ResetPasswordToken
            }; 
            _emailService.sendEmail(sentEmail);
            return Ok();
        }
        [HttpPut("reset-password")]
        public async Task<ActionResult> ResetPassword(ResetPasswordDTO request)
        {
            var loginAccount = await _accountService.GetByEmail(request.Email);
            if (loginAccount.ResetPasswordToken != request.ResetPasswordToken)
            {
                return BadRequest("Invalid Token");
            }
            if (loginAccount.ResetTokenExpires < DateTime.Now)
            {
                return BadRequest("Expired Token");
            }
            _accountService.CreatPasswordHash(request.NewPassword, out byte[] passwordHash, out byte[] passwordSalt);
            loginAccount.PasswordHash = passwordHash;
            loginAccount.PasswordSalt = passwordSalt;
            loginAccount.ResetPasswordToken = null;
            loginAccount.ResetTokenExpires = null;
            _accountService.Update(loginAccount);
            return Ok();
        }
    }
}
