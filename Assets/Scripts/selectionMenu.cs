using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.EventSystems;

public class selectionMenu : MonoBehaviour
{
    public bool open = false;
    public GameObject slot;
    public GameObject[] towers;
    public GameObject[] upgrades;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && open && !EventSystem.current.IsPointerOverGameObject())
        {
            CloseMenu();
            return;
        }
        open = true;
    }

    public void OpenMenu()
    {
        if (slot.GetComponent<slot>().empty)
        {
            foreach (GameObject tower in towers)
            {
                Instantiate(tower, gameObject.transform);
            }
        }
        else
        {
            
            foreach(GameObject upgrade in upgrades)
            {
                Instantiate(upgrade, gameObject.transform);
            }
        }
    }
    public void CloseMenu()
    {
        open = false;
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        slot.GetComponent<slot>().rangeCircle.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.SetActive(false);
    }
}
