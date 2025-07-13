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

    [Header("Slope Detection")]

    [SerializeField]
    private float slopeCheckDistance;

    private float originalSlopeCheckDistance;

    private float slopeDownAngle;

    private float slopeDownAngleOld;

    private float slopeSideAngle;

    private Vector2 slopeNormalPerp;

    private Vector2 colliderSize;

    private Vector2 newVelocity;

    [SerializeField]
    private bool isOnSlope;

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
        grounded = Physics2D.Raycast(transform.position, Vector2.down, linedistance, groundLayer);
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

    private void SlopeCheck()
    {
        Vector2 checkPos = transform.position - new Vector3(0.0f, colliderSize.y / 2);
        SlopeCheckVertical(checkPos);
        SlopeCheckHorizontal(checkPos);
    }

    private void SlopeCheckHorizontal(Vector2 checkPos)
    {
        RaycastHit2D slopeHitFront = Physics2D.Raycast(checkPos, transform.right, 0.25f, groundLayer);
        RaycastHit2D slopeHitBack = Physics2D.Raycast(checkPos, -transform.right, 0.25f , groundLayer);

        if (slopeHitFront)
        {
            isOnSlope = true;
            slopeSideAngle = Vector2.Angle(slopeHitFront.normal, Vector2.up);
        }
        else if (slopeHitBack)
        {
            isOnSlope = true;
            slopeSideAngle = Vector2.Angle(slopeHitBack.normal, Vector2.up);
        }
        else
        {
            slopeSideAngle = 0.0f;
            isOnSlope = false;
        }

    }

    private void SlopeCheckVertical(Vector2 checkPos)
    {
        RaycastHit2D hit = Physics2D.Raycast(checkPos, Vector2.down, slopeCheckDistance, groundLayer);

        if (hit)
        {
            Vector2 originalNormal = Vector2.Perpendicular(new Vector2(-1.00f,0.00f));

            slopeNormalPerp = Vector2.Perpendicular(hit.normal);

            slopeDownAngle = Vector2.Angle(hit.normal, Vector2.up);

            while (slopeDownAngle != slopeDownAngleOld)
            {
                isOnSlope = true;
                break;
            }
            slopeDownAngleOld = slopeDownAngle;

            while (slopeDownAngle == 0)
            {
                isOnSlope = false;
                break;
            }


                Debug.DrawRay(hit.point, slopeNormalPerp, Color.red);

            Debug.DrawRay(hit.point, hit.normal, Color.green);
        }

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
            physics.AddForce(Vector2.up * JumpSpeed, ForceMode2D.Impulse);
            isJumping = true;

            //Jump Audio
            audio.Play();
            int randomInt = Random.Range(0, 2);
            if (randomInt > 1)
            {
                audio.clip = SFX[1];
            }
            else
            {
                audio.clip = SFX[0];
            }

            
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

                //Jump Audio
                audio.Play();
                int randomInt = Random.Range(0, 2);
                if (randomInt > 1)
                {
                    audio.clip = SFX[1];
                }
                else
                {
                    audio.clip = SFX[0];
                }

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

}
