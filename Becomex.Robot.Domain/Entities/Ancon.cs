using System;
using System.Collections.Generic;
using System.Text;

namespace Becomex.Robot.Domain.Entities
{
    public class Ancon
    {
        public Enuns.EnumsRobot.EnumAncon AnconState { get; set; }
        public int Action { get; set; }
    }
}
