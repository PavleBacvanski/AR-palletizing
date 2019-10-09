using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

   public void StartApp()
    {
        SceneManager.LoadScene("MunchSCENA");
    }
    public void StartRandomMode()
    {
        SceneManager.LoadScene("RandomModeSCENA");
    }
}
