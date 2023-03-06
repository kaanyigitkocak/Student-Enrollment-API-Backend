using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Castle.Core.Resource;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserOperationClaimService _userOperationClaimService;
        private readonly IUserService _userService;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper,
            IUserOperationClaimService userOperationClaimService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _userOperationClaimService = userOperationClaimService;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var newUser = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(newUser);
           

            return new SuccessDataResult<User>();
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheckResult = _userService.GetByMail(userForLoginDto.Email);
            if (!userToCheckResult.Success) return new ErrorDataResult<User>();

            var userToCheck = userToCheckResult.Data;
            if (userToCheck == null) return new ErrorDataResult<User>();

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash,
                userToCheck.PasswordSalt)) return new ErrorDataResult<User>();

            return new SuccessDataResult<User>(userToCheck);
        }

        public IResult UserExists(string email)
        {
            var userResult = _userService.GetByMail(email);
            if (!userResult.Success) return new ErrorResult();
            if (userResult.Data != null) return new ErrorResult();

            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claimsResult = _userService.GetClaims(user);
            if (!claimsResult.Success) return new ErrorDataResult<AccessToken>();
            var accessToken = _tokenHelper.CreateToken(user, claimsResult.Data);

            return new SuccessDataResult<AccessToken>(accessToken,"token olusturuldu");
        }

        
    }
}
