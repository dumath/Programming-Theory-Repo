using UnityEngine;

public class Projectile : MonoBehaviour
{
    new private Rigidbody2D rigidbody;

    [SerializeField] private AudioClip hitSound;

    private ParticleSystem hitParticle;

    private bool isWorked = false;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        hitParticle = GetComponent<ParticleSystem>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //TODO: Добавить анимацию взрыва.
        //TODO: Реализм уничтожения снаряда.
        if (!isWorked)
        {
            isWorked = !isWorked;
            GetComponent<AudioSource>().PlayOneShot(hitSound);
            hitParticle.Play();
            Destroy(gameObject, 1f);
        }

    }
}
