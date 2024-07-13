using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
    [SerializeField] private Image ImgCorazon;
    [SerializeField] RectTransform PosicionPrimerCorazon;
    [SerializeField] private Canvas MyCanvas;
    private int OffSet = 80;

    private List<Image> corazones;
    public int CantidadCorazones = 3;
    // Start is called before the first frame update
    void Start()
    {
        corazones = new List<Image>();
        Vector2 PosicionCorazon = PosicionPrimerCorazon.anchoredPosition;
        for (int i = 0; i < CantidadCorazones; i++)
        {
            Image newCorazon = Instantiate(ImgCorazon, MyCanvas.transform);
            newCorazon.rectTransform.anchoredPosition = PosicionCorazon;
            corazones.Add(newCorazon);
            PosicionCorazon.x += OffSet;

        }
        if (CantidadCorazones == 0)
        {
            Die();
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            PerderCorazones();
        }
    }
    public void PerderCorazones()
    {
        if (corazones.Count > 0)
        {
            Image UltimoCorazon = corazones[corazones.Count - 1];
            corazones.RemoveAt(corazones.Count - 1);
            Destroy(UltimoCorazon.gameObject);
            if (corazones.Count == 0)
            {
                Die();
            }
        }

    }
    public void Die()
    {
        SceneManager.LoadScene("GameOver");
    }
    
}
