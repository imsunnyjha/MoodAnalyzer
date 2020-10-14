using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzer
{
    public class MoodAnalyse
    {
       public string message;
        public MoodAnalyse(string message)
        {
            this.message = message;
        }
        public MoodAnalyse()
        {

        }
        public string AnalyseMood()
        {
            try
            {
                if (this.message.Equals(string.Empty))
                {
                    throw new MoodAnalyseException(MoodAnalyseException.ExceptionType.ENTERED_EMPTY, "Mood should not be empty!");
                }
                if (this.message.Contains("Sad"))
                    return "SAD";
                else
                    return "HAPPY";
            }
            catch(NullReferenceException)
            {
                throw new MoodAnalyseException(MoodAnalyseException.ExceptionType.ENTERED_NULL, "Mood should not be null!");
            }
        }
    }
}
