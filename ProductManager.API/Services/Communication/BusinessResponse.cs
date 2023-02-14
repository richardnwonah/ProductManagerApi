using ProductManager.API.Models;

namespace ProductManager.API.Services.Communication
{
    public class BusinessResponse : BaseResponse
    {
        public Business Business { get; private set; }

        private BusinessResponse(bool success, string message, Business business) : base(success, message)
        {
            Business = business;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="business">Saved Business.</param>
        /// <returns>Response.</returns>
        public BusinessResponse(Business business) : this(true, string.Empty, business)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public BusinessResponse(string message) : this(false, message, null)
        { }
    }
}