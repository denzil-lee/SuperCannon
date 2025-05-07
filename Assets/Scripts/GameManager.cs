using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{

    //public static GameManager myGameManager;
    [SerializeField] Text playerScoreText;
    [SerializeField] Text playerHealthText;
    [SerializeField] int startHealth=100;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);
        
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void OnEnemyDie(int hitpoints)
    {

        GameData.Score += hitpoints;
        DisplayScore();
    }

    public void DisplayScore()
    {
        playerScoreText.text = "Score: " + GameData.Score.ToString();
        SaveLoadManager.Instance.SaveData();
    }

    public void OnEnemyWins()
    {

        
        DisplayHealth();
        if (GameData.PlayerHealth <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }

    public void DisplayHealth()
    {
        playerHealthText.text = "Health: " + GameData.PlayerHealth.ToString();
    }



    // Start is called before the first frame update
    void Start()
    {
        GameData.Score = 0;
        GameData.PlayerHealth = startHealth;
        SaveLoadManager.Instance.LoadData();
        DisplayScore();
        DisplayHealth();

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "LoseScene")
        {
            // Playerprefs example....  PlayerPrefs.SetInt("score", GameData.Score);
            EnemySpawner myEnemySpawner = GetComponent<EnemySpawner>();
            Destroy(myEnemySpawner);
        }
        
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
    }


}
