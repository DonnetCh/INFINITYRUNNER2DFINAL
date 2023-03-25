using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject spawnPointEnemy;
    public GameObject spawnPointCoin;
    public GameObject spawnPointObstacle;
    public GameObject spawnPointBackground;
    public float timer1;
    public float timer2;
    public float timer3;
    public float timer4;
    public float timeBetweenSpawnsEnemy;
    public float timeBetweenSpawnsCoins;
    public float timeBetweenSpawnsBackground;
    public float timeBetweenSpawnsObstacle;
    public GameObject spawnEnemy;
    public GameObject spawnCoin;
    public GameObject spawnBackground;
    public GameObject spawnObstacle;
    public float speedMultiplier;
    public TextMeshProUGUI distanceUI;
    private float distance;
    public int Score = 0;
    public int CurrentScore;
    public TextMeshProUGUI currentscoretxt;
    public TextMeshProUGUI highscoretxt;
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        Score = PlayerPrefs.GetInt("Score", CurrentScore);
        highscoretxt.text = "HighScore:" + PlayerPrefs.GetInt("Score").ToString();
        PlayerPrefs.SetInt("Score", 0);
    }
    private void Awake()
    {

        Score = PlayerPrefs.GetInt("Score", 0);
    }
    // Update is called once per frame
    void Update()
    {
        currentscoretxt.text = "Score:" + CurrentScore.ToString();
       // Score = (int)Score;
       highscoretxt.text = "HighScore:" + Score.ToString();
        speedMultiplier += Time.deltaTime * 0.01f;
        timer1 += Time.deltaTime;
        timer2 += Time.deltaTime;
        timer3 += Time.deltaTime;
        timer4 += Time.deltaTime;
        
        distanceUI.text = "    Distance:" + distance.ToString("F2");
        distance += Time.deltaTime * 0.5f;
        
        if (CurrentScore > PlayerPrefs.GetInt("Score", 0))
        {
            PlayerPrefs.SetInt("Score", CurrentScore);
            highscoretxt.text = Score.ToString();
        }

        if (timer1 > timeBetweenSpawnsEnemy)
        {
            timer1 = 0;
            Instantiate(spawnEnemy, spawnPointEnemy.transform.position, Quaternion.identity);
        }
        if (timer2 > timeBetweenSpawnsCoins)
        {
            timer2 = 0;
            Instantiate(spawnCoin, spawnPointCoin.transform.position, Quaternion.identity);
        }
        if (timer3 > timeBetweenSpawnsBackground)
        {
            timer3 = 0;
            Instantiate(spawnBackground, spawnPointBackground.transform.position, Quaternion.identity);
        }
        if (timer4 > timeBetweenSpawnsObstacle)
        {
            timer4 = 0;
            Instantiate(spawnObstacle, spawnPointObstacle.transform.position, Quaternion.identity);
        }
    }
   
    public void BorrarDatos()
    {
        PlayerPrefs.DeleteKey("Score");
        highscoretxt.text = "0";
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
    }

    public void VolverAlMenu()
    {
        SceneManager.LoadScene(1);
    }
}
