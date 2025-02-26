using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour 
{

    public Vector3 GetMovementInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        return new Vector3(x, y, 0).normalized;
    }

    public IMarkable GetMarkable()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity, PlayerManager.Instance.Marking.MarkableLayer);
            
            if(hit.collider != null)
            {
                return hit.collider.GetComponent<IMarkable>();
            }
        }
        return null;
    }
}
