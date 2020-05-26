using Microsoft.VisualStudio.TestTools.UnitTesting;
using DomainLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Domain.Tests
{
    [TestClass()]
    public class RunningSessionTests
    {
        [TestMethod()]
        public void RunningSessionTest_AverageSpeed_WhenCalculated()
        {

            DateTime when = DateTime.Now;
            int distance = 1000;
            TimeSpan time = new TimeSpan(0, 6, 0);
            float? averageSpeed = null;
            TrainingType trainingType = TrainingType.Endurance;
            string comment = "";
            float? expected = 10;
            //Act
            RunningSession rs = new RunningSession(when, distance, time, averageSpeed, trainingType, comment);

            //Assert
            Assert.AreEqual(expected, rs.AverageSpeed);
        }
    }
}