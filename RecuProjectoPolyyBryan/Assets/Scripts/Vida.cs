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
    [SerializeField] private int OffSet;

    private List<Image> corazones;
    public int CantidadCorazones;
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

    // Update is called once per frame
    public void PerderCorazones()
    {
        if (corazones.Count > 0)
        {
            Image UltimoCorazon = corazones[corazones.Count - 1];
            corazones.Remove(UltimoCorazon);
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
