using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenMonster : Monster
{
    private void Update()
    {
        //if(SetDistanse() < 5)
        //{
        //    transform.forward = player.transform.position;
        //    monsterController.SimpleMove(player.transform.position);
        //}
        //else if(SetDistanse() < 2)
        //{
        //    SetState(new M_AttackState(gameObject));
        //}
        //curState.Update();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            SetState(new M_AttackState(gameObject));
        }
        curState.Update();
    }

}
