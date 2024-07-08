using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caida : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vida vidaScript = FindObjectOfType<Vida>();
        if (Suelo.EsSuelo == false && vidaScript.CantidadCorazones != 0)
        {
            vidaScript.PerderCorazones();
            FindObjectOfType<Pj>().SendMessage("Spawn");
        }
        else if (vidaScript.CantidadCorazones == 0)
        {
            vidaScript.Die();
        }
    }
}
