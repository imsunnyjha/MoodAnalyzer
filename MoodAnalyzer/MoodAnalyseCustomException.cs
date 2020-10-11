using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzer
{
    public class MoodAnalyseException : Exception
    {
        public enum ExceptionType
        {
            ENTERED_NULL, ENTERED_EMPTY,
            NO_SUCH_FIELD, NO_SUCH_METHOD,
            NO_SUCH_CLASS, OBJECT_CREATION_ISSUE
        }
        private readonly ExceptionType type;

        ///<param name="type"></param>
        ///<param name="message"></param>
        public MoodAnalyseException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
