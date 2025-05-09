using Unity.Cinemachine;
using UnityEngine;

public class ToggleCameraFollow : MonoBehaviour
{
    public bool destroyWhenLeave;
    public bool focusCamera;
    public bool stopCamera;

    public Transform player;
    public Transform newFollowPosition;
    public CinemachineCamera cinemachineCamera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(stopCamera) cinemachineCamera.Follow = null;

            if (focusCamera) cinemachineCamera.Follow = newFollowPosition;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (stopCamera) cinemachineCamera.Follow = player;

            if (focusCamera) cinemachineCamera.Follow = newFollowPosition;

            if (destroyWhenLeave) Destroy(this.gameObject);
        }
    }
}
