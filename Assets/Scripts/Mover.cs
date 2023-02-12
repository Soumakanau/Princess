using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// �L�����N�^�[�̈ړ������N���X
/// </summary>
public class Mover : MonoBehaviour
{
    [SerializeField,Header("�������ꏊ")] Transform _target;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MoveToCursor();
        }
        UpdateAnimator();
    }

    /// <summary>
    /// MouseClick��Player�����̏ꏊ�Ɉړ�����
    /// </summary>
    private void MoveToCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;
        bool hasHit = Physics.Raycast(ray, out raycastHit);//�������ǂ��ɓ����������Ƃ�������raycastHit�ϐ��Ɋi�[
        if (hasHit)
        {
            GetComponent<NavMeshAgent>().destination = raycastHit.point;
        }
    }

    private void UpdateAnimator()
    {
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        GetComponent<Animator>().SetFloat("forwardSpeed", speed);
    }
}
