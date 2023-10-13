using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class icone : MonoBehaviour
{
    public int price;
    public bool canBuy;

    public GameObject towerType;
    Transform selectionMenu;
    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<Text>().text = price.ToString();
        selectionMenu = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        if (price > game.instance.money)
        {
            canBuy = false;
            GetComponentInChildren<Text>().color = Color.red;
        }
        else
        {
            canBuy = true;
            GetComponentInChildren<Text>().color = Color.green;
        }
    }

    public void Buy()
    {
        if (selectionMenu.GetComponent<selectionMenu>().slot.GetComponent<slot>().empty && canBuy)
        {
            selectionMenu.GetComponent<selectionMenu>().slot.GetComponent<slot>().tower = Instantiate(towerType, selectionMenu.GetComponent<selectionMenu>().slot.transform.position, new Quaternion(0, 0, 0, 0));
            selectionMenu.GetComponent<selectionMenu>().slot.GetComponent<slot>().empty = false;
            game.instance.money -= price;
        }
        selectionMenu.GetComponent<selectionMenu>().CloseMenu();
    }

    public void Levelup()
    {
        if (canBuy)
        {
            selectionMenu.GetComponent<selectionMenu>().slot.GetComponent<slot>().tower.GetComponent<tower>().UpdateFireRate(selectionMenu.GetComponent<selectionMenu>().slot.GetComponent<slot>().tower.GetComponent<tower>().fireRate * 0.75f);
            selectionMenu.GetComponent<selectionMenu>().slot.GetComponent<slot>().tower.GetComponent<tower>().range *= 1.25f;
            selectionMenu.GetComponent<selectionMenu>().slot.GetComponent<slot>().level++;
            game.instance.money -= price;
        }
        selectionMenu.GetComponent<selectionMenu>().CloseMenu();
    }
}
