using Becomex.Robot.Application.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Becomex.Robot.Application.Model
{
    public class FistModel
    {
        public Domain.Enuns.EnumsRobot.EnumFist FistState { get; set; }
        public int Action { get; set; }
        public string Description
        {
            get
            {
                return FistState.GetDescription();
            }
        }
    }
}
