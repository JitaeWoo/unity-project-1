using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAttack1 : Attack
{
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        damage = 10f;
        direction = GameObject.FindWithTag("Player").transform.position - transform.position;
        StartCoroutine(LifeTime());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * 3 * Time.deltaTime;
    }

    IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(2f);

        Destroy(this.gameObject);
    }
}
