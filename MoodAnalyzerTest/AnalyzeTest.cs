using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzer;

namespace MoodAnalyzerTest
{
    [TestClass]
    public class AnalyzeTest
    {
        [TestMethod]
        public void ForSadMoodShouldReturnSad()
        {
            //Arrange
            string expected = "SAD";
            string message = "I am in Sad Mood";
            MoodAnalyse moodAnalyzer = new MoodAnalyse(message);

            //Act
            string mood = moodAnalyzer.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, mood);
        }
        [TestMethod]
        [DataRow(null)]
        public void GivenHappyMoodShouldReturnHappy(string message)
        {
            //Arrange
            string expected = "HAPPY";
            MoodAnalyse moodAnalyzer = new MoodAnalyse("I am in Happy Mood");
            //Act
            string mood = moodAnalyzer.AnalyseMood();
            //Assert
            Assert.AreEqual(expected, mood);
        }
        [TestMethod]
        public void GivenEmptyMoodShouldThrowMoodAnalyserExceptionShowingEmptyMood()
        {
            try
            {
                string message = "";
                MoodAnalyse moodAnalyse = new MoodAnalyse(message);
                string mood = moodAnalyse.AnalyseMood();
            }
            catch (MoodAnalyseException e)
            {
                Assert.AreEqual("Mood should not be empty!", e.Message);
            }
        }
        [TestMethod]
        public void GivenNullMoodShouldThrowMoodAnalyserExceptionShowingNullMood()
        {
            try
            {
                string message = null;
                MoodAnalyse moodAnalyse = new MoodAnalyse(message);
                string mood = moodAnalyse.AnalyseMood();
            }
            catch (MoodAnalyseException e)
            {
                Assert.AreEqual("Mood should not be null!", e.Message);
            }
        }
        [TestMethod]
        public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyseObject()
        {
            object expected = new MoodAnalyse();
            object obj = MoodAnalyseFactory.CreateMoodAnalyse("MoodAnalyzer.MoodAnalyse", "MoodAnalyse");
            expected.Equals(obj);
        }
        [TestMethod]
        public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyseObject_UsingParameters()
        {
            object expected = new MoodAnalyse("HAPPY");
            object obj = MoodAnalyseFactory.CreateMoodAnalysisUsingParameterizedConstructor("MoodAnalyzer.MoodAnalyse", "MoodAnalyse","HAPPY");
            expected.Equals(obj);
        }
        [TestMethod]
        public void GivenHappyMoodShouldReturnHappy()
        {
            string expected = "HAPPY";
            string mood = MoodAnalyseFactory.InvokeAnalyseMood("Happy", "AnalyseMood");
            Assert.AreEqual(expected, mood);
        }
        [TestMethod]
        public void GivenHappyMessageWithReflectorShouldReturnHappy()
        {
            string result = MoodAnalyseFactory.SetField("HAPPY", "message");
            Assert.AreEqual("HAPPY",result);
        }
    }
}
