using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorBehaviour : MonoBehaviour
{
    
    [SerializeField]
    private float speed;
    [SerializeField]
    private bool isVertical;
    [SerializeField]
    private bool needsAwaking = false;
    private bool isAwake = true;
    [SerializeField]
    [Range(-1,1)]
    private int direction = 1;
    [SerializeField]
    private Transform transform;
    [SerializeField]
    private Transform positiveLimit;
    [SerializeField]
    private Transform negativeLimit;
    private Transform choosenLimit;

    // Start is called before the first frame update
    void Start()
    {
        choosenLimit = positiveLimit;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!needsAwaking || isAwake)
        {
            if (Vector2.Distance(transform.position, choosenLimit.position) <= 1)
            {
                ChangeDirection();
            }
            Move();
        }
    }

    void Move()
    {
        float velocity = direction * speed * Time.deltaTime;
        if (!isVertical)
        {
            transform.position += new Vector3(velocity,0,0);
            //newPosition.x += velocity;
        }
        else
        {
            transform.position += new Vector3(0, velocity, 0);
            //newPosition.y += velocity;

        }
    }
    void ChangeLimit()
    {
        choosenLimit = (choosenLimit == positiveLimit) ? negativeLimit : positiveLimit;
    }
    void ChangeDirection()
    {
        direction = -direction;
        ChangeLimit();
    }
    
}
