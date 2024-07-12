using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovEnemigo : MonoBehaviour
{
    public SpriteRenderer Sprite;
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform CurrentPoint;
    public float speed;

    void Start ()
    {
        rb  = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        CurrentPoint = pointB.transform;
    }
    void Update ()
    {
        Vector2 point = CurrentPoint.position - transform.position;
        if(CurrentPoint == pointA.transform)
        {
            rb.velocity = new Vector2(speed, 0); 
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        if(Vector2. Distance(transform.position, CurrentPoint.position) < 0.5f && CurrentPoint == pointB.transform)
        {
            CurrentPoint = pointA.transform;
            Sprite.flipX = false;
        }
        if(Vector2. Distance(transform.position, CurrentPoint.position) < 0.5f && CurrentPoint == pointA.transform)
        {
            Sprite.flipX = true;
            CurrentPoint = pointB.transform;
        }
    }

   
}
