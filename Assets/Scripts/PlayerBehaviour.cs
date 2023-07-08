using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    [Range(0f,20f)]
    private float moveSpeed = 5f;
    [SerializeField]
    [Range(0f, 20f)]
    private float jumpForce = 5f;
    [SerializeField]
    private string horizontalAxis = "Horizontal";
    [SerializeField]
    private string jumpButton = "Jump";
    [SerializeField]
    private bool amITheKiller=false;
    private bool isJumping = false; 
    
    [SerializeField]
    private LayerMask worldLayer;

    private Rigidbody2D rb;
    private bool isFacingRight = true;
    private Vector3 positionBeforeJumping;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        positionBeforeJumping = this.gameObject.transform.position;
    }
    private void Update() {

        if (Input.GetButtonDown(jumpButton) && !isJumping)
        {
            Jump();
        }
        
        
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis(horizontalAxis) * moveSpeed;


        rb.velocity = new Vector2(moveHorizontal, rb.velocity.y);

        if ((moveHorizontal > 0 && !isFacingRight) || (moveHorizontal < 0 && isFacingRight))
        {
            Flip();
        }

    

    }

    private void Jump()
    {

        positionBeforeJumping = this.gameObject.transform.position;
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        isJumping = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = false;
        }
        else if (amITheKiller && collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        } if (collision.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(collision.gameObject.transform,true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.parent = null;
        }
    
    }
        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            this.transform.position = positionBeforeJumping;
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void DemonBuff()
    {
        SetAmITheKiller(true);
        moveSpeed *= 1.5f;
        jumpForce *= 1.25f;
    }

    public void BackToNormal()
    {
        SetAmITheKiller(false);
        moveSpeed /= 1.5f;
        jumpForce /= 1.25f;

    }

    public void SetAmITheKiller(bool amI)
    {
        amITheKiller = amI;
    }
}
