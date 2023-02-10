using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    [SerializeField,Header("Œü‚©‚¤êŠ")] Transform _target;


    Ray _lastRay;//Ray‚ÍƒNƒŠƒbƒN‚µ‚½‚çÁ‚¦‚é‚©‚ç
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _lastRay = Camera.main.ScreenPointToRay(Input.mousePosition);//mouse‚Ìposition‚ÉRay‚ğ”ò‚Î‚·
        }
        Debug.DrawRay(_lastRay.origin, _lastRay.direction * 100,Color.red);//Ray‚Ì‰Â‹‰»
        GetComponent<NavMeshAgent>().destination = _target.position;
    }
}
