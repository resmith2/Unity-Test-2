using UnityEngine;

public class StarController : MonoBehaviour
{
	// Use this for initialization
	public void Start()
	{
	}

	// Update is called once per frame
	public void LateUpdate()
	{
	}

	public void OnMouseDown()
	{
		Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
        Debug.Log(Camera.main.transform.position);
    }
}
