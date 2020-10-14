using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalyzer
{
    public class MoodAnalyseFactory
    {
        public static object CreateMoodAnalyse(string className,string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(className, pattern);

            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                catch (ArgumentNullException)
                {
                    throw new MoodAnalyseException(MoodAnalyseException.ExceptionType.NO_SUCH_CLASS, "Class not found");
                }
            }
            else
            {
                throw new MoodAnalyseException(MoodAnalyseException.ExceptionType.NO_SUCH_METHOD, "Constructors not found");
            }
        }
        public static object CreateMoodAnalysisUsingParameterizedConstructor(string className,string constructorName,string message)
        {
            Type type = typeof(MoodAnalyse);
            if(type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo ctor = type.GetConstructor(new[] { typeof(string) });
                    object instance = ctor.Invoke(new object[] { message });
                    return instance;
                }
                else
                {
                    throw new MoodAnalyseException(MoodAnalyseException.ExceptionType.NO_SUCH_METHOD, "Constructors not found");
                }
            }
            else
            {
                throw new MoodAnalyseException(MoodAnalyseException.ExceptionType.NO_SUCH_CLASS, "Class not found");
            }
        }
        public static string InvokeAnalyseMood(string message,string methodName)
        {
            try
            {
                Type type = Type.GetType("MoodAnalyzer.MoodAnalyse");
                object moodAnalyseObject = MoodAnalyseFactory.CreateMoodAnalysisUsingParameterizedConstructor("MoodAnalyzer.MoodAnalyse","MoodAnalyse",message);
                MethodInfo analyseMoodInfo = type.GetMethod(methodName);
                object mood = analyseMoodInfo.Invoke(moodAnalyseObject, null);
                return mood.ToString();

            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyseException(MoodAnalyseException.ExceptionType.NO_SUCH_METHOD, "Method Not Found");
            }
        }
    }
}
