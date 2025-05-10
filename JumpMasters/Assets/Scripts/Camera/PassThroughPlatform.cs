using UnityEngine;

public class PassThroughPlatform : MonoBehaviour
{

    private bool canPassThrough;
    private Collider2D myCollider;

    private void Start()
    {
        myCollider = this.gameObject.GetComponent<Collider2D>();
    }

    private void Update()
    {
        //If pressing the Down button, then can can Pass Through object
        if (Input.GetKeyDown(KeyCode.S))
        {
            canPassThrough = true;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            canPassThrough = false;
        }

        if (!canPassThrough) myCollider.isTrigger = false;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        while (collision.gameObject.tag == "Player" && canPassThrough)
        {
            myCollider.isTrigger = true;
            break;
        }
    }

}
