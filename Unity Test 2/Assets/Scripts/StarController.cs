using UnityEngine;

public class StarController : MonoBehaviour
{
    private void OnMouseDown()
	{
		Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
    }
}
