﻿namespace SendKeys.Common;

public static class TimerExtensions
{
    public static void Start(this System.Timers.Timer timer, Action executeBeforeStart)
    {
        executeBeforeStart();
        timer.Start();
    }
}
