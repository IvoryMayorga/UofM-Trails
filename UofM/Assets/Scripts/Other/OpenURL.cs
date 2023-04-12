using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenURL : MonoBehaviour
{
    public void MapURL(string link)
    {
        Application.OpenURL(link);
    }
}
