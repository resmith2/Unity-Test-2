using UnityEngine;

public class CometBodyController : MonoBehaviour
{
    public float OrbitDistance;
    public float OrbitPeriodInYears;
    public int OrbitDay;
    public float Bearing;
    public bool InBound = false;

    private LineRenderer _lineRenderer;

    private void Awake()
    {
        PositionCommet();
    }

    private void PositionCommet()
    {
        var daysInOrbit = 360 * OrbitPeriodInYears;
        var distTraveledPerDay = OrbitDistance / daysInOrbit;
        float currentPosition;

        if (InBound)
            currentPosition = OrbitDistance - (distTraveledPerDay * OrbitDay);
        else
            currentPosition = distTraveledPerDay * OrbitDay;

        Vector3 pos = new Vector3(currentPosition * Mathf.Cos(Bearing), currentPosition * Mathf.Sin(Bearing), 0f);
        transform.position = pos;
    }
}
