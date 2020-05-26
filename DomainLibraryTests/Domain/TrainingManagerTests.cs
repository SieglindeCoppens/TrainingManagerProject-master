using Microsoft.VisualStudio.TestTools.UnitTesting;
using DomainLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;
using Shouldly;

namespace DomainLibrary.Domain.Tests
{
    [TestClass()]
    public class TrainingManagerTests
    {
        TrainingManager _tm;
        [TestInitialize]
        public void Initialize()
        {
            _tm = new TrainingManager(new UnitOfWork(new TrainingContextTest(false))); ;
        }

        [TestMethod()]
        public void AddCyclingTrainingTest_ShouldTrowDomainException_IfDateTimeIsInFuture()
        {
            //Arrange
            DateTime when = DateTime.Now.AddDays(1);
            float? distance = null;
            TimeSpan time = new TimeSpan(2, 30, 3);
            float? averageSpeed = null;
            int? averageWatt = null;
            TrainingType trainingType = TrainingType.Endurance;
            string comment = "";
            BikeType bikeType = BikeType.CityBike;

            //Act
            try
            {
                _tm.AddCyclingTraining(when, distance, time, averageSpeed, averageWatt, trainingType, comment, bikeType);
            }
            catch (DomainException e)
            {
                //Assert
                StringAssert.Contains(e.Message, "Training is in the future");
                return;
            }
            Assert.Fail("The expected exception was not thrown");

        }
        [TestMethod()]
        public void AddCyclingTrainingTest_ShouldTrowDomainException_IfDistanceTooBig()
        {
            //Arrange
            DateTime when = DateTime.Now;
            float? distance = -3;
            TimeSpan time = new TimeSpan(2, 30, 3);
            float? averageSpeed = null;
            int? averageWatt = null;
            TrainingType trainingType = TrainingType.Endurance;
            string comment = "";
            BikeType bikeType = BikeType.CityBike;
            //Act
            try
            {
                _tm.AddCyclingTraining(when, distance, time, averageSpeed, averageWatt, trainingType, comment, bikeType);
            }
            catch (DomainException e)
            {
                //Assert
                StringAssert.Contains(e.Message, "Distance invalid value");
                return;
            }
            Assert.Fail("The expected exception was not thrown");
        }
        [TestMethod()]
        public void AddCyclingTrainingTest_ShouldTrowDomainException_IfDistanceTooSmall()
        {
            //Arrange
            DateTime when = DateTime.Now;
            float? distance = 502;
            TimeSpan time = new TimeSpan(2, 30, 3);
            float? averageSpeed = null;
            int? averageWatt = null;
            TrainingType trainingType = TrainingType.Endurance;
            string comment = "";
            BikeType bikeType = BikeType.CityBike;
            //Act
            try
            {
                _tm.AddCyclingTraining(when, distance, time, averageSpeed, averageWatt, trainingType, comment, bikeType);
            }
            catch (DomainException e)
            {
                //Assert
                StringAssert.Contains(e.Message, "Distance invalid value");
                return;
            }
            Assert.Fail("The expected exception was not thrown");
        }
        [TestMethod()]
        public void AddCyclingTrainingTest_ShouldTrowDomainException_IfTimeBelow0()
        {
            //Arrange
            DateTime when = DateTime.Now;
            float? distance = 30;
            TimeSpan time = new TimeSpan(-3);
            float? averageSpeed = null;
            int? averageWatt = null;
            TrainingType trainingType = TrainingType.Endurance;
            string comment = "";
            BikeType bikeType = BikeType.CityBike;
            //Act
            try
            {
                _tm.AddCyclingTraining(when, distance, time, averageSpeed, averageWatt, trainingType, comment, bikeType);
            }
            catch (DomainException e)
            {
                //Assert
                StringAssert.Contains(e.Message, "Time invalid value");
                return;
            }
            Assert.Fail("The expected exception was not thrown");
        }
        [TestMethod()]
        public void AddCyclingTrainingTest_ShouldTrowDomainException_IfTimeOver20()
        {
            //Arrange
            DateTime when = DateTime.Now;
            float? distance = 30;
            TimeSpan time = new TimeSpan(24, 0, 0);
            float? averageSpeed = null;
            int? averageWatt = null;
            TrainingType trainingType = TrainingType.Endurance;
            string comment = "";
            BikeType bikeType = BikeType.CityBike;
            //Act
            try
            {
                _tm.AddCyclingTraining(when, distance, time, averageSpeed, averageWatt, trainingType, comment, bikeType);
            }
            catch (DomainException e)
            {
                //Assert
                StringAssert.Contains(e.Message, "Time invalid value");
                return;
            }
            Assert.Fail("The expected exception was not thrown");
        }
        [TestMethod()]
        public void AddCyclingTrainingTest_ShouldTrowDomainException_IfSpeedBelow0()
        {
            //Arrange
            DateTime when = DateTime.Now;
            float? distance = 30;
            TimeSpan time = new TimeSpan(3, 0, 0);
            float? averageSpeed = -3;
            int? averageWatt = null;
            TrainingType trainingType = TrainingType.Endurance;
            string comment = "";
            BikeType bikeType = BikeType.CityBike;
            //Act
            try
            {
                _tm.AddCyclingTraining(when, distance, time, averageSpeed, averageWatt, trainingType, comment, bikeType);
            }
            catch (DomainException e)
            {
                //Assert
                StringAssert.Contains(e.Message, "Average speed invalid value");
                return;
            }
            Assert.Fail("The expected exception was not thrown");
        }
        [TestMethod()]

