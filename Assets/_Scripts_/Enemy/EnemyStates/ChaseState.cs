using UnityEngine;

public class ChaseState : State
{
    private Transform target;
    protected override string AnimBoolName => "isRunning";
    public ChaseState(Enemy enemy) : base(enemy) { }
    private int whichAttack;
    public override void FixedUpdate()
    {
        //Check for target
        target = senses.GetChaseTarget();
        if(!target)
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
        //Check if we reached our target
        float distance = Mathf.Abs(target.position.x - enemy.transform.position.x);
        if(distance <= config.turnThreshold)
        {
            stateMachine.ChangeState(new IdleState(enemy));
            return;
        }
        //Check for obstacle
        if(senses.IsHittingWall() || senses.IsAtCliff())
        {
            stateMachine.ChangeState(new IdleState(enemy));
            return;
        }
        //Move towards target
        rb.linearVelocity = new Vector2(config.chaseSpeed * enemy.FacingDirection, rb.linearVelocity.y);
    }
    public override void Exit()
    {
        base.Exit();
        rb.linearVelocity = Vector2.zero;
    }
}
