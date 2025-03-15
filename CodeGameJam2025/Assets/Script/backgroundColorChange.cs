using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundColorChange : MonoBehaviour
{

    public GameManager g;
    public float alpha = 1f;
    private Renderer colorRenderer;
    // Start is called before the first frame update
    void Awake()
    {
        colorRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (g.nbEnemy>=5) {
            //alpha = Mathf.Clamp01(100f / 25f * (g.nbEnemy - 5));
            alpha = 0.04f * (g.nbEnemy - 5f);
            colorRenderer.material.color = new Color(125f / 255f, 0, 0, alpha);
        }
        else
        {
            colorRenderer.material.color = new Color(125f / 255f, 0, 0, 0);
        }
    }
}
