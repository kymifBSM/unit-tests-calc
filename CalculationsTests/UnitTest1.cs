namespace CalculationsTests
{
    [TestClass]
    public class UnitTest1
    {
        string[] startTimes = { "10:00", "11:00", "15:00", "15:30", "16:50" };
        string[] incorrectStartTimes = { "10:00", "10:20", "11:00", "15:00", "15:30", "16:50" };
        string[] emptyStartTimes = { };

        int[] durations = { 60, 60, 30, 10, 10, 40 };
        int[] emptyDurations = { };

        string
        beginWorkingTime = "08:00";
        string
        endWorkingTime = "18:00";

        int consultationTime = 30;
        int incorrectConsultationTime = 0;

        [TestMethod]
        public void AssertLength()
        {
            string[] expected = { "08:00 - 08:30", "08:30 - 09:00", "09:00 - 09:30", "09:30 - 10:00", "11:30 - 12:00", "12:00 - 12:30", "12:30 - 13:00", "13:00 - 13:30", "13:30 - 14:00", "14:00 - 14:30", "14:30 - 15:00", "15:40 - 16:10", "16:10 - 16:40", "17:30 - 18:00" };
            string[] actual = Calculations.Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);

            Assert.AreEqual(expected.Length, actual.Length);
        }

        [TestMethod]
        public void AssertCollections()
        {
            string[] expected = { "08:00 - 08:30", "08:30 - 09:00", "09:00 - 09:30", "09:30 - 10:00", "11:30 - 12:00", "12:00 - 12:30", "12:30 - 13:00", "13:00 - 13:30", "13:30 - 14:00", "14:00 - 14:30", "14:30 - 15:00", "15:40 - 16:10", "16:10 - 16:40", "17:30 - 18:00" };
            string[] actual = Calculations.Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PassEmptyStartTimes()
        {
            string[]? expected = null;
            string[] actual = Calculations.Calculations.AvailablePeriods(emptyStartTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PassEmptyDurations()
        {
            string[]? expected = null;
            string[] actual = Calculations.Calculations.AvailablePeriods(startTimes, emptyDurations, beginWorkingTime, endWorkingTime, consultationTime);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PassTooEarlyTimes()
        {
            string[]? expected = null;
            string[] actual = Calculations.Calculations.AvailablePeriods(new string[] { "07:00 - 08:00" }, durations, beginWorkingTime, endWorkingTime, consultationTime);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PassTooLateTimes()
        {
            string[]? expected = null;
            string[] actual = Calculations.Calculations.AvailablePeriods(new string[] { "19:00 - 20:00" }, durations, beginWorkingTime, endWorkingTime, consultationTime);

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
    "Passed incorrect consultation time")]
        public void PassIncorrectConsultationTime()
        {
            string[] actual = Calculations.Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, incorrectConsultationTime);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
"Passed incorrect start time is busy")]
        public void PassIncorrectStartTimes()
        {
            string[] actual = Calculations.Calculations.AvailablePeriods(incorrectStartTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
        }

        [TestMethod]
        public void PassTooShortWorkingDay()
        {
            string[]? expected = null;
            string tooShortBeginWorkingTime = "10:00";
            string tooShortEndWorkingTime = "12:00";

            string[] actual = Calculations.Calculations.AvailablePeriods(startTimes, durations, tooShortBeginWorkingTime, tooShortEndWorkingTime, consultationTime);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateWorkingHours()
        {
            string incorrectBeginWorkingTime = "18:00";
            string incorrectEndWorkingTime = "08:00";
            string[]? expected = null;

            string[] actual = Calculations.Calculations.AvailablePeriods(startTimes, durations, incorrectBeginWorkingTime, incorrectEndWorkingTime, consultationTime);

            Assert.AreEqual(expected, actual);
        }
    }
}