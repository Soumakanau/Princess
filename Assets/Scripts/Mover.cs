using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    /// <summary>
    /// キャラクターの移動を作るクラス
    /// </summary>
    public class Mover : MonoBehaviour
    {
        [SerializeField, Header("向かう場所")] Transform _target;

        void Update()
        {
            UpdateAnimator();
        }

        /// <summary>
        /// MouseClickでPlayerがその場所に移動する
        /// </summary>
        private void MoveToCursor()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            bool hasHit = Physics.Raycast(ray, out raycastHit);//光線がどこに当たったかという情報をraycastHit変数に格納
            if (hasHit)
            {
                MoveTo(raycastHit.point);
            }
        }

        public void MoveTo(Vector3 destination)
        {
            GetComponent<NavMeshAgent>().destination = destination;
        }

        private void UpdateAnimator()
        {
            Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }
    }
}
