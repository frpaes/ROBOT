using Becomex.Robot.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Becomex.Robot.Web.Models
{
    public class RobotViewModel
    {
        public RobotModel RobotStatus { get; set; }
        public HeadModel Head { get; set; }
        public ArmModel RightArm { get; set; }
        public ArmModel LeftArm { get; set; }

        public int HeadRotationStateId { get; set; }
        public int HeadInclinationStateId { get; set; }
        public int ElbowStateId { get; set; }
        public int FistStateId { get; set; }

        public string Description { get; set; }

    }
}
