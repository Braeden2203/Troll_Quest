using System.Collections;
using UnityEngine;

public class Enemy_Damage : MonoBehaviour
{
    public GameObject enemy;
    public Animator anim;
    public Health health;
    private void OnEnable()
    {
        health.OnDamaged += HandleDamage;
        health.OnDeath += HandleDeath;
    }
    private void OnDisable()
    {
        health.OnDamaged -= HandleDamage;
        health.OnDeath -= HandleDeath;
    }
    void HandleDamage()
    {
        anim.SetTrigger("isDamaged");
    }
    void HandleDeath()
    {
        StartCoroutine(Dead());
    }

    public IEnumerator Dead()
    {
        anim.SetTrigger("isDead");
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        enemy.SetActive(false);
    }
}
