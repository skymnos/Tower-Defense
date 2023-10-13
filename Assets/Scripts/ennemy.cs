using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ennemy : MonoBehaviour
{
    public int life;
    public int value;
    public int speed;

    public GameObject blood;
    private Vector3 direction;
    private Transform nextCheckpoint;
    private Transform[] checkpoints;
    private int count = 1;
    // Start is called before the first frame update
    void Start()
    {
        checkpoints = game.instance.checkPoints;
    }

    // Update is called once per frame
    void Update()
    {
        nextCheckpoint = checkpoints[count];

        direction = (nextCheckpoint.position - transform.position).normalized;

        gameObject.transform.position += direction * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, nextCheckpoint.position) < 0.5 && count < checkpoints.Length-1)
        {
            count++;
        }
    }

    private void Dead()
    {
        Instantiate(blood, transform.position, new Quaternion(0,0,0,0));
        game.instance.money += value;
        game.instance.ennemies.Remove(gameObject);
        Destroy(gameObject);
    }

    public void Damaged(int damage)
    {
        life -= damage;

        if (life <= 0)
        {
            Dead();
        }
    }
}
