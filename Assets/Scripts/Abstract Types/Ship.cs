using UnityEngine;
using System.Collections.Generic;

public abstract class Ship : MonoBehaviour
{
    protected int healthPoint;
    protected float lateralMovement;

    protected float posX;
    protected float posY;

    [SerializeField] protected Weapon launcherSlotCL; // Center Left.
    [SerializeField] protected Weapon launcherSlotCR; // Center Right.

    new protected Rigidbody2D rigidbody2D;

    protected virtual void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        posX = Input.GetAxis("Horizontal");
        posY = Input.GetAxis("Vertical");
        if(Input.GetMouseButtonDown(0))
            Fire();
    }

    protected virtual void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;
        position.x += posX * Time.deltaTime * lateralMovement;
        position.y += posY * Time.deltaTime * lateralMovement;
        rigidbody2D.MovePosition(position);
    }

    public abstract void Fire();
}
