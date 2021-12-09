using System;
using System.Collections.Generic;
using System.Text;

namespace Becomex.Robot.Application.Model
{
    public class ArmModel
    {
        public AnconModel Ancon { get; set; }
        public FistModel Fist { get; set; }
        public int Action { get; set; }
    }
}
