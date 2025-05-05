using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Orb : MonoBehaviour
{
    private Animator animator;
    public LayerMask playerLayer;
    private Collider2D collider;
    public Light2D orb_light;
    public ScoreManager score_manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = this.GetComponent<Animator>();
        animator.SetBool("isCollected", false);
        collider = this.GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("isCollected", true);
            transform.localScale = new Vector3(7, 7, 7);
            Add();
        }
    }

    public void Add()
    {
        score_manager.orb_Count += 1;

        if(score_manager.orb_Count > 3)
        {
            score_manager.orb_Count = 3;
        }
    }

    public void DestroyObject()
    {
        Destroy(this.gameObject);
        Destroy(this.collider);
        Destroy(orb_light);
    }
}
