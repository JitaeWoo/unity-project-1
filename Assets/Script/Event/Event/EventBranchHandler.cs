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

    // _eventBranches�� ������ ����� �б��� �켱������ �˴ϴ�.
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
