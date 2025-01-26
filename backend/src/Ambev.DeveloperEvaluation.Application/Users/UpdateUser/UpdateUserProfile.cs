using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Users.UpdateUser
{
    public class UpdateUserProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for UpdateUser operation
        /// </summary>
        public UpdateUserProfile()
        {
            CreateMap<User, UpdateUserCommand>().ReverseMap();
            CreateMap<User, UpdateUserResult>();
        }
    }
}
