using Unity.VisualScripting;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public float interactRange;
    public LayerMask interactMask;
    public bool canInteract = false;
    public bool isInteracting = false;
    public Collider2D InteractableObject;

    public KeyCode InteractButton;

    public void Activate()
    {
        if (canInteract)
        {
            if (Input.GetKeyDown(InteractButton))
            {
                var obj = InteractableObject.GetComponent<IInteractable>();
                obj.Interact();
            }
        }
    }

    private void FixedUpdate()
    {
        canInteract = InteractDetector();
    }

    public bool InteractDetector()
    {
        return Physics2D.OverlapCircle(this.transform.position, interactRange, interactMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, interactRange);
    }
}
