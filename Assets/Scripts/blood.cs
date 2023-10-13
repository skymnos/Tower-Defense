using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blood : MonoBehaviour
{
    public float fadeSpeed;
    private Color color;
    private SpriteRenderer spriteRenderer;
    private bool fade;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;
        Invoke("ActivateFade", 2);
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (fade)
        {
            color.a -= fadeSpeed * Time.deltaTime;
            spriteRenderer.color = color;
        }
    }

    void ActivateFade()
    {
        fade = true;
    }
}
