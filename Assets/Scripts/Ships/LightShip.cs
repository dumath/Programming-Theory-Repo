using UnityEngine;

public class LightShip : Ship
{
    public float LATERAL_MOVEMENT = 15.0f;

    
    protected override void Start()
    {
        base.Start(); // ABSTRACTION
        lateralMovement = LATERAL_MOVEMENT;
    }

    // ABSTRACTION
    public override void Fire()
    {
        launcherSlotCL.Fire();
        launcherSlotCR.Fire();
    }
}
