using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UpdateUserResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;

        /// <summary>
        /// Initializes a new instance of UpdateUserHandler
        /// </summary>
        /// <param name="userRepository">The user    repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        /// <param name="validator">The validator for CreateUserCommand</param>
        public UpdateUserHandler(IUserRepository userRepository, IMapper mapper, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        /// <summary>
        /// Handles the UpdateUserCommand request
        /// </summary>
        /// <param name="command">The UpdateUser command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created user details</returns>
        public async Task<UpdateUserResult> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpdateUserValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var existingUser = await _userRepository.GetByIdAsync(command.Id, cancellationToken);
            if (existingUser == null)
                throw new InvalidOperationException($"User with id {command.Id} not exists");

            existingUser.SetUsername(command.Username);
            existingUser.SetEmail(command.Email);
            existingUser.SetPhone(command.Phone);
            existingUser.SetRole(command.Role);
            existingUser.SetStatus(command.Status);

            if (!string.IsNullOrEmpty(command.Password))
                existingUser.SetPassword(_passwordHasher.HashPassword(command.Password));

            var updatedUser = await _userRepository.UpdateAsync(existingUser, cancellationToken);
            var result = _mapper.Map<UpdateUserResult>(updatedUser);
            return result;
        }
    }
}
