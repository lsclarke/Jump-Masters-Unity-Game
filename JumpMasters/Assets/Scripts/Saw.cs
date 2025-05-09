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
        splineLength = splinePath.CalculateLength();
    }

    // Update is called once per frame
    void Update()
    {
        distancePercent += speed * Time.deltaTime / splineLength;

        Vector3 currentPosition = splinePath.EvaluatePosition(distancePercent);
        transform.position = currentPosition;

        if (distancePercent > 1f) { distancePercent = 0; }
        if (distancePercent < -1f) { distancePercent = 0; }
    }
}
