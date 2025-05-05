using UnityEngine;

public class ParticleManager : MonoBehaviour
{

    public ParticleSystem RunParticleSystems;
    public PlayerMovement playerMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RunParticleSystems.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        //if (playerMovement.isRunning & playerMovement.grounded)
        //{
        //    RunParticleSystems.Play();
        //}
        //else
        //{
        //    RunParticleSystems.Stop();
        //}
    }
}
