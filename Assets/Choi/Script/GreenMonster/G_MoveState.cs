using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_MoveState : M_MoveState
{
    GreenMonster greenMonster;
    public G_MoveState(GameObject gameObject) : base(gameObject)
    {
        this.gameObj = gameObject;
        greenMonster = this.gameObj.GetComponent<GreenMonster>();
    }

    public override void Enter()
    {
        greenMonster.animator.SetFloat("Speed",1);
    }

    public override void Update()
    {
        Vector3 toPlayerVec = greenMonster.player.transform.position - greenMonster.transform.position;
        greenMonster.transform.forward = toPlayerVec;
        Vector3 targetVec = (greenMonster.player.transform.position - greenMonster.transform.position).normalized;
        greenMonster.monsterController.SimpleMove(targetVec);
        if(Vector3.Distance(greenMonster.player.transform.position, greenMonster.transform.position) < 7f)
        {
            greenMonster.SetState(greenMonster.g_Attack);
        }
    }

    public override void Exit()
    {
        monster.animator.SetFloat("Speed", 0);
    }
}
