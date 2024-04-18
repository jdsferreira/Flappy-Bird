using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> obstaclePrefabs;
    public static  GameManager Instance{get; private set;}
    public float obstacleInterval = 1;

    public float obstacleSpeed = 10;

    public float obstacleOffsetX = 0;
    public Vector2 obstacleOffsertY = new Vector2(0, 0);

    [HideInInspector]
    public int score = 0;

    private bool isGameOver = false;

    public Text scoreText;


    void Awake(){
        if(Instance != null && Instance != this){
            Destroy(this);
        } else{
            Instance = this;
        }
    }

    public bool IsGameOver(){
        return isGameOver;
    }

    public bool IsGameActive(){
        return !isGameOver;
    }
   
   public void EndGame(){
    isGameOver = true;
    scoreText.text = "GAME OVER";
    Debug.Log("GAME OVER !!!");
    StartCoroutine(ReloadScene(2));
    
   }

   private IEnumerator ReloadScene(float delay){
    //Wait the delay
    yield return new WaitForSeconds(delay);

    //Reload the scene
    scoreText.gameObject.SetActive(false);
    string sceneName = SceneManager.GetActiveScene().name;
    SceneManager.LoadScene(sceneName);

   }
    
}
