using UnityEngine;

public class CameraController : MonoBehaviour
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
        var oldPos = Camera.main.transform.position;

        if (height > 0)
        {
            _scale *= 2;
            Camera.main.transform.position *= 2f;
        }

        if (height < 0)
        {
            _scale /= 2;
            Camera.main.transform.position /= 2f;
        }

        if (_scale > 10)
        {
            _scale = 10f;
            Camera.main.transform.position = oldPos;
        }

        if (_scale < .001)
        {
            _scale = .001f;
            Camera.main.transform.position = oldPos;
        }

        Debug.Log("Before: " + Camera.main.transform.position + ", " + _scale);
        BodyCanvas.transform.localScale = new Vector3(_scale, _scale, 1f);
        Debug.Log("After: " + Camera.main.transform.position + ", " + _scale);

    }

    public void ResetPosition()
	{
		transform.position = new Vector3(0, 0, -10f);
	}
}
