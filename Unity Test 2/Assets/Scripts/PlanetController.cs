using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class PlanetController : MonoBehaviour
{
    public GameObject Body;
    public int VertexCount = 100;
    public float LineWidth = 0.2f;

    private LineRenderer _lineRenderer;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void LateUpdate()
    {
        transform.position = Body.transform.position;
        DrawOrbit();
    }

    private void DrawOrbit()
    {
        _lineRenderer.widthMultiplier = LineWidth;
        float deltaTheta = (2f * Mathf.PI) / VertexCount;
        float theta = 0f;
        _lineRenderer.positionCount = VertexCount;
        float radius = transform.position.x;

        for (int x = 0; x < _lineRenderer.positionCount; x++)
        {
            Vector3 pos = new Vector3(radius * Mathf.Cos(theta), radius * Mathf.Sin(theta), 0f);
            _lineRenderer.SetPosition(x, pos);
            theta += deltaTheta;
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        float deltaTheta = (2f * Mathf.PI) / VertexCount;
        float theta = 0f;
        Vector3 oldPos = Vector3.zero;
        float radius = transform.position.x;

        for (int x = 0; x < VertexCount + 1; x++)
        {
            Vector3 pos = new Vector3(radius * Mathf.Cos(theta), radius * Mathf.Sin(theta), 0f);
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
