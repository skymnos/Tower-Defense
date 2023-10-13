using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slot : MonoBehaviour
{
    public Color mainColor;
    public Color overColor;
    public Color clickedColor;
    SpriteRenderer spriteRenderer;
    public GameObject selectionMenu;
    public bool empty = true;
    public int level = 1;
    public GameObject tower;
    public GameObject rangeCircle;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rangeCircle = transform.GetChild(0).gameObject;
        rangeCircle.GetComponent<SpriteRenderer>().enabled = false;
        spriteRenderer.color = mainColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (tower == null)
        {
            return;
        }
        rangeCircle.transform.localScale = new Vector3(tower.GetComponent<tower>().range * 10, tower.GetComponent<tower>().range * 10, 1);
    }

    private void OnMouseOver()
    {
        spriteRenderer.color = overColor;
        if (Input.GetMouseButtonDown(0) && selectionMenu.GetComponent<selectionMenu>().open == false)
        {
            selectionMenu.SetActive(true);
            selectionMenu.transform.position = Input.mousePosition;
            selectionMenu.GetComponent<selectionMenu>().open = false;
            selectionMenu.GetComponent<selectionMenu>().slot = gameObject;
            selectionMenu.GetComponent<selectionMenu>().OpenMenu();
            if (!empty)
            {
                rangeCircle.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }

    private void OnMouseExit()
    {
        spriteRenderer.color = mainColor;
    }
}
