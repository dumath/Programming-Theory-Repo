using UnityEngine;

public class Missile : Weapon
{
    public override void Fire()
    {
        GameObject launchedMissile = Instantiate(prefabProjectile, transform.position, Quaternion.identity);
        Destroy(launchedMissile, 5f);
        launchedMissile.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 300f, ForceMode2D.Impulse);
    }
}
