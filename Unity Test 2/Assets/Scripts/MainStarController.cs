using System.Runtime.InteropServices;
using Repository;
using UnityEngine;

public class MainStarController : MonoBehaviour
{
	private void Awake()
	{
		var repo = new ReadStaticData();
		var bodies = repo.ReadSolBodyies();
	}

	private void OnMouseDown()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
    }
}
