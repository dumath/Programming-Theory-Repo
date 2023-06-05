using UnityEngine;

public class SimpleEnemy : Enemy
{
    protected override void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    protected override void Start()
    {
        fireSpeed = 2.0f;
        
    }
    protected override void Update()
    {
        timer += Time.deltaTime;
        if(timer > fireSpeed)
        {
            Fire();
            timer = 0.0f;
        }
    }
    protected override void FixedUpdate()
    {

    }

    public override void Fire()
    {
        WeaponLS.Fire();
        WeaponRS.Fire();
    }
}
