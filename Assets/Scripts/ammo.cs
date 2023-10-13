using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ammo : MonoBehaviour
{
    public GameObject target;
    public int speed;
    public int damage;
    private Vector3 direction;
    private float minDist;
    private float dist;
    // Update is called once per frame
    
    void Update()
    {
        if (target == null)
        {
            //si on veux un missile qui change de cible si la cible de base est détruite
            /*minDist = 100;
            foreach (GameObject ennemy in game.instance.ennemies)
            {
                if (ennemy == null)
                {
                    continue;
                }

                dist = Vector3.Distance(transform.position, ennemy.transform.position);

                if (dist < minDist)
                {
                    minDist = dist;
                    target = ennemy;
                }
            }*/
            Destroy(gameObject);
            return;
        }

        direction = (target.transform.position - transform.position).normalized;
        transform.up = -direction;
        transform.position += speed * direction * Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ennemy"))
        {
            Destroy(gameObject);
            collision.GetComponent<ennemy>().Damaged(damage);
        }
    }
}

