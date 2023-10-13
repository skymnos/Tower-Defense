using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower : MonoBehaviour
{

    public float range;
    public float fireRate;
    public GameObject ammo;
    public Transform firePosition;

    private float minDist = 100;
    private float dist;
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0, fireRate);
    }

    // Update is called once per frame
    void Update()
    {
        minDist = range + 1;
        foreach (GameObject ennemy in game.instance.ennemies)
        {
            if(ennemy == null)
            {
                continue;
            }
            dist = Vector3.Distance(transform.position, ennemy.transform.position);

            if (dist < minDist)
            {
                minDist = dist;
                target = ennemy;
            }

            
        }
    }

    private void Fire()
    {
        Debug.Log(minDist);
        if (minDist < range)
        {
            Instantiate(ammo, firePosition.position, Quaternion.identity).GetComponent<ammo>().target = target;
        }
    }

    public void UpdateFireRate(float rate)
    {
        fireRate = rate;
        CancelInvoke();
        InvokeRepeating("Fire", 0, fireRate);
    }
}
