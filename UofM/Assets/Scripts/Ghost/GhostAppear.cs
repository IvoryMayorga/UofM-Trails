using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAppear : MonoBehaviour
{
    public Color newColor;
    private SpriteRenderer rend;
    public GameObject Object;
    
    


    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            Object = GetComponent<GameObject>();
           

                 rend = GetComponent<SpriteRenderer>();
                 rend.color = newColor;
           
            
            
                        
        }
    }
}
