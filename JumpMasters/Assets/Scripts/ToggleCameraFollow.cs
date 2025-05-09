using Unity.Cinemachine;
using UnityEngine;

public class ToggleCameraFollow : MonoBehaviour
{
    public bool destroyWhenLeave;
    public bool focusCamera;
    public bool constant;
    public bool stopCamera;
    public LayerMask playerLayer;
    public Transform player;
    public Transform newFollowPosition;
    public CinemachineCamera cinemachineCamera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.layer == playerLayer)
        {
            Debug.Log("PLAYER DETECTED");
            if (stopCamera) cinemachineCamera.Follow = null;

            if (focusCamera) cinemachineCamera.Follow = newFollowPosition;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.layer == playerLayer)
        {
            
            Debug.Log("PLAYER DETECTED");
            
            if (!constant)
            {
                focusCamera = false;
                if (!focusCamera) { cinemachineCamera.Follow = newFollowPosition; Destroy(this.gameObject); }
                if (!stopCamera) cinemachineCamera.Follow = player;
            }
            else
            {
                stopCamera = true;
                focusCamera = true;
            }

            if (destroyWhenLeave) Destroy(this.gameObject);
        }
    }
}
