using AutoMapper;
using Becomex.Robot.Application.Interfaces;
using Becomex.Robot.Domain.Enuns;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Becomex.Robot.Test
{
    public class UnitTestRobot
    {
        public const string Msg01 = "inclinação da cabeça está pra baixo, ação não permitida.";
        public const string Msg02 = "A progressão deve ser feita em ordem crescente ou decrescente.";
        public const string Msg03 = "Movimento não permitido, o cotovelo não está fortemente contraído.";
        public const string Msg04 = "Robô está corrompido.";
        public const string Msg05 = "Robô não existe.";

        private readonly IRobot _robot;
        private readonly Mock<IMapper> _mapper;

        public UnitTestRobot()
        {
            _mapper = new Mock<IMapper>();
            _robot = new Becomex.Robot.Application.Robot(_mapper.Object);
        }

        [Fact]
        public async Task RobotTestMoveHeadAsyncInclinationSuccess()
        {
            //Arrange
            Domain.Entities.Robot robot = new Domain.Entities.Robot(); 
            robot.Head.ActionInclination = 3;

            // Act
            await _robot.MoveHeadAsync(robot);
            
            //Assert
            Assert.True(robot.Head.ActionInclination == (int)robot.Head.HeadInclinationState);
        }

        [Fact]
        public async Task RobotTestMoveHeadAsyncRotationSuccess()
        {
            //Arrange
            Domain.Entities.Robot robot = new Domain.Entities.Robot();
            robot.Head.ActionRotation = 2;

            // Act
            await _robot.MoveHeadAsync(robot);

            //Assert
            Assert.True(robot.Head.ActionRotation == (int)robot.Head.HeadRotationState);
        }

        [Fact]
        public async Task RobotTestMoveHeadAsyncRotationThrowsExceptionMsg02()
        {
            //arrange
            Domain.Entities.Robot robot = new Domain.Entities.Robot();
            robot.Head.ActionRotation = 5;

            //Act
            Func<Task> act = () => _robot.MoveHeadAsync(robot);

            //Assert
            var exception = await Assert.ThrowsAsync<Exception>(act);

            //assert
            Assert.Equal(Msg02, exception.Message);
        }

        [Fact]
        public async Task RobotTestMoveAnconLeftAsyncSuccess()
        {
            //arrange
            Domain.Entities.Robot robot = new Domain.Entities.Robot();
            robot.LeftArm.Action = 1;
            robot.LeftArm.Ancon.Action = 2;

            // Act
            await _robot.MoveAnconAsync(robot);

            //Assert
            Assert.True(robot.LeftArm.Ancon.Action == (int)robot.LeftArm.Ancon.AnconState);
        }

        [Fact]
        public async Task RobotTestMoveAnconRightAsyncSuccess()
        {
            //arrange
            Domain.Entities.Robot robot = new Domain.Entities.Robot();
            robot.RightArm.Action = 1;
            robot.RightArm.Ancon.Action = 2;

            // Act
            await _robot.MoveAnconAsync(robot);

            //Assert
            Assert.True(robot.RightArm.Ancon.Action == (int)robot.RightArm.Ancon.AnconState);
        }

        [Fact]
        public async Task RobotTestMoveAnconLeftAsyncThrowsExceptionMsg02()
        {
            //arrange
            Domain.Entities.Robot robot = new Domain.Entities.Robot();
            robot.LeftArm.Action = 1;
            robot.LeftArm.Ancon.Action = 3;

            //Act
            Func<Task> act = () => _robot.MoveAnconAsync(robot);

            //Assert
            var exception = await Assert.ThrowsAsync<Exception>(act);

            //assert
            Assert.Equal(Msg02, exception.Message);
        }

        [Fact]
        public async Task RobotTestMoveAnconRightAsyncThrowsExceptionMsg02()
        {
            //arrange
            Domain.Entities.Robot robot = new Domain.Entities.Robot();
            robot.RightArm.Action = 1;
            robot.RightArm.Ancon.Action = 3;

            //Act
            Func<Task> act = () => _robot.MoveAnconAsync(robot);

            //Assert
            var exception = await Assert.ThrowsAsync<Exception>(act);

            //assert
            Assert.Equal(Msg02, exception.Message);
        }

        [Fact]
        public async Task RobotTestMoveFistLeftAsyncSuccess()
        {
            //arrange
            Domain.Entities.Robot robot = new Domain.Entities.Robot();
            robot.RightArm.Action = 0;
            robot.LeftArm.Action = 1;
            robot.LeftArm.Fist.Action = 2;
            robot.LeftArm.Ancon.AnconState = EnumsRobot.EnumAncon.StronglyContracted;

            // Act
            await _robot.MoveFistAsync(robot);

            //Assert
            Assert.True(robot.LeftArm.Fist.Action == (int)robot.LeftArm.Fist.FistState);
        }

        [Fact]
        public async Task RobotTestMoveFistRightAsyncSuccess()
        {
            //arrange
            Domain.Entities.Robot robot = new Domain.Entities.Robot();
            robot.LeftArm.Action = 0;
            robot.RightArm.Action = 1;
            robot.RightArm.Fist.Action = 2;
            robot.RightArm.Ancon.AnconState = EnumsRobot.EnumAncon.StronglyContracted;

            // Act
            await _robot.MoveFistAsync(robot);

            //Assert
            Assert.True(robot.RightArm.Fist.Action == (int)robot.RightArm.Fist.FistState);
        }

        [Fact]
        public async Task RobotTestMoveFistLeftAsyncThrowsExceptionMsg03()
        {
            //arrange
            Domain.Entities.Robot robot = new Domain.Entities.Robot();
            robot.LeftArm.Action = 1;
            robot.LeftArm.Fist.Action = 2;

            //Act
            Func<Task> act = () => _robot.MoveFistAsync(robot);

            //Assert
            var exception = await Assert.ThrowsAsync<Exception>(act);

            //assert
            Assert.Equal(Msg03, exception.Message);
        }

        [Fact]
        public async Task RobotTestMoveFistRightAsyncThrowsExceptionMsg03()
        {
            //arrange
            Domain.Entities.Robot robot = new Domain.Entities.Robot();
            robot.RightArm.Action = 1;
            robot.RightArm.Fist.Action = 2;

            //Act
            Func<Task> act = () => _robot.MoveFistAsync(robot);

            //Assert
            var exception = await Assert.ThrowsAsync<Exception>(act);

            //assert
            Assert.Equal(Msg03, exception.Message);
        }

        [Fact]
        public async Task RobotTestMoveFistRightAsyncThrowsExceptionMsg02()
        {
            //arrange
            Domain.Entities.Robot robot = new Domain.Entities.Robot();
            robot.RightArm.Action = 1;
            robot.RightArm.Fist.Action = 5;
            robot.RightArm.Ancon.AnconState = EnumsRobot.EnumAncon.StronglyContracted;

            //Act
            Func<Task> act = () => _robot.MoveFistAsync(robot);

            //Assert
            var exception = await Assert.ThrowsAsync<Exception>(act);

            //assert
            Assert.Equal(Msg02, exception.Message);
        }

        [Fact]
        public async Task RobotTestMoveFistLeftAsyncThrowsExceptionMsg02()
        {
            //arrange
            Domain.Entities.Robot robot = new Domain.Entities.Robot();
            robot.LeftArm.Action = 1;
            robot.LeftArm.Fist.Action = 5;
            robot.LeftArm.Ancon.AnconState = EnumsRobot.EnumAncon.StronglyContracted;

            //Act
            Func<Task> act = () => _robot.MoveFistAsync(robot);

            //Assert
            var exception = await Assert.ThrowsAsync<Exception>(act);

            //assert
            Assert.Equal(Msg02, exception.Message);
        }
    }
}
