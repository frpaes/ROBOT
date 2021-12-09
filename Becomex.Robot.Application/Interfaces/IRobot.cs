using Becomex.Robot.Application.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Becomex.Robot.Application.Interfaces
{
    public interface IRobot
    {
        Task<RobotModel> GetRobotAsync();
        Task<RobotModel> InitialAsync(Domain.Entities.Robot robot);
        Task<RobotModel> MoveHeadAsync(Domain.Entities.Robot robot);
        Task<RobotModel> MoveAnconAsync(Domain.Entities.Robot robot);
        Task<RobotModel> MoveFistAsync(Domain.Entities.Robot robot);
        void Dispose();
    }
}
