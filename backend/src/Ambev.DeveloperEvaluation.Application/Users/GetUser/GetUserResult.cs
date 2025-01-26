using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Users.GetUser;

/// <summary>
/// Response model for GetUser operation
/// </summary>
public class GetUserResult
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

    /// <summary>
    /// The user's Name
    /// </summary>    
    public NameResult Name { get; set; } = new NameResult();

    /// <summary>
    /// The user's Address
    /// </summary> 
    public AddressResult Address { get; set; } = new AddressResult();

    public class NameResult
    {
        /// <summary>
        /// The user's first name
        /// </summary>
        public string First { get; set; } = string.Empty;

        /// <summary>
        /// The user's last name
        /// </summary>
        public string Last { get; set; } = string.Empty;
    }

    public class AddressResult
    {
        /// <summary>
        /// The user's Address City
        /// </summary>
        public string City { get; set; } = string.Empty;
        
        /// <summary>
        /// The user's Address Street
        /// </summary>
        public string Street { get; set; } = string.Empty;

        /// <summary>
        /// The user's Address Number
        /// </summary>
        public string Number { get; set; } = string.Empty;

        /// <summary>
        /// The user's Address Zipcode
        /// </summary>
        public string Zipcode { get; set; } = string.Empty;

        /// <summary>
        /// The user's Address Geolocation
        /// </summary> 
        public GeolocationResult Geolocation { get; set; } = new GeolocationResult();
    }

    public class GeolocationResult
    {
        /// <summary>
        /// The user's Address Lat
        /// </summary>
        public string Lat { get; set; } = string.Empty;

        /// <summary>
        /// The user's Address Long
        /// </summary>
        public string Long { get; set; } = string.Empty;        
    }
}
