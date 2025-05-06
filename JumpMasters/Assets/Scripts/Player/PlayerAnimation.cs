using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Rigidbody2D physics;
    public PlayerMovement movement_script;
    public Animator animator;
    public PlayerHealth player_health;

    enum Anim_States
    {
        Idle = 0,
        Moving,
        Jumping,
        Falling,
        WallSlide,
        WallJump,
    };

    private Anim_States state;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movement_script = this.transform.parent.GetComponent<PlayerMovement>();
        player_health = this.transform.parent.GetComponent<PlayerHealth>();
        physics = this.transform.parent.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movement_script == null) return;

        animator.SetBool("isHit", player_health.isKnockedBack);

        if (movement_script.grounded)
        {
            if (Mathf.Abs(movement_script.Direction().x) > 0f)
            {
                state = Anim_States.Moving;
                Debug.Log(state);
            }
            else if (physics.linearVelocityX == 0) state = Anim_States.Idle;
        }
        else
        {
            if (movement_script.isWallSliding)
            {
                state = Anim_States.WallSlide;
            }
            if (movement_script.isWallJumping)
            {
                state = Anim_States.WallJump;
            }

            if(physics.linearVelocityY > 0.1f && !movement_script.isWallSliding)
            {
                state = Anim_States.Jumping;
            }else if (physics.linearVelocityY < 0.0f && !movement_script.isWallSliding)
            {
                state = Anim_States.Falling;
            }
        }
        animator.SetInteger("MoveStates", (int)state);
    }
}
