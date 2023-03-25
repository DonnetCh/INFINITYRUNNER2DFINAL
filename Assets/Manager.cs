using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Manager : MonoBehaviour
{
    public GameObject spawnPointEnemy;
    public GameObject spawnPointCoin;
    public GameObject spawnPointBackground;
    public float timer;
    public float timeBetweenSpawns;
    public GameObject spawnEnemy;
    public GameObject spawnCoin;
    public GameObject spawnBackground;
    public float speedMultiplier;
    public TextMeshProUGUI distanceUI;
    private float distance;
    public float score;
    public int highscore;
    public TextMeshProUGUI highscoretxt;
    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("Score", highscore);
        highscoretxt.text = "HighScore:" + PlayerPrefs.GetInt("Score").ToString();

    }
    private void Awake()
    {

        highscore = PlayerPrefs.GetInt("Score", 0);
    }
    // Update is called once per frame
    void Update()
    {
        highscore = (int)score;
        highscoretxt.text = "HighScore:" + highscore.ToString("F1");
        speedMultiplier += Time.deltaTime * 0.01f;
        timer += Time.deltaTime;
        score += Time.deltaTime;
        distanceUI.text = "    Distance:" + distance.ToString("F2");
        distance += Time.deltaTime * 0.5f;

        if (highscore > PlayerPrefs.GetInt("Score", 0))
        {
            PlayerPrefs.SetInt("Score", highscore);
            highscoretxt.text = highscore.ToString();
        }

        if (timer > timeBetweenSpawns)
        {
            timer = 0;

            Instantiate(spawnEnemy, spawnPointEnemy.transform.position, Quaternion.identity);
            Instantiate(spawnCoin, spawnPointCoin.transform.position, Quaternion.identity);
            Instantiate(spawnBackground, spawnPointBackground.transform.position, Quaternion.identity);

        }
    }

}
