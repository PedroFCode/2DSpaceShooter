using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI highScoreText;
    private int score = 0;
    public int lives = 3;
    private int highScore = 0; 

    public AudioSource audioSource;
    public AudioClip hit;


    private Scene activeScene;
    void Start(){
        activeScene = SceneManager.GetActiveScene();
        score = PlayerPrefs.GetInt("Score", 0);
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        scoreText.text = "Score: " + score.ToString();
        highScoreText.text = "HighScore: " + highScore.ToString();

        audioSource = GetComponent<AudioSource>();
        
    }

    void OnDisable(){
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("HighScore", highScore);
    }
   
    
    public void UpdateScorePoints(int scoreValue){

        Debug.Log("Score Value: " + scoreValue);
        score += scoreValue;
        scoreText.text = "Score: " + score.ToString();
        Debug.Log("Score " + score);

        if(activeScene.name == "Tutorial" && score >= 250){
            FindObjectOfType<LvlManager>().LoadLevel1();
           // SceneManager.LoadSceneAsync("Level_1");
        }

        if(activeScene.name == "Level_1" && score >= 1000){
            FindObjectOfType<LvlManager>().LoadLevel2(); 
        }

        if(activeScene.name == "Level_2" && score >= 2500){
            FindObjectOfType<LvlManager>().LoadLevel3(); 
        }

        if(activeScene.name == "Level_3" && score >= 5000){
           FindObjectOfType<LvlManager>().LoadWinScreen(); 
           score = 0;
           Debug.Log("You Win!");
        }

        if(activeScene.name == "Endless" && score > highScore){
           highScore = score;
           highScoreText.text = "New Highscore: " + highScore.ToString();
           Debug.Log("New HighScore!");
        }

        
    }

    public void loseALife(){
        if(lives > 1){
            lives -= 1;
            Debug.Log("Lives " + lives);
            livesText.text = "Lives: " + lives.ToString();
            PlayHitSound();
        }
        else if(lives <= 1){
            FindObjectOfType<LvlManager>().LoadDeathScreen();
            score = 0;
        }
    }

    public void gainALife(){
        if(lives < 3){
            lives += 1;
            livesText.text = "Lives: " + lives.ToString();
            Debug.Log("Lives " + lives);
        }
    }

    void PlayHitSound() {
        audioSource.PlayOneShot(hit);
    }

}
