using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Qus_Exc : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(ActiveFalse());
    }

    IEnumerator ActiveFalse()
    {
        yield return new WaitForSeconds(2f);
        this.gameObject.SetActive(false);    
    }
}
