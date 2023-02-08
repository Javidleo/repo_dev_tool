using System.Runtime.Serialization;

namespace repo.Exceptions
{
    [Serializable]
    public class InvalidSwitchException : Exception
    {
        public InvalidSwitchException(string? message) : base(message)
        {
        }
    }
}