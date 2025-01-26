using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Users.ListUsers;

/// <summary>
/// Response model for ListUsers operation
/// </summary>
public class ListUsersResult
{
    public List<UserResult> Users { get; set; } = new List<UserResult>();
    
    /// <summary>
    /// Total items in the list
    /// </summary>
    public int TotalItems { get; set; }

    /// <summary>
    /// Current page
    /// </summary>
    public int CurrentPage { get; set; }

    /// <summary>
    /// Total pages
    /// </summary>
    public int TotalPages { get; set; }

    public class UserResult
    {
        /// <summary>
        /// The unique identifier of the user
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The user's full name
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// The user's email address
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// The user's phone number
        /// </summary>
        public string Phone { get; set; } = string.Empty;

        /// <summary>
        /// The user's role in the system
        /// </summary>
        public UserRole Role { get; set; }

        /// <summary>
        /// The current status of the user
        /// </summary>
        public UserStatus Status { get; set; }
    }
}
