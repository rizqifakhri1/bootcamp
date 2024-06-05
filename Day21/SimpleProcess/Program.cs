using NLog;
using NLog.Config;

class Program
{
    public static Logger logger = LogManager.GetCurrentClassLogger();
    static void Main()
    {
        LogManager.Configuration = new XmlLoggingConfiguration("NLog.config");
        logger.Debug("Starting Robot");
        Robot robot = new Robot();
        logger.Info("Starging Walk");
        robot.Walk();
        logger.Info("Program Ended");
    }
}

class Robot
{
    public static Logger logger = LogManager.GetCurrentClassLogger();

    public void Walk()
    {
        LeftLegMove();
        RightLegMove();
        logger.Info("Walk One Stap");
    }
    void LeftLegMove()
    {
        //Process
        logger.Info("Left Leg Move");
    }

    void RightLegMove()
    {
        //Process
        logger.Info("Right Leg Move");
    }
}