using System;
using UnityEngine;

public class RightDefender : SoccerPosition
{
    Vector2 centerPosition = new Vector2(-20.0f, -5.0f);
    public RightDefender(TeamManagement team) : base(team) { }

    public override Vector2 RawCenterPosition()
    {
        return centerPosition;
    }
}
