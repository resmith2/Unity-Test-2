using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class CometController : MonoBehaviour
{
    public float OrbitDistance;
    public float OrbitPeriodInYears;
    public int OrbitDay;
    public float Bearing;
    public float LineWidth = 0.2f;
    public bool InBound = false;

    private LineRenderer _lineRenderer;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        DrawOrbit();
        PositionCommet();
    }

    private void DrawOrbit()
    {
        _lineRenderer.widthMultiplier = LineWidth;
        _lineRenderer.SetPosition(0, Vector3.zero);
        Vector3 pos = new Vector3(OrbitDistance * Mathf.Cos(Bearing), OrbitDistance * Mathf.Sin(Bearing), 0f);
        _lineRenderer.SetPosition(1, pos);
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
