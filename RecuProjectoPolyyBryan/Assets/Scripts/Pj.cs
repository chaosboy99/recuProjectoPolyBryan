using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pj : MonoBehaviour
{
    [SerializeField] private float Xinicial, Yinicial;
    [SerializeField] private float Speed, Jump;
    public SpriteRenderer Sprite;
    [SerializeField] private Animator Animator;

    private bool atacando = false;
    Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Xinicial = transform.position.x;
        Yinicial = transform.position.y;
    }
    private void FixedUpdate()
    {
        if (Input.GetKey("e") && !atacando)
        {

            atacando = true;
            Animator.SetBool("Ataque", true);

        }
        else
        {
            atacando = false;
            Animator.SetBool("Ataque", false);
        }

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2D.velocity = new Vector2(Speed, rb2D.velocity.y);
            Sprite.flipX = false;
            Animator.SetBool("Correr", true);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.velocity = new Vector2(-Speed, rb2D.velocity.y);
            Sprite.flipX = true;
            Animator.SetBool("Correr", true);
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            Animator.SetBool("Correr", false);
        }

        if ((Input.GetKey("space") || Input.GetKey("w")) && Suelo.EsSuelo)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, Jump);
            Animator.SetBool("Correr", false);
        }
        if (Suelo.EsSuelo == false)
        {
            Animator.SetBool("Salto", true);
            Animator.SetBool("Correr", false);
        }
        if (Suelo.EsSuelo == true)
        {
            Animator.SetBool("Salto", false);
        }
    }

    public void Spawn()
    {
        transform.position = new Vector3(Xinicial, Yinicial, 0);
    }
}
