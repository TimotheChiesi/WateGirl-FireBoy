using UnityEngine;

public static class StateManager
{
    public static bool WaterGirlInDoor = false;
    public static bool FireBoyInDoor = false;

    public static void ResetState()
    {
        WaterGirlInDoor = false;
        FireBoyInDoor = false;
    }
}
