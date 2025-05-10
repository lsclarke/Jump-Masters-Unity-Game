using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Gate : MonoBehaviour
{
    public LayerMask playerLayer;
    private Collider2D collider;
    public ScoreManager score_manager;

    public int OrbsToActivteGate;
    public GameObject[] Modes = new GameObject[1];

    public GameObject interact_icon;
    public GameObject HighScore_Screen;
    public PlayerMovement movement;

    public AudioSource audio;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            interact_icon.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                movement.enabled = false;
                audio.Play();
                HighScore_Screen.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            interact_icon.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(score_manager.orb_Count >= OrbsToActivteGate)
        {
            Modes[0].SetActive(false);
            Modes[1].SetActive(true);
        }
    }
}
