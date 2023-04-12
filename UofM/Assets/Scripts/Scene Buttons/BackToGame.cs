using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToGame : MonoBehaviour
{
    private int sceneToContinue;
    public void ContinueGame()
    {
        sceneToContinue = PlayerPrefs.GetInt("SavedScene");
        if (sceneToContinue != 2)
            SceneManager.LoadScene(sceneToContinue);
        else
            return;
    }
}
