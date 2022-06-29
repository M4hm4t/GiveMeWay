using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    //private Text CurrentLevelText;
   //private Text NextLevelText;
    //private Image fill;
   // private int level;
   // private float startDistance, currentDistance;
    private GameObject player, finish;
    public GameObject swipeHand;
    
    private TextMesh startText;
    
    public static GameManager instance;
    [SerializeField] private Canvas gameOverCanvas;
    //public GameObject[] levels;
    [SerializeField] private Text gameOverText;




    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }

        //CurrentLevelText = GameObject.Find("CurrentLevelText").GetComponent<Text>();
       // NextLevelText = GameObject.Find("NextLevelText").GetComponent<Text>();

       // fill = GameObject.Find("Fill").GetComponent<Image>();

        player = GameObject.Find("Player");
        finish = GameObject.Find("Finish");
        swipeHand = GameObject.Find("Swipe");
        startText = GameObject.Find("StartText").GetComponent<TextMesh>();

    }

    public void RemoveUI()
    {
        swipeHand.SetActive(false);
    }

    public void GameOver()
    {
        gameOverCanvas.enabled = true;
    }
    public void GameOverText(string gameOverInfo)
    {
        gameOverText.text = gameOverInfo;

    }
   
    public void RestartGame()
    {

        //foreach (GameObject level in levels)
        //{
        //   levels.DontDestroyOnLoad();
        //}
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
