using System;
using UnityEngine;

public class BodyLabelController : MonoBehaviour
{
    public GameObject Body;

    // Use this for initialization
    private void Start()
    {
    }

    private void LateUpdate()
    {
        var _location = Body.transform.position;
        var height = Body.GetComponent<SpriteRenderer>().bounds.size.y;
        var locY = _location.y - (height / 2) - (10f * transform.localScale.y);

        transform.position = new Vector3(_location.x, locY, 1f);
    }

    private static Vector3 PointOnCircle(float radius, float angleInDegrees, Vector3 origin)
    {
        var radians = angleInDegrees * Math.PI / 180f;

        // Convert from degrees to radians via multiplication by PI/180        
        float x = (float)(radius * Math.Cos(radians)) + origin.x;
        float y = (float)(radius * Math.Sin(radians)) + origin.y;

        return new Vector3(x, y, 1f);
    }
}
