using System;
using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private LayerMask groundlayer;
    [SerializeField] private LayerMask targetLayer;
    public Animator Anim { get; private set; }
    public float Lifetime { get; set; } = 5;
    public int Damage { get; set; } = 1;
    void Awake()
    {
        Anim = GetComponent<Animator>();
    }
    void Start()
    {
        StartCoroutine(DestroyAfterAnimationAndLifeTime());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(((1 << collision.gameObject.layer) & groundlayer) != 0)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.linearVelocity = Vector2.zero;
            rb.simulated = false;
            GetComponent<Collider2D>().enabled = false;
            StartCoroutine(DestroyAfterAnimation());
            return;
        }
        if (((1 << collision.gameObject.layer) & targetLayer) == 0)
        {
            return;
        }
        Health health = collision.GetComponentInChildren<Health>();
        if(health)
        {
            health.ChangeHealth(-Damage, transform.position);
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.linearVelocity = Vector2.zero;
            rb.simulated = false;
            GetComponent<Collider2D>().enabled = false;
            StartCoroutine(DestroyAfterAnimation());
        }
    }
    private IEnumerator DestroyAfterAnimationAndLifeTime()
    {
        yield return new WaitForSeconds(Lifetime);
        StartCoroutine(DestroyAfterAnimation());
    }
    private IEnumerator DestroyAfterAnimation()
    {
        Anim.SetTrigger("isDestroyed");
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
}
