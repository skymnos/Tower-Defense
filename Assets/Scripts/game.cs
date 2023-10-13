using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class game : MonoBehaviour
{
    public static game instance;

    public int life;
    public int money;
    public Text lifeText;
    public Text moneyText;
    public Text gameover;

    public GameObject ennemy;
    public Transform[] checkPoints;
    public Transform spawnPoint;
    public List<GameObject> ennemies = new List<GameObject>();

    private GameObject newEnnemy;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wave(5,1,10,1,20,1));
    }

    // Update is called once per frame
    void Update()
    {
        lifeText.text = life.ToString();
        moneyText.text = money.ToString();

        if (life <= 0) 
        {
            gameover.gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.E)) 
        {
            foreach (GameObject ennemy in ennemies)
            {
                Debug.Log(ennemy);
            }
        }
    }

    IEnumerator Wave(int nb1, int delay1, int nb2, int delay2, int nb3, int delay3)
    {
        yield return new WaitForSeconds(10);
        for (int i = 0; i < nb1; i++)
        {
            newEnnemy = Instantiate(ennemy, spawnPoint.position, Quaternion.identity);
            ennemies.Add(newEnnemy);
            yield return new WaitForSeconds(delay1);
        }
        yield return new WaitForSeconds(10);
        for (int i = 0; i < nb2; i++)
        {
            newEnnemy = Instantiate(ennemy, spawnPoint.position, Quaternion.identity);
            ennemies.Add(newEnnemy);
            yield return new WaitForSeconds(delay2);
        }
        yield return new WaitForSeconds(10);
        for (int i = 0; i < nb3; i++)
        {
            newEnnemy = Instantiate(ennemy, spawnPoint.position, Quaternion.identity);
            ennemies.Add(newEnnemy);
            yield return new WaitForSeconds(delay3);
        }
    }
}
