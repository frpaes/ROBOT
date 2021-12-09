using System;
using System.Collections.Generic;
using System.Text;

namespace Becomex.Robot.Domain.Entities
{
    public class Arm
    {
        public Ancon Ancon { get; set; }
        public Fist Fist { get; set; }

        public int Action { get; set; }
    }
}