        public void AddCyclingTrainingTest_ShouldTrowDomainException_IfSpeedOver60()
        {
            //Arrange
            DateTime when = DateTime.Now;
            float? distance = 30;
            TimeSpan time = new TimeSpan(3, 0, 0);
            float? averageSpeed = 70;
            int? averageWatt = null;
            TrainingType trainingType = TrainingType.Endurance;
            string comment = "";
            BikeType bikeType = BikeType.CityBike;
            //Act
            try
            {
                _tm.AddCyclingTraining(when, distance, time, averageSpeed, averageWatt, trainingType, comment, bikeType);
            }
            catch (DomainException e)
            {
                //Assert
                StringAssert.Contains(e.Message, "Average speed invalid value");
                return;
            }
            Assert.Fail("The expected exception was not thrown");
        }
        [TestMethod()]
        public void AddCyclingTrainingTest_ShouldTrowDomainException_IfWattBelow0()
        {
            //Arrange
            DateTime when = DateTime.Now;
            float? distance = 30;
            TimeSpan time = new TimeSpan(3, 0, 0);
            float? averageSpeed = 10;
            int? averageWatt = -3;
            TrainingType trainingType = TrainingType.Endurance;
            string comment = "";
            BikeType bikeType = BikeType.CityBike;
            //Act
            try
            {
                _tm.AddCyclingTraining(when, distance, time, averageSpeed, averageWatt, trainingType, comment, bikeType);
            }
            catch (DomainException e)
            {
                //Assert
                StringAssert.Contains(e.Message, "Average watt invalid value");
                return;
            }
            Assert.Fail("The expected exception was not thrown");
        }
        [TestMethod()]
        public void AddCyclingTrainingTest_ShouldTrowDomainException_IfWattOver800()
        {
            //Arrange
            DateTime when = DateTime.Now;
            float? distance = 30;
            TimeSpan time = new TimeSpan(3, 0, 0);
            float? averageSpeed = 10;
            int? averageWatt = 801;
            TrainingType trainingType = TrainingType.Endurance;
            string comment = "";
            BikeType bikeType = BikeType.CityBike;
            //Act
            try
            {
                _tm.AddCyclingTraining(when, distance, time, averageSpeed, averageWatt, trainingType, comment, bikeType);
            }
            catch (DomainException e)
            {
                //Assert
                StringAssert.Contains(e.Message, "Average watt invalid value");
                return;
            }
            Assert.Fail("The expected exception was not thrown");
        }
        [TestMethod()]
        public void AddRunningTrainingTest_ShouldTrowDomainException_IfDateTimeIsInFuture()
        {
            //Arrange
            DateTime when = DateTime.Now.AddDays(1);
            int distance = 30;
            TimeSpan time = new TimeSpan(3, 0, 0);
            float? averageSpeed = 10;
            TrainingType trainingType = TrainingType.Endurance;
            string comment = "";
            //Act
            try
            {
                _tm.AddRunningTraining(when, distance, time, averageSpeed, trainingType, comment);
            }
            catch (DomainException e)
            {
                //Assert
                StringAssert.Contains(e.Message, "Training is in the future");
                return;
            }
            Assert.Fail("The expected exception was not thrown");
        }
        [TestMethod()]
        public void AddRunningTrainingTest_ShouldTrowDomainException_IfDistanceBelow0()
        {
            //Arrange
            DateTime when = DateTime.Now;
            int distance = -3;
            TimeSpan time = new TimeSpan(3, 0, 0);
            float? averageSpeed = 10;
            TrainingType trainingType = TrainingType.Endurance;
            string comment = "";
            //Act
            try
            {
                _tm.AddRunningTraining(when, distance, time, averageSpeed, trainingType, comment);
            }
            catch (DomainException e)
            {
                //Assert
                StringAssert.Contains(e.Message, "Distance invalid value");
                return;
            }
            Assert.Fail("The expected exception was not thrown");
        }
        [TestMethod()]
        public void AddRunningTrainingTest_ShouldTrowDomainException_IfDistanceOver50000()
        {
            //Arrange
            DateTime when = DateTime.Now;
            int distance = 50001;
            TimeSpan time = new TimeSpan(3, 0, 0);
            float? averageSpeed = 10;
            TrainingType trainingType = TrainingType.Endurance;
            string comment = "";
            //Act
            try
            {
                _tm.AddRunningTraining(when, distance, time, averageSpeed, trainingType, comment);
            }
            catch (DomainException e)
            {
                //Assert
                StringAssert.Contains(e.Message, "Distance invalid value");
                return;
            }
            Assert.Fail("The expected exception was not thrown");
        }
        [TestMethod()]
        public void AddRunningTrainingTest_ShouldTrowDomainException_IfTimeBelow0()
        {
            //Arrange
            DateTime when = DateTime.Now;
            int distance = 1000;
            TimeSpan time = new TimeSpan(-3);
            float? averageSpeed = 10;
            TrainingType trainingType = TrainingType.Endurance;
            string comment = "";
            //Act
            try
            {
                _tm.AddRunningTraining(when, distance, time, averageSpeed, trainingType, comment);
            }
            catch (DomainException e)
            {
                //Assert
                StringAssert.Contains(e.Message, "Time invalid value");
                return;
            }
            Assert.Fail("The expected exception was not thrown");
        }
        [TestMethod()]
        public void AddRunningTrainingTest_ShouldTrowDomainException_IfTimeOver20()
        {
            //Arrange
            DateTime when = DateTime.Now;
            int distance = 1000;
            TimeSpan time = new TimeSpan(20, 30, 0);
            float? averageSpeed = 10;
            TrainingType trainingType = TrainingType.Endurance;
            string comment = "";
            //Act
            try
            {
                _tm.AddRunningTraining(when, distance, time, averageSpeed, trainingType, comment);
            }
            catch (DomainException e)
            {
                //Assert
                StringAssert.Contains(e.Message, "Time invalid value");
                return;
            }
            Assert.Fail("The expected exception was not thrown");
        }
        [TestMethod()]
        public void AddRunningTrainingTest_ShouldTrowDomainException_IfSpeedBelow0()
        {
            //Arrange
            DateTime when = DateTime.Now;
            int distance = 1000;
            TimeSpan time = new TimeSpan(10, 0, 0);
            float? averageSpeed = -3;
            TrainingType trainingType = TrainingType.Endurance;
            string comment = "";
            //Act
            try
            {
                _tm.AddRunningTraining(when, distance, time, averageSpeed, trainingType, comment);
            }
            catch (DomainException e)
            {
                //Assert
                StringAssert.Contains(e.Message, "Average speed invalid value");
                return;
            }
            Assert.Fail("The expected exception was not thrown");
        }
        [TestMethod()]
        public void AddRunningTrainingTest_ShouldTrowDomainException_IfSpeedOver30()
        {
            //Arrange
            DateTime when = DateTime.Now;
            int distance = 1000;
            TimeSpan time = new TimeSpan(10, 0, 0);
            float? averageSpeed = 31;
            TrainingType trainingType = TrainingType.Endurance;
            string comment = "";
            //Act
            try
            {
                _tm.AddRunningTraining(when, distance, time, averageSpeed, trainingType, comment);
            }
            catch (DomainException e)
            {
                //Assert
                StringAssert.Contains(e.Message, "Average speed invalid value");
                return;
            }
            Assert.Fail("The expected exception was not thrown");
        }

        [TestMethod()]
        public void GenerateMonthlyCyclingReportTest()
        {
            Assert.Fail();
        }
    }
}