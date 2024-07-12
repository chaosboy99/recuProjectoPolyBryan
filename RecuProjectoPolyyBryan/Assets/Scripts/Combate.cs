using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combate : MonoBehaviour
{
    [SerializeField] private Transform ControlGolpe;
    [SerializeField] private float RadioGolpe;
    [SerializeField] private float dañoGolpe;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Golpe();
        }
    }

    private void Golpe()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(ControlGolpe.position, RadioGolpe);

        foreach (Collider2D GolpeColision in objetos)
        {
            if (GolpeColision.CompareTag("Enemigo"))
            {
                GolpeColision.transform.GetComponent<Enemigo>().RecibirDaño(dañoGolpe);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(ControlGolpe.position, RadioGolpe);
    }
}


