using UnityEngine;

public class Turret : Weapon // INHERITANCE
{
    [SerializeField] private AudioClip fireClip;

    // POLYMORPHISM
    public override void Fire()
    {
        GameObject launchedMissile = Instantiate(prefabProjectile, transform.position, transform.rotation);
        Destroy(launchedMissile, 5f);
        GetComponent<AudioSource>().PlayOneShot(fireClip);
        launchedMissile.GetComponent<Rigidbody2D>().AddRelativeForce(Vector3.up * 300f, ForceMode2D.Impulse);
    }
}
