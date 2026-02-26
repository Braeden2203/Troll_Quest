using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public PlayerState currenntState;
    public PlayerIdleState idleState;
    public PlayerJumpState jumpState;
    public PlayerMoveState moveState;
    public PlayerCrouchState crouchState;
    public PlayerSlideState slideState;
    public PlayerDamagedState damagedState;
    public PlayerDeathState deathState;
    public PlayerAttackState attackState;
    public PlayerWallJumpState wallJumpState;
    public PlayerWallSlideState wallSlideState;

    [Header("Core Components")]
    public Combat combat;
    public Damage damage;
    public Health health;

    [Header("Components")]
    public Rigidbody2D rb;
    public PlayerInput playerInput;
    public Animator anim;
    public CapsuleCollider2D playerCollider;

    [Header("Movement Variables")]
    public float walkSpeed;
    public float runSpeed = 10;
    public float jumpForce;
    public float jumpCutMultiplier = .5f;
    public float normalGravity;
    public float fallGravity;
    public float jumpGravity;
    public int facingDirection = 1;

    //Inputs
    public Vector2 moveInput;
    public bool runPressed;
    public bool jumpPressed;
    public bool jumpReleased;
    public bool attackPressed;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public bool isGrounded;

    [Header("Wall Check")]
    public Transform wallCheck;
    public float wallCheckRadius = 0.5f;
    public LayerMask wallLayer;
    public bool isTouchingWall;

    [Header("Crouch Settings")]
    public Transform headCheck;
    public float headCheckRadius = .4f;

    [Header("Slide Settings")]
    public float slideDuration = .6f;
    public float slideSpeed = 12;
    public float slideStopDuration = .15f;
    public float slideHeight;
    public Vector2 slideOffset;
    public float normalHeight;
    public Vector2 normalOffset;
    private bool isSliding;
   

    private void Awake()
    {
        idleState = new PlayerIdleState(this);
        jumpState = new PlayerJumpState(this);
        moveState = new PlayerMoveState(this);
        crouchState = new PlayerCrouchState(this);
        slideState = new PlayerSlideState(this);
        damagedState = new PlayerDamagedState(this);
        deathState = new PlayerDeathState(this);
        attackState = new PlayerAttackState(this);
        wallJumpState = new PlayerWallJumpState(this);
        wallSlideState = new PlayerWallSlideState(this);
    }

    private void Start()
    {
        rb.gravityScale = normalGravity;
        ChangeState(idleState);
    }
    void Update()
    {
        currenntState.Update();
        if(!isSliding)
            Flip();
        HandleAnimations();
    }

    void FixedUpdate()
    {
        currenntState.FixedUpdate();
        CheckGrounded();
        CheckForWalls();
    }
    public void SetColliderNormal()
    {
        playerCollider.size = new Vector2(playerCollider.size.x, normalHeight);
        playerCollider.offset = normalOffset;
    }
    public void SetColliderSlide()
    {
        playerCollider.size = new Vector2(playerCollider.size.x, slideHeight);
        playerCollider.offset = slideOffset;
    }

    public void ChangeState(PlayerState newState)
    {
        if(currenntState != null) 
            currenntState.Exit();

        currenntState = newState;
        currenntState.Enter();
    }

    public void ApplyVariableGravity()
    {
        if(rb.linearVelocity.y < -0.1f)
        {
            rb.gravityScale = fallGravity;
        }
        else if (rb.linearVelocity.y > 0.1f)
        {
            rb.gravityScale = jumpGravity;
        }
        else
        {
            rb.gravityScale = normalGravity; 
        }
    }

    public void CheckGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
    public void CheckForWalls()
    {
        isTouchingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, wallLayer);
    }
    public bool CheckForCeiling()
    {
        return Physics2D.OverlapCircle(headCheck.position, headCheckRadius, groundLayer);
    }

    void HandleAnimations()
    {
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("yVelocity", rb.linearVelocity.y);
    }

    void Flip()
    {
        if (currenntState == deathState)
            return;
        if(moveInput.x > 0.1f)
        {
            facingDirection = 1;
        }
        else if (moveInput.x < -0.1f)
        {
            facingDirection = -1;
        }
        transform.localScale = new Vector3(facingDirection, 1, 1);
    }

    public void AttackAnimationFinished()
    {
        currenntState.AttackAnimationFinished();
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnAttack(InputValue value)
    {
        attackPressed = value.isPressed;
    }

    public void OnRun(InputValue value)
    {
        runPressed = value.isPressed;
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            if(isGrounded && !CheckForCeiling() || isTouchingWall)
                jumpPressed = true;
            jumpReleased = false;
        }
        else
        {
            jumpReleased = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(wallCheck.position, wallCheckRadius);


        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(headCheck.position, headCheckRadius);
    }
}
