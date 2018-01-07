using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class CometController : MonoBehaviour
{
    public GameObject Body;

    public float OrbitDistance;
    public float Bearing;
    public float LineWidth = 0.02f;

    private LineRenderer _lineRenderer;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        DrawOrbit();
        transform.position = Body.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = Body.transform.position;
    }

    private void DrawOrbit()
    {
        _lineRenderer.widthMultiplier = LineWidth;
        _lineRenderer.SetPosition(0, Vector3.zero);
        Vector3 pos = new Vector3(OrbitDistance * Mathf.Cos(Bearing), OrbitDistance * Mathf.Sin(Bearing), 0f);
        _lineRenderer.SetPosition(1, pos);
    }

    private void OnMouseDown()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
    }
}
