using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // movement
    [Header("Movement")]

    public Rigidbody2D physics;
    private Vector2 PlayerInput;
    public float MoveSpeed;
    public float MoveSpeedMultiplier;
    public float Acceleration;
    public float Decceleration;

    [Header("Jump")]
    public bool canJump;
    public bool isJumping;
    public float JumpSpeed;

    [Header("Player Direction Facing")]
    public bool facingRight;


    [Header("Ground Detection")]
    //ground
    public bool grounded;
    public float linedistance;
    public LayerMask groundLayer;

    [Header("Wall Detection")]
    //wall
    public bool isWallSliding;
    public bool canWallJump;
    public float wallCheckRadius;
    public float wallSlideSpeed;
    public LayerMask wallLayer;

    public Vector2 WallJumpForce;
    public Vector2 WallJumpDirection;
    public bool isWallJumping;
    public float WallJumpDuration;
    public float WallJumpCounter;
    public float WallJumpTime;

    [Header("Music and SFX")]

    public AudioSource audio;
    public AudioClip[] SFX;

    private PlayerRailGrind rail;
    public void PlayerDirection()
    {
        //Flip Sprite
        facingRight = !facingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void PlayerDirectionalChange()
    {
        //If moving right flip sprite to the right, if moving left flip sprite to the left
        if (physics.linearVelocity.x < -0.01f && !facingRight && !isWallJumping)
        {
            PlayerDirection();
        }

        if (physics.linearVelocity.x > 0.01f && facingRight && !isWallJumping)
        {
            PlayerDirection();
        }
    }

    public Vector2 Direction()
    {
        return PlayerInput;
    }

    public bool IsOnWall()
    {
        while (!grounded)
        {
            isWallSliding = Physics2D.OverlapCircle(transform.position, wallCheckRadius, wallLayer);

            if (isWallSliding)
            {
                WallJumpDirection.x = -transform.localScale.x;
                canWallJump = true;
                WallJumpCounter = WallJumpTime;
                physics.linearVelocity = new Vector2(physics.linearVelocityX, Mathf.Clamp(physics.linearVelocityY, -wallSlideSpeed, float.MaxValue));

            }
            else
            {
                canWallJump = false;
                WallJumpCounter -= Time.deltaTime;
                physics.linearVelocity = new Vector2(physics.linearVelocityX, physics.linearVelocityY);

            }
            break;
        }
        return isWallSliding;
    }
    public bool OnGround()
    {
        Debug.DrawRay(transform.position, Vector2.down * linedistance, Color.red);
        grounded = Physics2D.Raycast(transform.position, Vector2.down, linedistance, groundLayer);
        rail = this.gameObject.GetComponent<PlayerRailGrind>();
        if (grounded)
        {
            canJump = true;
            isJumping = false;
            canWallJump = false;
            isWallSliding = false;
            isWallJumping = false;
        }
        else
        {
            canJump = false;
        }

            return grounded;
    }


    public void Friction()
    {
        if (PlayerInput.x.Equals(0) & grounded)
        {
            float continuedMovement = PlayerInput.x * MoveSpeed;
            if (Mathf.Abs(physics.linearVelocity.x) > 0)
            {
                continuedMovement -= 0.00001f;
                physics.linearVelocity = new Vector2(continuedMovement, physics.linearVelocity.y);
            }
        }
        else
        {
            physics.linearVelocity = new Vector2(physics.linearVelocity.x, physics.linearVelocity.y);
        }
    }

    public void MovePlayer()
    {
        PlayerInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) ;

        float PlayerVelocity = PlayerInput.x * MoveSpeed;

        float SpeedDifference = PlayerVelocity - physics.linearVelocity.x;

        float PlayerAcceleration = (Mathf.Abs(PlayerVelocity) > 0.1f) ? Acceleration : Decceleration;

        float movement = Mathf.Pow(Mathf.Abs(SpeedDifference) * Acceleration, MoveSpeedMultiplier) * Mathf.Sign(SpeedDifference);

        PlayerDirectionalChange();

        physics.AddForce(movement * Vector2.right);
    }

    public void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rail = this.gameObject.GetComponent<PlayerRailGrind>();
            physics.AddForce(Vector2.up * JumpSpeed, ForceMode2D.Impulse);
            isJumping = true;
        }

        PlayerWallJump();
    }

    public void PlayerWallJump()
    {
        if(canWallJump & WallJumpCounter > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                physics.linearVelocity = new Vector2(WallJumpDirection.x * WallJumpForce.x, WallJumpForce.y);
                canWallJump = false;
                isWallJumping = true;
                WallJumpCounter = 0;

                if (transform.localScale.x != WallJumpDirection.x)
                {
                    PlayerDirection();
                }

                Invoke(nameof(StopWallJump), WallJumpDuration);
            }
        }
    }

    public void StopWallJump()
    {
        isWallJumping = false;
    }
    private void FixedUpdate()
    {
        MovePlayer();
        PlayerJump();
        OnGround();
        IsOnWall();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, wallCheckRadius);
    }
}