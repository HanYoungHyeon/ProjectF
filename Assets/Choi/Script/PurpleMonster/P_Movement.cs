using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Movement : M_MoveState
{
    public PurpleMonster p_monster;
    public P_Movement(GameObject gameObject) : base(gameObject)
    {
        gameObj = gameObject;
        p_monster = gameObject.GetComponent<PurpleMonster>();        
    }

    public override void Enter()
    {
        p_monster.animator.SetFloat("Speed", monster.speed);
    }

    public override void Update()
    {
        Vector3 toPlayerVec = (p_monster.player.transform.position - p_monster.transform.position).normalized;
        p_monster.transform.forward = toPlayerVec;
        p_monster.monsterController.SimpleMove(toPlayerVec * monster.speed);
        if (Vector3.Distance(p_monster.player.transform.position, p_monster.transform.position) < 4.5f)
        {
            if (p_monster.isTailCool)
            {
                p_monster.isTailCool = false;
                p_monster.p_attack = new P_TailAttack(gameObj);
            }
            else
            {
                p_monster.p_attack = new P_Attack(gameObj);
            }
            p_monster.SetState(p_monster.p_attack);
        }
    }

    public override void Exit()
    {
        p_monster.animator.SetFloat("Speed", 0);
    }
}

public class P2_Movement : P_Movement
{
    public P2_Movement(GameObject gameObject) : base(gameObject)
    {
        monster.speed = 2;
    }
}
