using Becomex.Robot.Application.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Becomex.Robot.Application.Model
{
    public class HeadModel
    {
        public Domain.Enuns.EnumsRobot.EnumHeadRotation HeadRotationState { get; set; }
        public Domain.Enuns.EnumsRobot.EnumHeadInclination HeadInclinationState { get; set; }

        public int Action { get; set; }
        public string HeadRotationStateDescription
        {
            get
            {
                return HeadRotationState.GetDescription();
            }
        }
        public string HeadInclinationStateDescription
        {
            get
            {
                return HeadInclinationState.GetDescription();
            }
        }
    }
}
