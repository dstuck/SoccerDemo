using System;
using UnityEngine;

public class LeftMidfielder : SoccerPosition
{
    Vector2 centerPosition = new Vector2(5.0f, 10.0f);
    public LeftMidfielder(TeamManagement team) : base(team) { }
    public override Vector2 RawCenterPosition()
    {
        return centerPosition;
    }
}
