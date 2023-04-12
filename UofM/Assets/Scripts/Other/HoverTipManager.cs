using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HoverTipManager : MonoBehaviour
{
    
  public GameObject BuildingText;

    //// Start is called before the first frame update
    public void Start()
    {
        BuildingText.SetActive(false);
       
    }

    public void OnMouseOver()
    {
        BuildingText.SetActive(true);
    }

    public void OnMouseExit()
    {
        BuildingText.SetActive(false);
    }






  








}
