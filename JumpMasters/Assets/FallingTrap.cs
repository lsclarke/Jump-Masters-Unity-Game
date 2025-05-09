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
    private Rigidbody2D physics;
    public Transform newPosition;

    private Vector3 startPosition;
    private float elapseTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        physics = this.GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        physics.gravityScale = 1;
    }

    public bool OnGround()
    {
        Debug.DrawRay(transform.position, Vector2.down * linedistance, Color.red);
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, linedistance, groundLayer);
        return isGrounded;
    }

    IEnumerator WaitBeforeMove(float deltaTime)
    {
        yield return new WaitForSeconds(deltaTime);
        elapseTime += Time.deltaTime; 
        float percentage = elapseTime / speed;
        physics.gravityScale = 0;
        transform.position = Vector2.MoveTowards(transform.position, newPosition.position, speed);

        yield return new WaitForSeconds(deltaTime);
        physics.gravityScale = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if( OnGround() ) StartCoroutine(WaitBeforeMove(waitTime));
    }
}
