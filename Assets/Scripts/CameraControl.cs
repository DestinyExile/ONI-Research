using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float ScrollSpeed = 250f;

    private Vector3 dragOrigin;

    private void Update()
    {
        PanCamera();
        cam.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed;
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, 200f, 600f);

        cam.transform.position = ClampCamera(cam.transform.position);
    }

    private void PanCamera()
    {
        if(Input.GetMouseButtonDown(0))
        {
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if(Input.GetMouseButton(0))
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);

            cam.transform.position += difference;
        }
    }

    private Vector3 ClampCamera(Vector3 targetposition)
    {
        float camHeight = cam.orthographicSize;
        float camWidth = cam.orthographicSize * cam.aspect;

        float minX = -1250f + camWidth;
        float maxX = 1250f - camWidth;
        float minY = -2000f + camHeight;
        float maxY = 2000f - camHeight;

        float newX = Mathf.Clamp(targetposition.x, minX, maxX);
        float newY = Mathf.Clamp(targetposition.y, minY, maxY);

        return new Vector3(newX, newY, targetposition.z);
    }
}
