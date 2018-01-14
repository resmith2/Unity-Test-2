using UnityEngine;
using Repository;

public class SpriteBodyController : MonoBehaviour
{
    public GameObject Body;

    private Class1 _test;

    private void Awake()
    {
        _test = new Class1();
    }

    private void LateUpdate()
    {
        transform.position = Body.transform.position;
    }

    private void OnMouseDown()
    {
        Debug.Log(_test.GetBefore());
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
        Debug.Log(_test.GetAfter());
    }
}