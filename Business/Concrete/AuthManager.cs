using Business.Abstract;
using Core.Utilities.Security.Hashing;
using Entities.Concrete;
using Entities.DTOs;
using System;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IWriterService _writerService;

        public AuthManager(IUserService userService, IWriterService writerService)
        {
            _userService = userService;
            _writerService = writerService;
        }

        public User Login(UserForLoginDto userForLoginDto)
        {
            var user = _userService.GetByMail(userForLoginDto.Email);
            if (user == null)
            {
                return null;
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            return user;
        }

        public User Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePassswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                Email = userForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            _userService.Add(user);

            var writer = new Writer
            {
                UserId = user.UserId,
            };

            _writerService.Add(writer);

            return user;
        }

        public bool UserExists(string email)
        {
            return _userService.GetByMail(email) == null ? true : false;
        }
    }
}
