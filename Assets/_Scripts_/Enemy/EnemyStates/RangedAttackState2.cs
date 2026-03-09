using UnityEngine;

public class RangedAttackState2 : State
{
   protected override string AnimBoolName => "isShooting2";
    private bool attackFinished;
    public RangedAttackState2(Enemy enemy) : base(enemy) { }
    public override void Enter()
    {
        base.Enter();
        rb.linearVelocity = Vector2.zero;
        attackFinished = false;
    }
    public override void Update()
    {
        if (!attackFinished) return;
        if (senses.GetChaseTarget())
            stateMachine.ChangeState(new ChaseState(enemy));
        else
            stateMachine.ChangeState(new IdleState(enemy));
    }
    public override void OnAnimationFinished() => attackFinished = true;
}
