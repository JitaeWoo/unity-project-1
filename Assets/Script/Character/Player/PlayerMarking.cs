using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMarking : MonoBehaviour
{
    [SerializeField]
    private GameObject markPrefab;

    private GameObject currentMarkInstance; 
    private IMarkable currentMarkedTarget; 

    public void TryMark(IMarkable target)
    {
        if (target != null && !target.IsMark)
        {
            ClearCurrentMark();
            MarkTarget(target);
        }
    }

    private void ClearCurrentMark()
    {
        if (currentMarkedTarget != null)
        {
            currentMarkedTarget.Unmark(); 
            currentMarkedTarget = null;
        }

        if (currentMarkInstance != null)
        {
            Destroy(currentMarkInstance); 
            currentMarkInstance = null;
        }
    }

    private void MarkTarget(IMarkable target)
    {
        currentMarkedTarget = target;
        currentMarkInstance = Instantiate(markPrefab, target.GetPosition(), Quaternion.identity, target.GetTransform());
        target.Mark();
    }
}
