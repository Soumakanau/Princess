using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    public class ActionScheduler : MonoBehaviour
    {
        IActin currentAction;
        public void StartAction(IActin action)
        {
            if (currentAction == action) return;
            if(currentAction != null)
            {
                currentAction.Cancel();
            }
            currentAction = action;
        }
    }

}
