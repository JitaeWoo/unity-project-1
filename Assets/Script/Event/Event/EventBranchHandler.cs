using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class EventBranchHandler : MonoBehaviour
{
    [System.Serializable]
    private class EventBranch
    {
        public string[] TriggerConditionEventIDs;
        public UnityEvent TriggerActions;
    }

    // _eventBranches의 순서가 실행될 분기의 우선순위가 됩니다.
    [SerializeField] private EventBranch[] _eventBranches;

    public void ChooseBranch()
    {
        foreach (EventBranch branch in _eventBranches)
        {
            if(branch.TriggerConditionEventIDs.All(ID => EventManager.Instance.IsPlayerExperienced(ID)))
            {
                branch.TriggerActions.Invoke();
                break;
            }
        }
    }
}
