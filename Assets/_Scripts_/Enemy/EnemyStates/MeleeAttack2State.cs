using UnityEngine;

public class MeleeAttackState2 : State
{
    protected override string AnimBoolName => "isAttacking2";
    public MeleeAttackState2(Enemy enemy) : base(enemy) { }
    public override void Enter()
    {
        base.Enter();
        rb.linearVelocity = Vector2.zero;
    }
    public override void OnAnimationFinished()
    {
        stateMachine.ChangeState(new IdleState(enemy));
    }
}
