using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Enemy : MonoBehaviour
{
    new protected Rigidbody2D rigidbody;
    public int HealthPoint;
    public int Speed;

    [SerializeField] protected Weapon WeaponLS;
    [SerializeField] protected Weapon WeaponRS;

    protected float timer = 0.0f;
    protected float fireSpeed;

    protected abstract void Awake();
    protected abstract void Start();
    protected abstract void Update();
    protected abstract void FixedUpdate();

    public abstract void Fire();
}
