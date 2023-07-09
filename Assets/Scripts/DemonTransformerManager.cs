using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemonTransformerManager : MonoBehaviour
{
    [SerializeField]
    [Range(5,10)]
    private int amountNeeded=5;
    private int amountCollected;
    [SerializeField]
    private CounterBehaviour cb;
    [SerializeField]
    private Text itensCollected;
    [SerializeField]
    private Transform collectablesParent;
    [SerializeField]
    private GameObject collectables;
    

    // Start is called before the first frame update
    void Start()
    {
        amountCollected = 0;
    }

    // Update is called once per frame


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Transformer"))
        {
            amountCollected++;
            itensCollected.text = "Itens: " + amountCollected.ToString("0");
            Debug.Log(amountCollected);
            Destroy(collision.gameObject);
            if(CheckIfEnough())
            {
                cb.StartTimer();
            }
        }
    }
    private bool CheckIfEnough()
    {
        return amountCollected >= amountNeeded;
    }

    public void ResetAmountCollected()
    {
        amountCollected = 0;
        itensCollected.text = "Itens: " + amountCollected.ToString("0");
        StartCoroutine(SpawnItensAgain());
    }

    IEnumerator SpawnItensAgain(){
        
        yield return new WaitForSeconds(5);
        if(GameObject.Find("Collectables")){
            Destroy(GameObject.Find("Collectables"));
        }
        Instantiate(collectables,collectablesParent);
    }
}
