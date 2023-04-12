using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;
    private Vector3 origin;
   
    [SerializeField]
    private SpriteRenderer mapRend;
    private float mapMinX, mapMaxX, mapMinY, mapMaxY;


    private void Update()
    {
        PanCamera();
       
    }

    private void PanCamera()
    {
        if (Input.GetMouseButtonDown(0))
            origin = mainCamera.ScreenToWorldPoint(Input.mousePosition);
       

        if (Input.GetMouseButton(0))
        {
            Vector3 difference = origin - mainCamera.ScreenToWorldPoint(Input.mousePosition);
 
            print("origin " + origin + " newPosition " + mainCamera.ScreenToWorldPoint(Input.mousePosition) + "differnce"+ difference);
           
            mainCamera.transform.position = ClampCamera(mainCamera.transform.position + difference);
           
        }

    }

   
    private Vector3 ClampCamera(Vector3 targetpos)
    {
        float height = mainCamera.orthographicSize;
        float width = height * mainCamera.aspect;

        float minX = mapMinX + width;
        float maxX = mapMaxX- width;

        float minY = mapMinY+ height;
        float maxY = mapMaxY- height;
        float newX = Mathf.Clamp(targetpos.x,minX,maxX);
        float newY = Mathf.Clamp(targetpos.y, minY, maxY);
        return new Vector3(newX, newY, targetpos.z);
    }
    private void Awake()
    {
        
        mapMinX = mapRend.transform.position.x - mapRend.bounds.size.x/ 2f;
        mapMaxX = mapRend.transform.position.x + mapRend.bounds.size.x / 2f;
        mapMinY = mapRend.transform.position.y - mapRend.bounds.size.y / 2f;
        mapMaxY = mapRend.transform.position.y + mapRend.bounds.size.y / 2f;



    }
}
