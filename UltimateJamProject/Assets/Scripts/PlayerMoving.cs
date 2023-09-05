using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //------- Функция/метод, выполняемая каждый кадр в игре ---------
    void Update()
    {
        Walk();
        Jump();
        Reflect();
        CheckingGround();
    }

    //------- Функция/метод для перемещения персонажа по горизонтали ---------
    public float speed = 2f;
    public Vector2 moveVector;

    void Walk()
    {
        moveVector.x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
        if (onGround && rb.velocity.magnitude > 0) SoundManager.Instance.PlaySound(SoundManager.Sound.PlayerWalk, transform.position, .5f);
    }

    public int jumpForce = 10;

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            SoundManager.Instance.PlaySound(SoundManager.Sound.PlayerJump, transform.position);
        }
    }

    public bool faceRight = true;

    void Reflect()
    {
        if ((moveVector.x > 0 && !faceRight) || (moveVector.x < 0 && faceRight))
        {
            transform.localScale *= new Vector2(-1, 1);
            faceRight = !faceRight;
        }
    }

    public bool onGround;
    public LayerMask Ground;
    public Transform GroundCheck;
    public float CheckRadius = 0.5f;

    void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, CheckRadius, Ground);

    }
}