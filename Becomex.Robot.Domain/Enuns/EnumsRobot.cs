using System;
using System.ComponentModel;

namespace Becomex.Robot.Domain.Enuns
{
    public class EnumsRobot
    {
        public enum EnumRobot
        {
            [Description("OK")]
            Ok = 1,

            [Description("Corrompido")]
            Corrupted = 2
        }

        public enum EnumArm
        {
            [Description("Braço Direito")]
            Right = 1,

            [Description("Braço Esquerdo")]
            Left = 2
        }

        public enum EnumAncon
        {
            [Description("Em Repouso")]
            InRest = 1,

            [Description("Levemente Contraído")]
            SlightlyContracted = 2,

            [Description("Contraído")]
            Contracted = 3,

            [Description("Fortemente Contraído")]
            StronglyContracted = 4
        }

        public enum EnumFist
        {
            [Description("Rotação para -90º")]
            Negat90Deg = 1,

            [Description("Rotação para -45º")]
            Negat45Deg = 2,

            [Description("Em Repouso")]
            InRest = 3,

            [Description("Rotação para 45º")]
            Posit45Deg = 4,

            [Description("Rotação para 90º")]
            Posit90Deg = 5,

            [Description("Rotação para 135º")]
            Posit135Deg = 6,

            [Description("Rotação para 180º")]
            Posit180Deg = 7
        }

        public enum EnumHeadInclination
        {
            [Description("Para Cima")]
            Up = 1,

            [Description("Em Repouso")]
            InRest = 2,

            [Description("Para Baixo")]
            Down = 3
        }

        public enum EnumHeadRotation
        {
            [Description("Rotação -90º")]
            Negative90Degrees = 1,

            [Description("Rotação -45º")]
            Negative45Degrees = 2,

            [Description("Em Repouso")]
            InRest = 3,

            [Description("Rotação 45º")]
            Positive45Degrees = 4,

            [Description("Rotação 90º")]
            Positive90Degrees = 5
        }
    }
}
