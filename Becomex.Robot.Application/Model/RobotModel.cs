using Becomex.Robot.Application.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Becomex.Robot.Application.Model
{
    public class RobotModel
    {
        public Domain.Enuns.EnumsRobot.EnumRobot RobotStatus { get; set; }
        public HeadModel Head { get; set; }
        public ArmModel RightArm { get; set; }
        public ArmModel LeftArm { get; set; }

        public int Action { get; set; }
        public string StatusDescription
        {
            get
            {
                return RobotStatus.GetDescription();
            }
        }
    }
}
