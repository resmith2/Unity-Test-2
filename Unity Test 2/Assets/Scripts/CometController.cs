using UnityEngine;

public class CometController : MonoBehaviour
{
    public GameObject Body;

    private void LateUpdate()
    {
        transform.position = Body.transform.position;
    }

    private void OnMouseDown()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
    }
}
