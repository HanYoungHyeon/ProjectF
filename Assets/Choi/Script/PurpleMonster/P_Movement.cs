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
        Vector3 toPlayerVec = p_monster.player.transform.position - p_monster.transform.position;
        p_monster.transform.forward = toPlayerVec;
        Vector3 targetVec = (p_monster.player.transform.position - p_monster.transform.position).normalized;
        p_monster.monsterController.SimpleMove(targetVec * monster.speed);
        if (Vector3.Distance(p_monster.player.transform.position, p_monster.transform.position) < 4f)
        {
            if (p_monster.isTailCool)
            {
                p_monster.isTailCool = false;
                p_monster.p_attack = new P_TailAttack(gameObj);
                p_monster.StartCor();
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
        p_monster.speed = 0;
    }
}

public class P2_Movement : P_Movement
{
    public P2_Movement(GameObject gameObject) : base(gameObject)
    {
        monster.speed = 2;
    }
    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
