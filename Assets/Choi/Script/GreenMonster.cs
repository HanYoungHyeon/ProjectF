using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenMonster : Monster
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SetState(new M_MoveState(gameObject));
        }
        curState.Update();
    }

}
