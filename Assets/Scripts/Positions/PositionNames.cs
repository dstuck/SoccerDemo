using System;
using System.Collections.Generic;

public enum PositionNames
{
    CenterForward,
    LeftMidfielder,
    RightMidfielder,
    LeftDefender,
    RightDefender,
}

public static class SoccerPositionFactory
{
    public static SoccerPosition CreatePositionForName(PositionNames positionName, TeamManagement team)
    {
        Dictionary<PositionNames, SoccerPosition> PositionNameMap = new Dictionary<PositionNames, SoccerPosition>
        {
            { PositionNames.CenterForward, new CenterForward(team) },
            { PositionNames.LeftMidfielder, new LeftMidfielder(team) },
            { PositionNames.RightMidfielder, new RightMidfielder(team) },
            { PositionNames.LeftDefender, new LeftDefender(team) },
            { PositionNames.RightDefender, new RightDefender(team) },
        };
        return PositionNameMap[positionName];
    }
}
