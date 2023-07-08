using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonTransformerManager : MonoBehaviour
{
    [SerializeField]
    [Range(5,10)]
    private int amountNeeded=5;
    private int amountCollected;
    [SerializeField]
    private CounterBehaviour cb;

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
    }
}
