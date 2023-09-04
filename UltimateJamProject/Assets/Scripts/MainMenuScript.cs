using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void NormalTime()
    {
        //SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        GlobalValues.Instance.NormalTime = false;
        Time.timeScale = 1f;
    }

    public void GoToLevel2()
    {
        SceneManager.LoadScene(2);
    }

    public void GoToLevel3()
    {
        SceneManager.LoadScene(3);
    }
}
