using System;
using UnityEngine;

public class LeftDefender : SoccerPosition
{
    Vector2 centerPosition = new Vector2(-20.0f, 5.0f);
    public LeftDefender(TeamManagement team) : base(team) { }
    public override Vector2 RawCenterPosition()
    {
        return centerPosition;
    }
}
