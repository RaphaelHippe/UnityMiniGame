using System;

public static class GameStats
{
    private static int points,
        positivePickUps,
        negativePickUps,
        timePickUps,
        speedPickUps,
        resetPickUps;


    public static int Points
    {
        get
        {
            return points;
        }
        set
        {
            points = value;
        }
    }

    public static int PositivePickUps
    {
        get
        {
            return positivePickUps;
        }
        set
        {
            positivePickUps = value;
        }
    }

    public static int NegativePickUps
    {
        get
        {
            return negativePickUps;
        }
        set
        {
            negativePickUps = value;
        }
    }

    public static int TimePickUps
    {
        get
        {
            return timePickUps;
        }
        set
        {
            timePickUps = value;
        }
    }

    public static int SpeedPickUps
    {
        get
        {
            return speedPickUps;
        }
        set
        {
            speedPickUps = value;
        }
    }

    public static int ResetPickUps
    {
        get
        {
            return resetPickUps;
        }
        set
        {
            resetPickUps = value;
        }
    }

}
