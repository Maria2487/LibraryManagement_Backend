using AutoMapper;
using LibraryManagement.Application.DTOs.Account;
using LibraryManagement.Application.DTOs.User;
using LibraryManagement.Application.Security.Utils;
using LibraryManagement.Application.Services.Interfaces;
using LibraryManagement.Domain.Entities.RegularEntities;
using LibraryManagement.Infrastructure.Repositories.Interfaces;
using LibraryManagement.Utils;

namespace LibraryManagement.Application.Services
{
    public class UserService : IUserService
    {
        public readonly IUserRepository userRepository;
        public readonly IMembershipRepository membershipRepository;
        public readonly IMapper mapper;
        public readonly IJwtUtils jwtUtils;
        public readonly IAzureStorageService storageService;

        public UserService(IUserRepository userRepository, IMembershipRepository membershipRepository, IMapper mapper, IJwtUtils jwtUtils, IAzureStorageService storageService)
        {
            this.userRepository = userRepository;
            this.membershipRepository = membershipRepository;
            this.mapper = mapper;
            this.jwtUtils = jwtUtils;
            this.storageService = storageService;
        }

        public async Task<CreateUserResponseDto> Create(CreateUserDto userDto)
        {
            var entity = mapper.Map<User>(userDto);
            entity.Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password);

            var image = entity.MemberPhoto;
            entity.MemberPhoto = string.Empty;

            var user = await userRepository.Create(entity);

            //var test = await storageService.UploadAsync(image, user.Id.ToString());

            //user.MemberPhoto = test;

            //var membership = await membershipRepository.Create(new Membership
            //{
            //    StartDate = DateTime.UtcNow,
            //    MemberId = user.Id,
            //    Member = user
            //});
            //user.MembershipId = membership.Id;
            //user.Membership = membership;

            //user = await userRepository.Update(user);

            return mapper.Map<CreateUserResponseDto>(user);
        }

        public async Task Delete(Guid id)
        {
            var user = await userRepository.GetById(id);

            if (user is null)
            {
                throw new KeyNotFoundException();
            }

            await userRepository.Delete(user);
        }

        public async Task<List<CreateUserResponseDto>> GetAll()
        {
            var users = await userRepository.GetAll();

            //foreach (var user in users)
            //{
            //    user.MemberPhoto = await storageService.GetImageByNameAsync(user.Id.ToString());
            //}

            return mapper.Map<List<CreateUserResponseDto>>(users);
        }

        public async Task<CreateUserResponseDto> GetById(Guid id)
        {
            var user = await userRepository.GetById(id);

            if (user is null)
            {
                throw new Exception(Constants.UserWasNotFound);
            }

            //user.ProfilePicture = await storageService.GetImageByNameAsync(user.Id.ToString());

            return mapper.Map<CreateUserResponseDto>(user);
        }

        public async Task<CreateUserResponseDto> Update(Guid id, UpdateUserDto userDto)
        {
            var user = await userRepository.GetById(id);

            if (user is null)
            {
                throw new KeyNotFoundException();
            }

            mapper.Map(userDto, user);
            await userRepository.Update(user);

            return mapper.Map<CreateUserResponseDto>(user);
        }

        //Authorization
        public async Task<LoginResponseDto> Login(LoginDto loginData)
        {
            var user = await userRepository.GetByEmail(loginData.Email);

            if (user is null)
            {
                throw new Exception(Constants.UserWasNotFound);
            }

            if (!BCrypt.Net.BCrypt.Verify(loginData.Password, user.Password))
            {
                throw new Exception(Constants.InvalidPassword);
            }

            var token = jwtUtils.GenerateToken(user);

            return new LoginResponseDto
            {
                Token = token,
                FirstName = user.FirstName,
                LastName = user.LastName,
                ProfilePicture = user.MemberPhoto
            };
        }
    }
}
