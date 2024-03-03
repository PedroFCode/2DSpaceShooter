using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LvlManager : MonoBehaviour
{
  
    public void LoadMenu(){
      SceneManager.LoadSceneAsync("MainMenu");
    }

    public void LoadTutorial(){
      SceneManager.LoadSceneAsync("Tutorial");
    }

    public void LoadLevel1(){
      SceneManager.LoadSceneAsync("Level_1");
    }

    public void LoadLevel2(){
      SceneManager.LoadSceneAsync("Level_2");
    }

    public void LoadLevel3(){
      SceneManager.LoadSceneAsync("Level_3");
    }

    public void LoadEndlessMode(){
      SceneManager.LoadSceneAsync("Endless");
    }

    public void LoadDeathScreen(){
      SceneManager.LoadSceneAsync("DeathScreen");
    }

    public void LoadWinScreen(){
      SceneManager.LoadSceneAsync("WinScreen");
    }

    public void LoadInfo(){
      SceneManager.LoadSceneAsync("Info");
    }

    public void Exit(){
      Application.Quit();
    }


}
