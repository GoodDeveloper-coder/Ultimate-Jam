using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalValues : Singleton<GlobalValues>
{
    public int PlayerLives = 3;

    public GameObject HP1;
    public GameObject HP2;
    public GameObject HP3;
    public GameObject HP4;

    public GameObject deathMenu;
    public GameObject failMenu;
    public GameObject winMenu;
    public GameObject finishMenu;

    public Animator anim;

    public bool NormalTime = true;

    public bool water;

    //public Animator anim2;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerLives == 2)
        {
            HP1.SetActive(false);
            Debug.Log("2");
        }

        if (PlayerLives == 1)
        {
            HP1.SetActive(false);
            HP2.SetActive(false);
            Debug.Log("1");
        }

        if (PlayerLives == 0)
        {
            HP3.SetActive(false);
            Debug.Log("You Lose");
            if (NormalTime)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
            //Time.timeScale = 0f;
            deathMenu.SetActive(true);
            pauseBTN.gameObject.SetActive(false);
            //anim2.Play("UltimateDeathPlayerAnim");
            SoundManager.Instance.PlaySound(SoundManager.Sound.FailLevel, transform.position);
        }
    }

    public void CameraShake()
    {
        anim.SetTrigger("Shake");
    }
    public void FinishLevel()
    {
        if (water)
        {
            if (SceneManager.sceneCountInBuildSettings - 1 > SceneManager.GetActiveScene().buildIndex)
                winMenu.SetActive(true);
            else
                finishMenu.SetActive(true);
            SoundManager.Instance.PlaySound(SoundManager.Sound.FinishLevel, transform.position);
        }
        else
        {
            failMenu.SetActive(true);
            SoundManager.Instance.PlaySound(SoundManager.Sound.FailLevel, transform.position);
        }
        pauseBTN.gameObject.SetActive(false);
    }

    #region Pause MENU

    public GameObject pauseMenu;
    public GameObject pauseBTN;
    public MainMenuScript mainMenu;

    public void PauseGame()
    {
        if(pauseMenu.gameObject.activeInHierarchy == false)
        {
            pauseMenu.gameObject.SetActive(true);
            pauseBTN.gameObject.SetActive(false);
            Time.timeScale = 0f;
        }
    }

    public void ResumeGame()
    {
        if (pauseMenu.gameObject.activeInHierarchy == true)
        {
            pauseMenu.gameObject.SetActive(false);
            pauseBTN.gameObject.SetActive(true);
            Time.timeScale = 1f;
        }
    }

    public void RetryGame()
    {
        mainMenu = GameObject.Find("Canvas").GetComponent<MainMenuScript>();
        mainMenu.PlayAgain();
    }
    public void MainMenu()
    {
        mainMenu = GameObject.Find("Canvas").GetComponent<MainMenuScript>();
        mainMenu.GoToMenu();
    }

#endregion
}
