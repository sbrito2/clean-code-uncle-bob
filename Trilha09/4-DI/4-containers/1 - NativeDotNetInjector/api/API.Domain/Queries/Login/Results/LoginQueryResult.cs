
namespace API.Domain.Queries.Login.Results
{
    public class LoginQueryResult
    {
        public string Token { get; set; }
        public bool Succeeded { get; set; }

        public LoginQueryResult SetSucceeded()
        {
            this.Succeeded = true;
            return this;
        }

        public LoginQueryResult SetNotSucceeded()
        {
            this.Succeeded = false;
            return this;
        }
    }
}
