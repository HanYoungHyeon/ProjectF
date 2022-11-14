using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Movement : M_MoveState
{
    public RedMonster r_monster;
    public R_Movement(GameObject gameObject) : base(gameObject)
    {
        gameObj = gameObject;
        r_monster = gameObj.GetComponent<RedMonster>();
    }
    public override void Enter()
    {
        r_monster.animator.SetFloat("Speed", r_monster.speed);
    }

    public override void Update()
    {
        Vector3 toPlayerVec = (r_monster.player.transform.position - r_monster.transform.position).normalized;
        r_monster.transform.forward = toPlayerVec;
        r_monster.monsterController.SimpleMove(toPlayerVec * monster.speed);
        if (Vector3.Distance(r_monster.player.transform.position, r_monster.transform.position) < 7f)
        {
            if(r_monster.isCool)
            {
                r_monster.isCool = false;
                r_monster.r_attack = new R_ClawAttack(gameObj);
            }
            else
            {
                r_monster.r_attack = new R_Attack(gameObj);
            }
        }
        else
        {
            if (!r_monster.isAngry)
                return;

            if (!r_monster.isFlameCool)
                return;

            r_monster.r_attack = new R_FlameAttack(gameObj);
        }
        r_monster.SetState(r_monster.r_attack);
    }

    public override void Exit()
    {
        r_monster.animator.SetFloat("Speed", 0);
    }
}
public class R_2Movement : R_Movement
{
    public R_2Movement(GameObject gameObject) : base(gameObject)
    {
        r_monster.speed = 2;
    }
}
