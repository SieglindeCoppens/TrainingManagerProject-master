using Microsoft.VisualStudio.TestTools.UnitTesting;
using DomainLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Domain.Tests
{
    [TestClass()]
    public class CyclingSessionTests
    {
        [TestMethod()]
        public void CyclingSessionTest_AverageSpeed_WhenCalculated()
        {
            
            DateTime when = DateTime.Now;
            int distance = 50;
            TimeSpan time = new TimeSpan(4, 0, 0);
            float? averageSpeed = null;
            int? averageWatt = null;
            TrainingType trainingType = TrainingType.Endurance;
            string comment = "";
            BikeType bt = BikeType.CityBike;
            float? expected = 12.5F;
            //Act
            CyclingSession cs = new CyclingSession(when, distance, time, averageSpeed, averageWatt, trainingType, comment, bt);

            //Assert
            Assert.AreEqual(expected, cs.AverageSpeed);
        }
    }
}