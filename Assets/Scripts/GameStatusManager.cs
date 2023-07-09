using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStatusManager : MonoBehaviour
{
    [SerializeField]
    private Text winner;
    [SerializeField]
    private GameObject  restartButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StateWinner(int player){
        if( winner.text  == ""){
            winner.text =  (player == 0) ?  "BEAST WINS" : "HUNTER WINS";
        restartButton.SetActive(true);
        }
    }

    public void RestartGame(){
        Debug.Log("Eu rodo");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
