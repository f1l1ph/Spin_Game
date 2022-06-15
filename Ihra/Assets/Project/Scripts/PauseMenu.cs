using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pauseMenu;

    private void Start()
    {
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
    }


    void Update()
    {
        if(StaticClass.isDeath == true)
        {
            pauseButton.SetActive(false);
        }
    }

    public void OnPause()
    {
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        StaticClass.pausedGame = true;
    }

    public void OnResume()
    {
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
        StaticClass.pausedGame = false;
    }

    public void OnRestart()
    {
        Time.timeScale = 1f;
        StaticClass.pausedGame = false;
        StaticClass.score = 0;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void OnMainMenu()
    {
        Time.timeScale = 1f;
        StaticClass.pausedGame = false;
        StaticClass.score = 0;
        SceneManager.LoadScene(0);
    }
}
