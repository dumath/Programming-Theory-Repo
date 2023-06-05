using UnityEngine;

public class HeavyShip :  Ship
{
    public float LATERAL_MOVEMENT = 5.0f;
    [SerializeField] private Weapon impulseGenerater; // Center.
    [SerializeField] private Weapon launcherSlotSL; // Side Left.
    [SerializeField] private Weapon launcherSlotSR; // Side Right.

    protected override void Start()
    {
        base.Start();
        lateralMovement = LATERAL_MOVEMENT;
    }

    public override void Fire()
    {
        launcherSlotCL.Fire();
        launcherSlotCR.Fire();
        launcherSlotSL.Fire();
        launcherSlotSR.Fire();
    }
}
