using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject         options;
    [SerializeField] private GameObject         mainMenu;
    [SerializeField] private GameObject         levels;
    [SerializeField] private GameObject         aboutGame;
    [SerializeField] private Text               highScore;

    private void Start()
    {
        highScore.text = "high score: " + PlayerPrefs.GetInt("highScore", 0).ToString();
        mainMenu.SetActive(true);

        options.SetActive(false);
        levels.SetActive(false);
        aboutGame.SetActive(false);
    }

    //Main menu stuff
    public void OnPlay()
    {
        levels.SetActive(true);

        mainMenu.SetActive(false);
        options.SetActive(false);
        aboutGame.SetActive(false);
    }

    public void OnOptions()
    {
        options.SetActive(true);

        mainMenu.SetActive(false);
        levels.SetActive(false);
        aboutGame.SetActive(false);
    }
    public void OnExit()
    {
        Application.Quit();
    }
    public void OnAboutUs()
    {
        aboutGame.SetActive(true);

        mainMenu.SetActive(false);
        levels.SetActive(false);
        options.SetActive(false);
    }

    //Other stuff
    public void OnBack()
    {
        mainMenu.SetActive(true);

        options.SetActive(false);
        levels.SetActive(false);
        aboutGame.SetActive(false);
    }

    public void StartLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
}
