using System;
using System.Collections.Generic;
using System.Text;

namespace Becomex.Robot.Domain.Entities
{
    public class Robot
    {
        public Robot()
        {
            RobotStatus = Enuns.EnumsRobot.EnumRobot.Ok;

            Head = new Head()
            {
                HeadInclinationState = Enuns.EnumsRobot.EnumHeadInclination.InRest,
                HeadRotationState = Enuns.EnumsRobot.EnumHeadRotation.InRest
            };

            LeftArm = new Arm()
            {
                Ancon = new Ancon() { AnconState = Enuns.EnumsRobot.EnumAncon.InRest },
                Fist = new Fist() { FistState = Enuns.EnumsRobot.EnumFist.InRest }
            };

            RightArm = new Arm()
            {
                Ancon = new Ancon() { AnconState = Enuns.EnumsRobot.EnumAncon.InRest },
                Fist = new Fist() { FistState = Enuns.EnumsRobot.EnumFist.InRest }
            };


        }
        public Enuns.EnumsRobot.EnumRobot RobotStatus { get; set; }
        public Head Head { get; set; }
        public Arm RightArm { get; set; }
        public Arm LeftArm { get; set; }
        public int Action { get; set; }

       


    }
}
