using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayBTN()
    {
        SceneManager.LoadScene(1);
    }   
    
    public void SettingsBTN()
    {
        //open a new panel for settings
    }

    public void QuitBTN()
    {
        Application.Quit();
    }
}
