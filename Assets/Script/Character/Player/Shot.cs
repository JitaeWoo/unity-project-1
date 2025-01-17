using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] private GameObject shotComplate;
    public GameObject enemy;
    public float playerDamage;
    private float enemyHp;
    private float killTime;
    private float timeCounter;

    /*// Start is called before the first frame update
    void Start()
    {
        enemyHp = enemy.GetComponent<Enemy>().hp;
        killTime = enemyHp / playerDamage;
        timeCounter = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(killTime >= timeCounter)
        {
            timeCounter += Time.deltaTime;
        }
        else
        {
            Instantiate(shotComplate, transform.position, Quaternion.identity);
            shotComplate.GetComponent<ShotComplate>().enemy = enemy;
            Debug.Log("I ready to kill this enemy!!!!");
            Destroy(this.gameObject);
        }
    }*/
}
