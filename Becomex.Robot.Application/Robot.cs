using AutoMapper;
using Becomex.Robot.Application.Interfaces;
using Becomex.Robot.Application.Model;
using Becomex.Robot.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Becomex.Robot.Application
{
    public class Robot : IRobot
    {
        public const string Msg01 = "inclinação da cabeça está pra baixo, ação não permitida.";
        public const string Msg02 = "A progressão deve ser feita em ordem crescente ou decrescente.";
        public const string Msg03 = "Movimento não permitido, o cotovelo não está fortemente contraído.";
        public const string Msg04 = "Robô está corrompido.";
        public const string Msg05 = "Robô não existe.";

        private readonly IMapper _mapper;

        public Robot(
            IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<RobotModel> GetRobotAsync()
        {
            return await Task.Run(() =>
            {
                return _mapper.Map<Domain.Entities.Robot, RobotModel>(new Domain.Entities.Robot());
            });
        }
        public async Task<RobotModel> InitialAsync(Domain.Entities.Robot robot)
        {
            return await Task.Run(() =>
            {
                if (robot == null)
                    throw new Exception(Msg05);

                robot.RobotStatus = EnumsRobot.EnumRobot.Ok;

                return _mapper.Map<Domain.Entities.Robot, RobotModel>(robot);
            });
        }

        public async Task<RobotModel> MoveHeadAsync(Domain.Entities.Robot robot)
        {
            return await Task.Run(() =>
            {
                if (robot == null) 
                    throw new Exception(Msg05);

                if (robot.RobotStatus == EnumsRobot.EnumRobot.Corrupted)
                {
                    throw new Exception(Msg04);
                }

                if (robot.Head.ActionRotation != 0)
                {
                    if (robot.Head.HeadInclinationState == EnumsRobot.EnumHeadInclination.Down)
                        throw new Exception(Msg01);

                    if (!ValidateState((int)robot.Head.HeadRotationState, robot.Head.ActionRotation))
                        throw new Exception(Msg02);
                    
                    if (robot.Head.ActionRotation != 0)
                        robot.Head.HeadRotationState = (EnumsRobot.EnumHeadRotation)robot.Head.ActionRotation;
                }
                if (robot.Head.ActionInclination != 0)
                {
                    if (!ValidateState((int)robot.Head.HeadInclinationState, robot.Head.ActionInclination))
                        throw new Exception(Msg02);

                    robot.Head.HeadInclinationState = (EnumsRobot.EnumHeadInclination)robot.Head.ActionInclination;
                }

                if (!Enum.IsDefined(typeof(EnumsRobot.EnumHeadRotation), robot.Head.ActionRotation ) && robot.Head.ActionRotation != 0
                    || !Enum.IsDefined(typeof(EnumsRobot.EnumHeadInclination), robot.Head.ActionInclination) && robot.Head.ActionInclination != 0)
                {
                    robot.RobotStatus = EnumsRobot.EnumRobot.Corrupted;
                }

                return _mapper.Map<Domain.Entities.Robot, RobotModel>(robot);
            });
        }

        public async Task<RobotModel> MoveAnconAsync(Domain.Entities.Robot robot)
        {
            return await Task.Run(() =>
            {

                if (robot == null)
                    throw new Exception(Msg05);
                
                if (robot.LeftArm.Action != 0)
                {
                    if (!Enum.IsDefined(typeof(EnumsRobot.EnumArm), robot.LeftArm.Action))
                    {
                        robot.RobotStatus = EnumsRobot.EnumRobot.Corrupted;
                    }

                    if (!ValidateState((int)robot.LeftArm.Ancon.AnconState, robot.LeftArm.Ancon.Action))
                        throw new Exception(Msg02);

                    robot.LeftArm.Ancon.AnconState = (EnumsRobot.EnumAncon)robot.LeftArm.Ancon.Action;
                }

                if (robot.RightArm.Action != 0)
                {
                    if (!Enum.IsDefined(typeof(EnumsRobot.EnumArm), robot.RightArm.Action))
                    {
                        robot.RobotStatus = EnumsRobot.EnumRobot.Corrupted;
                    }

                    if (!ValidateState((int)robot.RightArm.Ancon.AnconState, robot.RightArm.Ancon.Action))
                        throw new Exception(Msg02);

                    robot.RightArm.Ancon.AnconState = (EnumsRobot.EnumAncon)robot.RightArm.Ancon.Action;
                }

                return _mapper.Map<Domain.Entities.Robot, RobotModel>(robot);
            });
        }

        public async Task<RobotModel> MoveFistAsync(Domain.Entities.Robot robot)
        {
            return await Task.Run(() =>
            {
                if (robot == null)
                    throw new Exception(Msg05);

                if (robot.LeftArm.Action != 0)
                {
                    if (!Enum.IsDefined(typeof(EnumsRobot.EnumArm), robot.LeftArm.Action))
                    {
                        robot.RobotStatus = EnumsRobot.EnumRobot.Corrupted;
                    }

                    if (!ValidateState((int)robot.LeftArm.Fist.FistState, robot.LeftArm.Fist.Action))
                        throw new Exception(Msg02);

                    if(robot.LeftArm.Ancon.AnconState != EnumsRobot.EnumAncon.StronglyContracted)
                        throw new Exception(Msg03);

                    robot.LeftArm.Fist.FistState = (EnumsRobot.EnumFist)robot.LeftArm.Fist.Action;
                }

                if (robot.RightArm.Action != 0)
                {
                    if (!Enum.IsDefined(typeof(EnumsRobot.EnumArm), robot.RightArm.Action))
                    {
                        robot.RobotStatus = EnumsRobot.EnumRobot.Corrupted;
                    }

                    if (!ValidateState((int)robot.RightArm.Fist.FistState, robot.RightArm.Fist.Action))
                        throw new Exception(Msg02);

                    if (robot.RightArm.Ancon.AnconState != EnumsRobot.EnumAncon.StronglyContracted)
                        throw new Exception(Msg03);

                    robot.RightArm.Fist.FistState = (EnumsRobot.EnumFist)robot.RightArm.Fist.Action;
                }

                return _mapper.Map<Domain.Entities.Robot, RobotModel>(robot);
            });
        }
        
        private bool ValidateState(int oldS, int newS)
        {
            if (newS == oldS || (newS == (oldS - 1) || newS == (oldS + 1)))
                return true; 

            return false;

        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
