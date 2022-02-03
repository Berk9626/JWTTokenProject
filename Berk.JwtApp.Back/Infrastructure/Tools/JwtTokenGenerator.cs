﻿using Berk.JwtApp.Back.Core.Application.DTO;
using Berk.JwtApp.Back.Core.Domain;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Berk.JwtApp.Back.Infrastructure.Tools
{
    public class JwtTokenGenerator
    {
        public static JwtTokenResponse GenerateToken(CheckUserResponseDto dto)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenSettings.Key));
            SigningCredentials credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);


            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, dto.Role)); //gelen role bilgisine göre tokenımız oluşacak
            claims.Add(new Claim(ClaimTypes.Name, dto.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, dto.Id.ToString()));




            JwtSecurityToken token = new JwtSecurityToken(issuer:JwtTokenSettings.Issuer, audience: JwtTokenSettings.Audience, claims:claims,
                notBefore:DateTime.Now, expires: DateTime.Now.AddDays(JwtTokenSettings.Expire), signingCredentials: credentials);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return new JwtTokenResponse (handler.WriteToken(token));
        
        }

    }
}
