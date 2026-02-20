using UnityEngine;

public class IdleState : State
{
    private Transform target;
    protected override string AnimBoolName => "isIdleing";
    public IdleState(Enemy enemy) : base(enemy) { }
    private int whichAttack;
    public override void Enter()
    {
        base.Enter();
        rb.linearVelocity = Vector2.zero;
    }
    public override void FixedUpdate()
    {
        //Check for target
        target = senses.GetChaseTarget();
        if (!target)
        {
            stateMachine.ChangeState(new PatrolState(enemy));
            return;
        }
        enemy.FaceTarget(target);
        //check if we can attack
        if (senses.IsInMeleeRange(target) && combat.CanMeleeAttack())
        {
            whichAttack = Random.Range(1, 3);
            if (whichAttack == 1)
                stateMachine.ChangeState(new MeleeAttackState1(enemy));
            else
                stateMachine.ChangeState(new MeleeAttackState2(enemy));
            return;
        }
        //Check if we reached target
        float distance = Mathf.Abs(target.position.x - enemy.transform.position.x);
        if (distance <= config.turnThreshold)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }
        //Check for obstacles
        if (senses.IsHittingWall() || senses.IsAtCliff())
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }
        //After all that we have reached our target
        stateMachine.ChangeState(new ChaseState(enemy));
    }
}