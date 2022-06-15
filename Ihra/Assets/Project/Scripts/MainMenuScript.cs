using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject         mainMenu;
    [SerializeField] private GameObject         levels;
    [SerializeField] private TextMeshProUGUI    highScore;

    private void Start()
    {
        highScore.text = "high score: " + PlayerPrefs.GetInt("highScore", 0).ToString();
        mainMenu.SetActive(true);

        levels.SetActive(false);
    }

    //Main menu stuff
    public void OnPlay()
    {
        levels.SetActive(true);

        mainMenu.SetActive(false);
    }

    public void OnExit()
    {
        Application.Quit();
    }

    //Other stuff
    public void OnBack()
    {
        mainMenu.SetActive(true);

        levels.SetActive(false);
    }

    public void StartLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
}
