using UnityEngine;
using UnityEngine.UI;

public class StarController : MonoBehaviour
{
	public Camera MainCamera;

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
		MainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, MainCamera.transform.position.z);
	}
}
