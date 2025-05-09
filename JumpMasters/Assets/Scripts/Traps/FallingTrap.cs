using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class FallingTrap : MonoBehaviour
{
    public float speed;
    private bool isGrounded;
    public float linedistance;
    public LayerMask groundLayer;

    public float waitTime;
    public Transform newPosition;

    public Transform startPosition;
    private float elapseTime;

    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    public bool OnGround()
    {
        Debug.DrawRay(transform.position, Vector2.down * linedistance, Color.red);
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, linedistance, groundLayer);
        return isGrounded;
    }

    IEnumerator WaitBeforeMove(float deltaTime)
    {
        animator.SetBool("slammed", true);
        animator.SetBool("idle", false);
        yield return new WaitForSeconds(deltaTime);
        animator.SetBool("idle", true);
        transform.position = Vector2.MoveTowards(transform.position, newPosition.position, speed -.15f);
        yield return new WaitForSeconds(deltaTime);
        StartCoroutine(Reset(waitTime));
    }

    IEnumerator Reset(float deltaTime)
    {
        animator.SetBool("blink", true);
        yield return new WaitForSeconds(deltaTime + 1);
        animator.SetBool("blink", false);
        animator.SetBool("idle", true);
        transform.position = Vector2.MoveTowards(transform.position, startPosition.position, speed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if(OnGround()) StartCoroutine(WaitBeforeMove(waitTime));

        if (!OnGround() && transform.position != newPosition.position)
        {
            animator.SetBool("slammed", false);
            animator.SetBool("idle", true);
        }
    }
}
