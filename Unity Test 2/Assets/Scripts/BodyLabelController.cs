using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BodyLabelController : MonoBehaviour
{
    public GameObject Body;

    private SpriteRenderer _renderer;
    private BoxCollider2D _collider;
    private TextMeshProUGUI _uGUI;

    private void Awake()
    {
        _renderer = Body.GetComponent<SpriteRenderer>();
        _collider = GetComponent<BoxCollider2D>();
        _uGUI = GetComponent<TextMeshProUGUI>();
    }

    private void LateUpdate()
    {
        var _location = Body.transform.position;
        var height = _renderer.bounds.size.y;
        var locY = _location.y - (height / 2) - (10f * transform.localScale.y);

        transform.position = new Vector3(_location.x, locY, 1f);
        _collider.size = _uGUI.bounds.size;
    }

    private static Vector3 PointOnCircle(float radius, float angleInDegrees, Vector3 origin)
    {
        var radians = angleInDegrees * Math.PI / 180f;

        // Convert from degrees to radians via multiplication by PI/180        
        float x = (float)(radius * Math.Cos(radians)) + origin.x;
        float y = (float)(radius * Math.Sin(radians)) + origin.y;

        return new Vector3(x, y, 1f);
    }

    private void OnMouseDown()
    {
        Camera.main.transform.position = new Vector3(Body.transform.position.x, Body.transform.position.y, Camera.main.transform.position.z);
    }
}
