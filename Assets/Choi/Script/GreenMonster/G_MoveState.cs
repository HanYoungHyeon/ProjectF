using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class G_MoveState : M_MoveState
{
    GreenMonster greenMonster;
    public G_MoveState(GameObject gameObject) : base(gameObject)
    {
        gameObj = gameObject;
        greenMonster = gameObj.GetComponent<GreenMonster>();
    }

    public override void Enter()
    {
        greenMonster.animator.SetFloat("Speed",1);
    }

    public override void Update()
    {
        Vector3 toPlayerVec = (greenMonster.player.transform.position - greenMonster.transform.position).normalized;
        greenMonster.transform.forward = toPlayerVec;
        greenMonster.monsterController.SimpleMove(toPlayerVec * monster.speed);
        if(Vector3.Distance(greenMonster.player.transform.position, greenMonster.transform.position) < 5f)
        {
            if(greenMonster.isRush)
            {
                greenMonster.g_Attack = new GreenMonsterRushAttack(gameObj);
            }
            else
            {
                greenMonster.g_Attack = new GreenMonsterAttack(gameObj);
            }
            greenMonster.SetState(greenMonster.g_Attack);
        }
    }

    public override void Exit()
    {
        greenMonster.animator.SetFloat("Speed", 0);
    }
}
