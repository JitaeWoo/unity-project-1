using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    public Warning attackWarning;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 targetPosition = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            attackWarning.StartWarning();
        }
    }
}
