using System;
using UnityEngine;

public abstract class SoccerPosition
{
    private TeamManagement _team;

    public SoccerPosition(TeamManagement team) { _team = team; }
    public abstract Vector2 RawCenterPosition();
    public Vector2 GetCenterPosition() {
        return RawCenterPosition() * _team.GetDirection();
    }
    public virtual float GetBoundingWidth() { return 30.0f; }
    public virtual float GetBoundingHeight() { return 15.0f; }
    private float MinX() { return RawCenterPosition().x - GetBoundingWidth() * 0.5f; }
    private float MaxX() { return RawCenterPosition().x + GetBoundingWidth() * 0.5f; }
    private float MinY() { return RawCenterPosition().y - GetBoundingHeight() * 0.5f; }
    private float MaxY() { return RawCenterPosition().y + GetBoundingHeight() * 0.5f; }

    public void ClampToBoundingBox(Vector2 targetPosition)
    {
        targetPosition.x = Mathf.Clamp(targetPosition.x, MinX(), MaxX());
        targetPosition.y = Mathf.Clamp(targetPosition.y, MinY(), MaxY()); 
    }
}