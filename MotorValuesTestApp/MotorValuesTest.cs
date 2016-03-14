using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using RaspiTankUWP;
using System;

namespace MotorValuesTestApp
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFullForward()
        {
            var result = MotorValues.JoystickPercentToMotorValues(0, 100);

            Assert.AreEqual(100, result.Left);
            Assert.AreEqual(100, result.Right);
        }

        [TestMethod]
        public void TestFullBack()
        {
            var result = MotorValues.JoystickPercentToMotorValues(0, -100);

            Assert.AreEqual(-100, result.Left);
            Assert.AreEqual(-100, result.Right);
        }

        [TestMethod]
        public void TestRotateLeft()
        {
            var result = MotorValues.JoystickPercentToMotorValues(100, 0);

            Assert.AreEqual(-100, result.Left);
            Assert.AreEqual(100, result.Right);
        }

        [TestMethod]
        public void TestRotateRight()
        {
            var result = MotorValues.JoystickPercentToMotorValues(-100, 0);

            Assert.AreEqual(100, result.Left);
            Assert.AreEqual(-100, result.Right);
        }

        [TestMethod]
        public void TestForwardTurnLeft()
        {
            var result = MotorValues.JoystickPercentToMotorValues(100, 100);

            Assert.AreEqual(0, result.Left);
            Assert.AreEqual(100, result.Right);
        }

        [TestMethod]
        public void TestForwardTurnRight()
        {
            var result = MotorValues.JoystickPercentToMotorValues(-100, 100);

            Assert.AreEqual(100, result.Left);
            Assert.AreEqual(0, result.Right);
        }

        [TestMethod]
        public void TestReverseTurnLeft()
        {
            var result = MotorValues.JoystickPercentToMotorValues(100, -100);

            Assert.AreEqual(-100, result.Left);
            Assert.AreEqual(0, result.Right);
        }

        [TestMethod]
        public void TestReverseTurnRight()
        {
            var result = MotorValues.JoystickPercentToMotorValues(-100, -100);

            Assert.AreEqual(0, result.Left);
            Assert.AreEqual(-100, result.Right);
        }
    }
}