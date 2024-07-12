using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float vida;
    public Vida loseHearts;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void RecibirDa�o(float da�o)
    {
        vida -= da�o;
        Debug.Log("Da�o");
        if (vida <= 0)
        {
            muerte();
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pj"))
        {
            loseHearts.PerderCorazones();
        }
    }
    
    private void muerte()
    {
        animator.SetBool("Muerte", true);
        Debug.Log("Muerto");
    }
    private void DestruirEnemigo()
    {
        Destroy(gameObject);
    }
}
