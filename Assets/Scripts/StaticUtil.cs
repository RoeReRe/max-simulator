using UnityEngine;

public static class StaticUtil
{
    public static bool isInvoked = false;

    public static bool isDead = false;
    public static Vector2 lastPosition = Vector2.negativeInfinity;
    public static float lastCholesterol = -1f;
    public static float lastWeight = -1f;
}
