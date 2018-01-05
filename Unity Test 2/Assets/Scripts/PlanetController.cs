using UnityEngine;

public class PlanetController : MonoBehaviour
{
    public Camera MainCamera;

    // Use this for initialization
    void Start()
    {
    }

    public void OnMouseDown()
    {
        MainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, MainCamera.transform.position.z);
    }
}
