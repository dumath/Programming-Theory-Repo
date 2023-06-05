using UnityEngine;


public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected GameObject prefabProjectile;

    protected int projectileSpeed;

    protected virtual void Start()
    {

    }

    public abstract void Fire();
}
