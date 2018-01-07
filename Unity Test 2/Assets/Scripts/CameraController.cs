using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Canvas BodyCanvas;

    private float _scale = 1f;

    // Update is called once per frame
    private void LateUpdate()
	{
		var horizontal = Input.GetAxis("Horizontal");
		var vertical = Input.GetAxis("Vertical");
        var height = Input.GetAxis("Mouse ScrollWheel");
        var oldPos = Camera.main.transform.position;

        var movement = new Vector3(horizontal, vertical, 0f);
        transform.position += movement;

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

        BodyCanvas.transform.localScale = new Vector3(_scale, _scale, 1f);
    }

    private void ResetPosition()
	{
		transform.position = new Vector3(0, 0, -10f);
	}
}
