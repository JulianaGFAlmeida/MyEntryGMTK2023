using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatusManager : MonoBehaviour
{
    [SerializeField]
    private Text winner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StateWinner(int player){
        winner.text =  (player == 0) ?  "BEAST WINS" : "HUNTER WINS";
    }
}
