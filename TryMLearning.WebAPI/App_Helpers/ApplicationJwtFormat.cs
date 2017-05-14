//using System;
//using System.Collections.Generic;
//using System.IdentityModel.Tokens;
//using Microsoft.IdentityModel.Tokens;
//using Microsoft.Owin.Security;
//using Microsoft.Owin.Security.Jwt;
//using Microsoft.Owin.Security.OAuth;

//namespace TryMLearning.WebAPI.App_Helpers
//{
//    public class ApplicationJwtFormat : ISecureDataFormat<AuthenticationTicket>
//    {
//        private readonly JwtBearerAuthenticationOptions _jwtAuthOptions;
//        private readonly OAuthAuthorizationServerOptions _oAuthOptions;

//        public ApplicationJwtFormat(JwtBearerAuthenticationOptions jwtAuthOptions, OAuthAuthorizationServerOptions oAuthOptions)
//        {
//            _jwtAuthOptions = jwtAuthOptions;
//            _oAuthOptions = oAuthOptions;
//        }

//        public string SignatureAlgorithm
//        {
//            get { return "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256"; }
//        }

//        public string DigestAlgorithm
//        {
//            get { return "http://www.w3.org/2001/04/xmlenc#sha256"; }
//        }

//        public string Protect(AuthenticationTicket data)
//        {
//            if (data == null) throw new ArgumentNullException("data");

//            var issuer = "localhost";
//            var audience = "all";
//            var key = Convert.FromBase64String("UHxNtYMRYwvfpO1dS5pWLKL0M2DgOj40EbN4SoBWgfc");
//            var now = DateTime.UtcNow;
//            var expires = now.AddMinutes(_options.AccessTokenExpireTimeSpan.TotalMinutes);
//            var signingCredentials = new SigningCredentials(
//                new InMemorySymmetricSecurityKey(key),
//                SignatureAlgorithm,
//                DigestAlgorithm);
//            var token = new JwtSecurityToken(issuer, audience, data.Identity.Claims,
//                now, expires, signingCredentials);

//            return new JwtSecurityTokenHandler().WriteToken(token);
//        }

//        public AuthenticationTicket Unprotect(string protectedText)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}