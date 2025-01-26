using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using static Ambev.DeveloperEvaluation.Application.Users.ListUsers.ListUsersResult;

namespace Ambev.DeveloperEvaluation.Application.Users.ListUsers;

/// <summary>
/// Handler for processing ListUsersCommand requests
/// </summary>
public class ListUsersHandler : IRequestHandler<ListUsersCommand, ListUsersResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of ListUsersHandler
    /// </summary>
    /// <param name="userRepository">The user repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for GetUserCommand</param>
    public ListUsersHandler(
        IUserRepository userRepository,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetUserCommand request
    /// </summary>
    /// <param name="request">The GetUser command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The user details if found</returns>
    public async Task<ListUsersResult> Handle(ListUsersCommand request, CancellationToken cancellationToken)
    {
        var validator = new ListUsersValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        var orderDescending = request.Order?.Contains("desc") ?? false;
        var users = await _userRepository.GetPagedUsersAsync(request.Page, request.Size, request.Order, orderDescending, cancellationToken);
        var totalUsers = await _userRepository.GetTotalUsersCountAsync(cancellationToken);

        var result = new ListUsersResult
        {
            Users = _mapper.Map<List<UserResult>>(users),
            CurrentPage = request.Page,
            TotalPages = request.Size,
            TotalItems = totalUsers
        };

        return result;
    }
}
