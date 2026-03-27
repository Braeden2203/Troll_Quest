using UnityEngine;
using System.Collections;

public class PlayerDeathState : PlayerState
{
    private float knockbackVelocity;
    private float knockbackDuration;
    public PlayerDeathState(Player player) : base(player) { }
    public void SetParameters(int knockbackDirection)
    {
        knockbackVelocity = knockbackDirection * damage.knockbackForce;
    }
    public override void Enter()
    {
        base.Enter();
        anim.SetBool("isDead", true);
        player.groundCheckRadius = .2f;
        knockbackDuration = damage.knockbackDuration;
        player.rb.linearVelocity = new Vector2(knockbackVelocity, player.rb.linearVelocity.y);
    }
    public override void FixedUpdate()
    {
        knockbackDuration -= Time.fixedDeltaTime;
        if (knockbackDuration <= 0)
        {
            if(player.isGrounded)
                player.rb.linearVelocity = Vector2.zero;
        }
    }
    public override void Exit() 
    {
        base.Exit();
        anim.SetBool("isDead", false);
        player.groundCheckRadius = .5f;
    }
}
