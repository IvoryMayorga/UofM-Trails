using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomin : MonoBehaviour
{
    private Camera cam;
    private float targetZoom;
    private float zoomFactor = 50f;
    private float zoomLerpSpeed = 100;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        targetZoom = cam.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        float scrollData;
        scrollData = Input.GetAxis("Mouse ScrollWheel");

        targetZoom += scrollData * zoomFactor;
        targetZoom = Mathf.Clamp(targetZoom, 40f, 400f);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * zoomLerpSpeed);


    }
}
