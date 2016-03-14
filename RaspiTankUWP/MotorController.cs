using Devkoes.Restup.WebServer.Attributes;
using Devkoes.Restup.WebServer.Models.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaspiTankUWP
{
    [RestController(InstanceCreationType.Singleton)]
    public class MotorController
    {
        public MotorController()
        {
        }

        [UriFormat("/move/{xValue}/{yValue}/{rnd}")]
        public GetResponse Move(double xValue, double yValue, string rnd)
        {
            MotorValues motorValues = MotorValues.JoystickPercentToMotorValues(xValue, yValue);

            return new GetResponse(GetResponse.ResponseStatus.OK, motorValues);
        }

        [UriFormat("/turret/{xValue}/{yValue}/{rnd}")]
        public GetResponse Turret(double xValue, double yValue, string rnd)
        {
            return new GetResponse(GetResponse.ResponseStatus.OK);
        }

        private MotorValues joystickToMotorValues(double xValue, double yValue)
        {
            // TODO: Add motor control code here...

            return new MotorValues();
        }
    }
}