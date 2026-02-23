using UnityEditor;
using UnityEngine;

public class DeathState : State
{
    private float knockbackVelocity;
    private float knockbackDuration;
    public DeathState(Enemy enemy, int knockbackDir) : base(enemy)
    {
        knockbackVelocity = knockbackDir * config.knockbackForce;
    }
    public override void Enter()
    {
        base.Enter();
        anim.SetBool("isDead", true);
        knockbackDuration = config.knockbackDuration;
        rb.linearVelocity = new Vector2(knockbackVelocity, rb.linearVelocity.y);
    }
    public override void FixedUpdate()
    {
        knockbackDuration -= Time.fixedDeltaTime;
        if (knockbackDuration <= 0)
        {
            if (!senses.IsAtCliff())
                rb.linearVelocity = Vector2.zero;
            enemy.OnDeath?.Invoke();
            enemy.OnDeath = null;
            GameObject.Destroy(enemy.gameObject, 2f);
        }
    }
    public override void Exit()
    {
        base.Exit();
        anim.SetBool("isDead", false);
    }   
   
}
