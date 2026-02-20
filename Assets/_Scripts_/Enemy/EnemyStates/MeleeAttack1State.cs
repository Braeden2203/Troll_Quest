using UnityEngine;

public class MeleeAttackState1 : State
{
    protected override string AnimBoolName => "isAttacking1";
    public MeleeAttackState1(Enemy enemy) : base(enemy) { }
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
