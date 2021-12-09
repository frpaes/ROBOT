using System;
using System.Collections.Generic;
using System.Text;

namespace Becomex.Robot.Domain.Entities
{
    public class Head
    {
        public Enuns.EnumsRobot.EnumHeadRotation HeadRotationState { get; set; }
        public Enuns.EnumsRobot.EnumHeadInclination HeadInclinationState { get; set; }
        public int ActionRotation { get; set; }
        public int ActionInclination { get; set; }
    }
}
