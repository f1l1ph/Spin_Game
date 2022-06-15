using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject         player;
    [SerializeField] private GameObject[]       block;
    [SerializeField] private Text               scoreTxT;
    [SerializeField] private GameObject         deathMenu;
    [SerializeField] private Text               highScore;
    [SerializeField] private GameObject         randomObject;

    [SerializeField] private float              rotational_Speed;
    [SerializeField] private float              timeRemaining;
    private float timeLeft;

    private float timeR1 = 10f;
    private float timeLeft2;

    private int turn_Value = 0;

    private void Start()
    {
        timeLeft    = timeRemaining;
        timeLeft2   = timeR1;

        Instantiate(randomObject, new Vector3(-9f ,Random.Range(-3f,3f), 0f), Quaternion.identity);
    }

    void Update()
    {
        if(StaticClass.score >= PlayerPrefs.GetInt("highScore", 0))
        {
            PlayerPrefs.SetInt("highScore", StaticClass.score);
        }


        if (timeLeft2 > 0)
        {
            timeLeft2 -= Time.deltaTime;
        }
        else if (timeLeft2 <= 0)
        {
            timeLeft2 = timeR1;
            Instantiate(randomObject, new Vector3(-9f, Random.Range(-3f, 3f), 0f), Quaternion.identity);
        }

        SpawnBlocks();

        scoreTxT.text = "score: " + StaticClass.score.ToString();//updating score

        //Steer();
        float toRotate = rotational_Speed * Time.deltaTime * turn_Value;
        player.transform.RotateAround(this.transform.position, Vector3.forward, toRotate);


        if (StaticClass.isDeath == false)
        {
            deathMenu.SetActive(false);
        }

        if (StaticClass.isDeath == true)
        {
            OnDie();
        }
        
        else if (Input.GetKeyDown(KeyCode.Escape) && StaticClass.pausedGame == true && StaticClass.isDeath == false)
        {
            OnResume();
        }
    }

    private void SpawnBlocks()
    {
        if (StaticClass.pausedGame == false)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
            }
            else if (timeLeft <= 0)
            {
                timeLeft = timeRemaining;
                Instantiate(block[Random.Range(0,block.Length)]);
            }
        }
    }
    
    public void Turn(int value)
    {
        turn_Value = value;
    }

    void OnDie()
    {
        deathMenu.SetActive(true);
        StaticClass.score = 0;
    }

    //button functions
    public void OnRestart()
    {
        StaticClass.isDeath     = false;
        Time.timeScale          = 1f;
        StaticClass.pausedGame  = false;
        StaticClass.score       = 0;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    public void OnMainMenu()
    {
        StaticClass.isDeath     = false;
        Time.timeScale          = 1f;
        StaticClass.pausedGame  = false;
        SceneManager.LoadScene(0);
    }
    public void OnExitToDesktop()
    {
        Application.Quit();
    }
    public void OnResume()
    {
        Time.timeScale = 1f;
        StaticClass.pausedGame = false;
    }
}
