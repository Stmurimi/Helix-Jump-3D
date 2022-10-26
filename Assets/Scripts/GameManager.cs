using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool levelComplete;
    public static bool mute = false;
    public static bool isGameStarted;
    public GameObject gameOverPanel;
    public GameObject levelCompletedPanel;
    public GameObject gamePlayPanel;
    public GameObject startMenuPanel;
    public GameObject header;

    public static int currentLevelIndex;
    public Slider gameProgressSlider;
    public TextMeshProUGUI currentLevelText;
    public TextMeshProUGUI nextLevelText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    public static int noOfPassedRings;
    public static int score = 0;
    
    

    private void Awake()
    {
        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        noOfPassedRings = 0;
        Time.timeScale = 1;
        isGameStarted = gameOver = levelComplete = false;
        header.SetActive(false);
        highScoreText.text = "Best Score\n" + PlayerPrefs.GetInt("High Score", 0);
       
    }

    // Update is called once per frame
    void Update()
    {
        //Update UI
        currentLevelText.text = currentLevelIndex.ToString();
        nextLevelText.text = (currentLevelIndex+1).ToString();

        int progress = noOfPassedRings * 100 / FindObjectOfType<HelixManager>().noOfRings;
        gameProgressSlider.value = progress;

        scoreText.text = score.ToString();

        //Start level
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !isGameStarted)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                return;
            else

            isGameStarted = true;
            gamePlayPanel.SetActive(true);
            startMenuPanel.SetActive(false);
            header.SetActive(false);
        }

        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            header.SetActive(true);

            if (Input.GetButtonDown("Fire1"))
            {
                if(score > PlayerPrefs.GetInt("High Score", 0))
                {
                    PlayerPrefs.SetInt("High Score", score);
                }
                score = 0;
                SceneManager.LoadScene(0);
                header.SetActive(false);
            }
        }

        if (levelComplete)
        {
            Time.timeScale = 0;
            levelCompletedPanel.SetActive(true);

            if (Input.GetButtonDown("Fire1"))
            {
                PlayerPrefs.SetInt("CurrentLevelIndex", currentLevelIndex + 1);
                SceneManager.LoadScene(0);
            }
        }
    }
}
