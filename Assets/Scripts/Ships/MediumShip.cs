using UnityEngine;

public class MediumShip : Ship
{
    public float LATERAL_MOVEMENT = 10.0f;

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
