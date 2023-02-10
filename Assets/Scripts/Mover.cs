using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    [SerializeField,Header("�������ꏊ")] Transform _target;


    Ray _lastRay;//Ray�̓N���b�N����������邩��
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _lastRay = Camera.main.ScreenPointToRay(Input.mousePosition);//mouse��position��Ray���΂�
        }
        Debug.DrawRay(_lastRay.origin, _lastRay.direction * 100,Color.red);//Ray�̉���
        GetComponent<NavMeshAgent>().destination = _target.position;
    }
}
