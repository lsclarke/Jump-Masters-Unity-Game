using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Gate : MonoBehaviour
{
    public LayerMask playerLayer;
    private Collider2D collider;
    public ScoreManager score_manager;

    public int OrbsToActivteGate;
    public GameObject[] Modes = new GameObject[1];

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
