using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Fruit : MonoBehaviour
{
    private Animator animator;
    public LayerMask playerLayer;
    private Collider2D collider;
    public Light2D orb_light;

    public enum Anim_States
    {
        Apple = 1,
        Banana,
        Orange,
        Pinapple,
        Strawberry,
        Melon,
        Cherries,
        Kiwi,
    };

    public Anim_States state;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = this.GetComponent<Animator>();
        animator.SetBool("isCollected", false);
        collider = this.GetComponent<Collider2D>();
    }

    private void Update()
    {
        animator.SetInteger("FruitStates", (int)state);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("isCollected", true);
            transform.localScale = new Vector3(7, 7, 7);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("isCollected", true);
            transform.localScale = new Vector3(7, 7, 7);
        }
    }
    public void DestroyObject()
    {
        Destroy(this.gameObject);
        Destroy(this.collider);
        Destroy(orb_light);
    }
}
