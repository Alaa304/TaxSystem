using Core;
using Core.Domain.Entities;
using Core.Services.Abstraction;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

using System.Security.Claims;
using System.Text;

namespace Infrastructure.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public AuthService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<string> AuthenticateAsync(string username, string password)
        {
            // 1️⃣ جلب الموظف من قاعدة البيانات
            var employeeRepo = _unitOfWork.GetRepository<Employee, int>();
            var employee = (await employeeRepo.GetAllAsync())
                            .FirstOrDefault(e => e.Username == username);

            if (employee == null || employee.PasswordHash != password)
                throw new Exception("اسم المستخدم أو كلمة المرور غير صحيحة");

            // 2️⃣ إعداد Claims للـ JWT
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, employee.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, employee.Username),
                new Claim("FullName", employee.FullName)
                // ممكن تضيف Role هنا لو عندك
            };

            // 3️⃣ توليد المفتاح
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // 4️⃣ إعداد Token
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(double.Parse(_configuration["Jwt:ExpireMinutes"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
