using RPG.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    /// <summary>
    /// �L�����N�^�[�̈ړ������N���X
    /// </summary>
    public class Mover : MonoBehaviour,IActin
    {
        [SerializeField, Header("�������ꏊ")] Transform _target;

        NavMeshAgent _navMeshAgent;

        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            UpdateAnimator();
        }

        public void StartMoveAction(Vector3 destination)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            MoveTo(destination);
        }

        /// <summary>
        /// MouseClick��Player�����̏ꏊ�Ɉړ�����
        /// </summary>
        //private void MoveToCursor()
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit raycastHit;
        //    bool hasHit = Physics.Raycast(ray, out raycastHit);//�������ǂ��ɓ����������Ƃ�������raycastHit�ϐ��Ɋi�[
        //    if (hasHit)
        //    {
        //        MoveTo(raycastHit.point);
        //    }
        //}

        public void MoveTo(Vector3 destination)
        {
            _navMeshAgent.destination = destination;
            _navMeshAgent.isStopped = false;
        }

        public void Cancel()
        {
            _navMeshAgent.isStopped = true; 
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
