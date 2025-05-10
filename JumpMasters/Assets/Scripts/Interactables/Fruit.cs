using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Fruit : MonoBehaviour
{
    private Animator animator;
    public LayerMask playerLayer;
    private Collider2D collider;
    public Light2D orb_light;
    public ScoreManager score_manager;
    private PlayerHealth player_Health;
    public AudioSource audio_source;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player_Health = collision.GetComponent<PlayerHealth>(); 
            animator.SetBool("isCollected", true);
            audio_source.Play();
            transform.localScale = new Vector3(7, 7, 7);
            Invoke("Add",0.01f);
        }
    }

    public void Add()
    {
        score_manager.fruit_Count += Random.Range(2,5);

        if (score_manager.fruit_Count >= 25) player_Health.Health += 1;
    }

    public void DestroyObject()
    {
        Destroy(this.gameObject);
        Destroy(this.collider);
        Destroy(orb_light);
    }
}
