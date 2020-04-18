using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SetUIManager : MonoBehaviour
{
    public float timeInGame;
    [HideInInspector]public int level;
    public static int round =0 ;
    [Header("Text")]
    public Text timeText;
    public Text scoreText;
    public static int totalScore ;
    public Text winScore;
    public Text loseScore;
    public Text roundText;
    [Header("Panel")]
    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject controllerPanel;
    [Header("Object")]
    public GameObject mag;
    public GameObject spawn;
    public GameObject player;
    [Header("Button")]
    public Button continueTab;
    public Button loseTab;
   
    void Awake()
    {
        round += 1;
        level = round;
        Debug.Log("Level: " + level);
    }
    void Start()
    {
        controllerPanel.SetActive(true);
        mag.SetActive(true);
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        spawn.SetActive(true);
        player.SetActive(true);
        continueTab.onClick.AddListener(() => NextLevel());
        loseTab.onClick.AddListener(() => LoadingScene());
   
    }

  
    // Update is called once per frame
    void Update()
    {
        timeInGame -= Time.deltaTime;
        
        if(timeInGame < 0)
        {
            timeInGame = 0;
        }
        SetUIFinishGame();
        UpdateTime();
        UpdateScore();
        UpdateResultScore();
        UpdateRound();
        Quit();
    }
    void UpdateTime()
    {
        timeText.text = "Time: "+timeInGame.ToString("0") + " Remaining";
    }
    void UpdateScore()
    {
        scoreText.text = "Score: "+totalScore.ToString() + " Point";
    }
    void UpdateResultScore()
    {
        winScore.text = "You Got Score: " + totalScore.ToString() + " Point";
        loseScore.text = "You Got Score: " + totalScore.ToString() + " Point";
    }
    void UpdateRound()
    {
        roundText.text = "Stage " + round.ToString();
    }
    void SetUIFinishGame()
    {
        if (timeInGame == 0)
        {
            if (totalScore >= 1200 && round == 1 || round == 2 && totalScore >= 4100 || round == 3 && totalScore >= 6000)
            {
                winPanel.SetActive(true);
                losePanel.SetActive(false);
                controllerPanel.SetActive(false);
                mag.SetActive(false);
                spawn.SetActive(false);
                player.SetActive(false);
              
            }
            else if(round ==1 &&totalScore < 1200 || round ==2 &&totalScore<4100 || round == 3 && totalScore < 6000)
            {
                losePanel.SetActive(true);
                winPanel.SetActive(false);
                controllerPanel.SetActive(false);
                mag.SetActive(false);
                spawn.SetActive(false);
                player.SetActive(false);
            }
        }
    }
     void NextLevel()
    {
        if(round >=2)
        {
            Debug.Log("You Stay On High Level.");
            round = 0;
            totalScore = 0;
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
    void LoadingScene()
    {
        round = 0;
        SceneManager.LoadScene(0);
        totalScore = 0;
    }
    void Quit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
