using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float scrollSpeed = 0.025f; // Vitesse de défilement
    public GameManager g;
    private Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        // Récupère le Renderer de l'objet
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calcul de l'offset en fonction du temps
        float offset = Time.time * scrollSpeed;
        // Applique l'offset au matériau (uniquement sur l'axe X pour un défilement horizontal)
        rend.material.mainTextureOffset = new Vector2(offset, 0);

        if (g.nbEnemy >= 5)
        {
            scrollSpeed = 0.125f;
        }
        if (g.nbEnemy >= 10)
        {
            scrollSpeed = 0.225f;
        }
        if (g.nbEnemy >= 15)
        {
            scrollSpeed = 0.325f;
        }
        if (g.nbEnemy >= 20)
        {
            scrollSpeed = 0.425f;
        }
    }
}
