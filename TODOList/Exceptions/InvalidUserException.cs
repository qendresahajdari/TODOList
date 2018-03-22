using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TODOList.Exceptions
{
    public class InvalidUserException : Exception
    {
        public InvalidUserException()
        {

        }

        public InvalidUserException(string username)
            : base(String.Format("User already exist with username: {0}", username))
        {

        }
    }
}