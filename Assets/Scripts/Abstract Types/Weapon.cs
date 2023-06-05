using UnityEngine;

// INHERITANCE
public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected GameObject prefabProjectile;

    protected int projectileSpeed;

    // POLYMORPHISM
    protected virtual void Start() { }

    // POLYMORPHISM
    public abstract void Fire();
}
