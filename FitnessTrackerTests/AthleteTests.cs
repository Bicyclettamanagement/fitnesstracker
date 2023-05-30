using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FitnessTracker;

namespace FitnessTrackerTests
{
    public class AthleteTests
    {
        [Theory]
        [InlineData(20010227)]
        public void GetAge_ReturnCorrectAge(int birthdayDate)
        {
            var birthdayYear = birthdayDate/10000;
            var birthdayMonth = birthdayDate % (birthdayYear * 10000) / 100;
            var birthdayDay = birthdayDate % (birthdayYear * 10000) % (birthdayMonth * 100);
            var testAthlete = new Athlete("testName", new DateTime(birthdayYear, birthdayMonth, birthdayDay), 80.0f);
            var currentDate = DateTime.Now;
            var currentDateInt = currentDate.Year*10000 + currentDate.Month*100 + currentDate.Day;
            var expectedAge = (currentDateInt - birthdayDate) / 10000;

            int actualAge = testAthlete.GetAge();

            Assert.Equal(expectedAge, actualAge);


        }
    }
}
