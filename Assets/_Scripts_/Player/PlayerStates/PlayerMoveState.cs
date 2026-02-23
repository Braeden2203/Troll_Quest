using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public PlayerMoveState(Player player) : base(player) { }
    public override void Enter()
    {
        base.Enter();
        anim.SetBool("isRunning", true);
    }

    public override void Update()
    {
        base.Update();
        if (AttackPressed && combat.CanAttack)
            player.ChangeState(player.attackState);
        else if (JumpPressed)
        {
            player.ChangeState(player.jumpState);
        }
        else if (Mathf.Abs(MoveInput.x) < .1f)
        {
            player.ChangeState(player.idleState);
        }
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        float speed = RunPressed ? player.runSpeed : player.walkSpeed;
        rb.linearVelocity = new Vector2(speed * player.facingDirection, rb.linearVelocity.y);
    }

    public override void Exit()
    {
        base.Exit();
        anim.SetBool("isRunning", false);
    }
}
