using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    [SerializeField,Header("向かう場所")] Transform _target;


    Ray _lastRay;//Rayはクリックしたら消えるから
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _lastRay = Camera.main.ScreenPointToRay(Input.mousePosition);//mouseのpositionにRayを飛ばす
        }
        Debug.DrawRay(_lastRay.origin, _lastRay.direction * 100,Color.red);//Rayの可視化
        GetComponent<NavMeshAgent>().destination = _target.position;
    }
}
