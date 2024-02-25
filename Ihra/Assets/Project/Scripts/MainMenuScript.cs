using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject         mainMenu;
    [SerializeField] private GameObject         levels;
    [SerializeField] private TextMeshProUGUI    highScore;
    [SerializeField] private Slider             sensitivitySlider;
    [SerializeField] private TMP_Text           sensitivityText;

    private void Start()
    {
        highScore.text = "high score: " + PlayerPrefs.GetInt("highScore", 0).ToString();
        mainMenu.SetActive(true);

        levels.SetActive(false);
        sensitivitySlider.value = PlayerPrefs.GetFloat(StaticClass.SensitivityKey, 1);
        sensitivityText.text = "Sensitivity: " + sensitivitySlider.value.ToString("0.00");
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

    public void OnSliderValueChanged(float value)
    {
        PlayerPrefs.SetFloat(StaticClass.SensitivityKey, value);
        sensitivityText.text = "Sensitivity: " + sensitivitySlider.value.ToString("0.00");
    }

    public void StartLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
}
