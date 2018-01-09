using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(LineRenderer))]
public class PlanetController : MonoBehaviour, Assets.Scripts.IBodyMovedTarget
{
    public GameObject TheBodyIOrbit;
    public float OrbitalPeriodInYears;
    public float OrbitDistance;
    public int DayOfYear = 180;
    public int VertexCount = 100;
    public float LineWidth = 0.02f;

    private LineRenderer _lineRenderer;
    private float _daysPerYear;


    private void Awake()
    {
        transform.position = new Vector3(OrbitDistance, 0f, 0f);
        _lineRenderer = GetComponent<LineRenderer>();
        _daysPerYear = OrbitalPeriodInYears * 360f;

        CalculatePosition();
        DrawOrbit(OrbitDistance);
    }

    private void LateUpdate()
    {
        var radius = Mathf.Sqrt(transform.position.x * transform.position.x + transform.position.y * transform.position.y);
        DrawOrbit(radius);
    }

    public void UpdatePosition(string sender)
    {
        Debug.Log(name + ": Received Message from " + sender);
    }

    private void CalculatePosition()
    {
        var theta = ((2f * Mathf.PI) / _daysPerYear) * DayOfYear;
        Vector3 pos = new Vector3(OrbitDistance * Mathf.Cos(theta), OrbitDistance * Mathf.Sin(theta), 0f);
        transform.position = pos + TheBodyIOrbit.transform.position;

        ExecuteEvents.Execute<Assets.Scripts.IBodyMovedTarget>(TheBodyIOrbit, null, (x, y) => x.UpdatePosition(name));
    }

    private void DrawOrbit(float radius)
    {
        _lineRenderer.widthMultiplier = LineWidth;
        float deltaTheta = (2f * Mathf.PI) / VertexCount;
        float theta = 0f;
        _lineRenderer.positionCount = VertexCount;

        for (int x = 0; x < _lineRenderer.positionCount; x++)
        {
            Vector3 pos = new Vector3(radius * Mathf.Cos(theta), radius * Mathf.Sin(theta), 0f);
            _lineRenderer.SetPosition(x, pos + TheBodyIOrbit.transform.position);
            theta += deltaTheta;
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        float deltaTheta = (2f * Mathf.PI) / VertexCount;
        float theta = 0f;
        Vector3 oldPos = Vector3.zero;

        for (int x = 0; x < VertexCount + 1; x++)
        {
            Vector3 pos = new Vector3(OrbitDistance * Mathf.Cos(theta), OrbitDistance * Mathf.Sin(theta), 0f);
            Gizmos.DrawLine(oldPos, transform.position + pos);
            oldPos = transform.position + pos;
            theta += deltaTheta;
        }
    }
#endif

    private void OnMouseDown()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
    }
}
