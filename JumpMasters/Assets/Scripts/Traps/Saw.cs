using UnityEngine;
using UnityEngine.Splines;
public class Saw : MonoBehaviour
{
    public SplineContainer splinePath;
    public float speed;
    public float distancePercent  = 0;

    private float splineLength;
    void Start()
    {
        if (splinePath != null)
        {
            splineLength = splinePath.CalculateLength();
        }
    }
    // Update is called once per frame
    void Update()
    {
        distancePercent += speed * Time.deltaTime / splineLength;

        if (splinePath != null)
        {
            Vector3 currentPosition = splinePath.EvaluatePosition(distancePercent);
            transform.position = currentPosition;
        }

        if (distancePercent > 1f) { distancePercent = 0; }
        if (distancePercent < -1f) { distancePercent = 0; }
    }
}
