using UnityEngine;

public class MyCameraController : MonoBehaviour
{
    public Canvas BodyCanvas;

    private float _scale = 1f;

	// Update is called once per frame
	public void LateUpdate()
	{
		var horizontal = Input.GetAxis("Horizontal");
		var vertical = Input.GetAxis("Vertical");
        var height = Input.GetAxis("Mouse ScrollWheel");

		var movement = new Vector3(horizontal, vertical, 0f);
        transform.position += movement;

        if (height > 0)
            _scale *= 2;

        if (height < 0)
            _scale /= 2;

        if (_scale > 10)
            _scale = 10f;

        if (_scale < .001)
            _scale = .001f;

        BodyCanvas.transform.localScale = new Vector3(_scale, _scale, 1f);
    }

    public void ResetPosition()
	{
		transform.position = new Vector3(0, 0, -10f);
	}
}
