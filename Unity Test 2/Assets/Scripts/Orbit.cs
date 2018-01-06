using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Orbit : MonoBehaviour
{
    public int vertexCount = 100;
    public float lineWidth = 0.4f;
    public float radius;

    private LineRenderer _lineRenderer;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        DrawOrbit();
    }

    private void LateUpdate()
    {
        DrawOrbit();
    }

    private void DrawOrbit()
    {
        _lineRenderer.widthMultiplier = lineWidth;
        float deltaTheta = (2f * Mathf.PI) / vertexCount;
        float theta = 0f;
        _lineRenderer.positionCount = vertexCount;

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
        float deltaTheta = (2f * Mathf.PI) / vertexCount;
        float theta = 0f;
        Vector3 oldPos = Vector3.zero;

        for (int x = 0; x < vertexCount + 1; x++)
        {
            Vector3 pos = new Vector3(radius * Mathf.Cos(theta), radius * Mathf.Sin(theta), 0f);
            Gizmos.DrawLine(oldPos, transform.position + pos);
            oldPos = transform.position + pos;
            theta += deltaTheta;
        }
    }
#endif

}