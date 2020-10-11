using System;
using UnityEngine;

public class CenterForward : SoccerPosition
{
    Vector2 centerPosition = new Vector2(15.0f, 0.0f);
    public CenterForward(TeamManagement team) : base(team) { }
    public override Vector2 RawCenterPosition()
    {
        return centerPosition;
    }
}
