using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ParallaxScript : MonoBehaviour
{
    private float length, startpointx, startpointy;
    public GameObject Player;
    public float parallaxEffect;

    private void Start()
    {
        InitializeVars();
    }
    void InitializeVars()
    {
        startpointx = this.transform.position.x;
        startpointy = this.transform.position.y;
        length = this.GetComponent<TilemapRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        float xdistance = (Player.transform.position.x * parallaxEffect);
        float ydistance = (Player.transform.position.y * parallaxEffect);
        transform.position = new Vector3(startpointx + xdistance, startpointy + ydistance, transform.position.z);
    }

}
