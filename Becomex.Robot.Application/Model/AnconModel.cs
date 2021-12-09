using Becomex.Robot.Application.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Becomex.Robot.Application.Model
{
    public class AnconModel
    {
        public Domain.Enuns.EnumsRobot.EnumAncon AnconState { get; set; }
        public int Action { get; set; }
        public string Description
        {
            get
            {
                return AnconState.GetDescription();
            }
        }
    }
}
