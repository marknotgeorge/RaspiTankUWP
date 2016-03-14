using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaspiTankUWP
{
    public class MotorValues
    {
        public int Left { get; set; }
        public int Right { get; set; }

        public MotorValues(int left = 0, int right = 0)
        {
            Left = left;
            Right = right;
        }

        /// <summary>
        /// Convert Joystick Percentages to left motor and right motor percentages. Based on http://home.kendra.com/mauser/Joystick.html
        /// </summary>
        /// <param name="X">
        /// Percentage of horizontal movement, where 100 = full left, 0 = center and -100 = full right
        /// </param>
        /// <param name="Y">
        /// Percentage of vertical movement, where 100 = full up, 0 = center and -100 = full down
        /// </param>
        /// <returns></returns>

        public static MotorValues JoystickPercentToMotorValues(double x, double y)
        {
            // In the original algorithm, full left is x=-100, and X is inverted. Because with
            // jsJoystick full left is x=+100, there's no need to invert.

            var X = x;
            var Y = y;

            var RightPlusLeft = (100 - Math.Abs(X)) * (Y / 100) + Y;
            var RightMinusLeft = (100 - Math.Abs(Y)) * (X / 100) + X;

            var Right = (RightPlusLeft + RightMinusLeft) / 2;
            var Left = (RightPlusLeft - RightMinusLeft) / 2;

            return new MotorValues((int)Math.Round(Left), (int)Math.Round(Right));
        }
    }
}