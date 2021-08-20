using System;
using System.Runtime.Serialization;

namespace Lesson10
{
    public class UserEmptyException : Exception
    {
        // НЕ РОБИ ТАК!
        public User User { get; set; }

        public override string Message
        {
            get
            {
                return User.Username;
            }
        }

        public UserEmptyException(User user) // : base(user.Username)
        {
            User = user;
        }
        // НЕ РОБИ ТАК!

        public UserEmptyException()
        {
        }

        public UserEmptyException(string message) : base(message)
        {
        }

        public UserEmptyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserEmptyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
