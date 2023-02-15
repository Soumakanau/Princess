using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour,IActin
    {
        [SerializeField] float _weaponRange = 2f;
        Transform target;

        private void Update()
        {
            if (target == null) return;

            if (!GetIsInRange())
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Mover>().Cancel();
            }
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.position) < _weaponRange;
        }

        public void Attack(CombatTarget combattarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combattarget.transform;
        }

        public void Cancel()
        {
            target = null;
        }
    }
}

