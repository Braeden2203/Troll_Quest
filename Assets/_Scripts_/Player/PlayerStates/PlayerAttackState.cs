using UnityEngine;

public class PlayerAttackState : PlayerState
{
    public PlayerAttackState(Player player) : base(player) { }
    public override void Enter()
    {
        base.Enter();
        anim.SetBool("isAttacking", true);
        rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
    }

    public override void Update()
    {
        base.Update();
        
    }

    public override void AttackAnimationFinished()
    {
        if (Mathf.Abs(MoveInput.x) > .1f)
            player.ChangeState(player.moveState);
        else
            player.ChangeState(player.idleState);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void Exit()
    {
        base.Exit();
        anim.SetBool("isAttacking", false);
    }
}