using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    
    private int health;
    [SerializeField]
    private int numOfShips;

    public Image[] ships;
    public Sprite fullShip;
    public Sprite emptyShip;

    void Start(){
        //health = FindObjectOfType<GameController>().lives;
    }
    void Update(){
        health = FindObjectOfType<GameController>().lives;
      //  Debug.Log("health" + health);
        if (health > numOfShips){
            health = numOfShips;
        }

        for(int i = 0; i < ships.Length; i++){

            if(i < health){
                ships[i].sprite = fullShip;
            } else {
                ships[i].sprite = emptyShip;
            }

            if(i < numOfShips){
                ships[i].enabled = true;
            } else{
                ships[i].enabled = false;
            }
        }
    }
}
