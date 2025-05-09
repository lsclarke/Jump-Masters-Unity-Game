using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;

public class PlayerRailGrind : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public SplineContainer RailPath;
    public float speed;

    public float RaildistancePercent = 0;
    private float railLength;
    private bool IsOnRail;
    private bool IsRailGrinding;

    public float linedistance;
    public LayerMask RailLayer;
    public Transform FeetToRail;
    public float Offset;

    private RaycastHit2D hit;
    void Start()
    {
        playerMovement = this.gameObject.GetComponent<PlayerMovement>();
        railLength = RailPath.CalculateLength();
    }

    public bool OnRail()
    {
        IsOnRail = Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z), Vector2.down, linedistance, RailLayer);

        return IsOnRail;
    }

    private void FixedUpdate()
    {
        OnRail();
        if (Input.GetKeyDown(KeyCode.Space) && OnRail())
        {
            playerMovement.physics.AddForce(Vector2.up * playerMovement.JumpSpeed, ForceMode2D.Impulse);
        }
        if ((playerMovement.Direction().x > 0 && OnRail()) || (playerMovement.Direction().x < 0 && OnRail()))
        {
            speed = 5.75f;
        }
        if ((playerMovement.Direction().x == 0 && OnRail()))
        {
            speed = 5;
        }
    }
    public Vector2 direction;
    // Update is called once per frame
    void Update()
    {

        // Cast a ray in the direction specified in the inspector.
        hit = Physics2D.Raycast(hit.point, direction);

        // If something was hit, draw a line from the start position to the point we intersected.
        if (hit && IsOnRail) Debug.Log("HIT LOCATION: "+ hit.point);

        Debug.DrawLine(new Vector3(hit.point.x, hit.point.y + 5), new Vector3(hit.point.x, hit.point.y - 5), Color.blue, 2.0f);
        Debug.DrawRay(transform.position, Vector2.down * linedistance, Color.red);

        if (Input.GetMouseButtonDown(0))
        {
            Debug.DrawLine(new Vector3(hit.point.x, hit.point.y + 5), new Vector3(hit.point.x, hit.point.y - 5), Color.blue,2.0f);
        }

        //If is falling and contacts rail
        if ( playerMovement.physics.linearVelocityY < 0.01f && IsOnRail)
        {

            Vector3 currentPosition = RailPath.EvaluatePosition(RaildistancePercent);
            FeetToRail.position = currentPosition;

            playerMovement.physics.gravityScale = 0;

            if(this.transform.localScale.x == 1)
            RaildistancePercent += speed * Time.deltaTime / railLength;

            if (this.transform.localScale.x == -1)
                RaildistancePercent -= speed * Time.deltaTime / railLength;

            Vector3 newPosition = new Vector3(FeetToRail.position.x, FeetToRail.position.y + Offset, FeetToRail.position.z);
            this.transform.position = newPosition;
           


            if (RaildistancePercent > 1f) { playerMovement.physics.AddForce((Vector2.right + Vector2.up) * playerMovement.JumpSpeed, ForceMode2D.Impulse); RaildistancePercent = 1f; }
            if (RaildistancePercent < 0f) { playerMovement.physics.AddForce((Vector2.left + Vector2.up) * playerMovement.JumpSpeed, ForceMode2D.Impulse); RaildistancePercent = 0f; }
        }
        else
        {
            playerMovement.physics.gravityScale = 1;
            FeetToRail.position = new Vector3(0f, -0.888999999f, 0f);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(hit.point, 2f);
    }
}
