using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// キャラクターの移動を作るクラス
/// </summary>
public class Mover : MonoBehaviour
{
    [SerializeField,Header("向かう場所")] Transform _target;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoveToCursor();
        }
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
            GetComponent<NavMeshAgent>().destination = raycastHit.point;
        }
    }
}
