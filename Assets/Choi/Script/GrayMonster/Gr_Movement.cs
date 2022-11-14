using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gr_Movement : M_MoveState
{
    public GrayMonster gr_monster;
    public Gr_Movement(GameObject gameObject) : base(gameObject)
    {
        gameObj = gameObject;
        gr_monster = gameObj.GetComponent<GrayMonster>();
    }
    public override void Enter()
    {
        gr_monster.animator.SetFloat("Speed", gr_monster.speed);
    }

    public override void Update()
    {
        Vector3 toPlayerVec = gr_monster.player.transform.position - gr_monster.transform.position;
        gr_monster.transform.forward = toPlayerVec;
        Vector3 targetVec = (gr_monster.player.transform.position - gr_monster.transform.position).normalized;
        gr_monster.monsterController.SimpleMove(targetVec * monster.speed);
        if (Vector3.Distance(gr_monster.player.transform.position, gr_monster.transform.position) < 4f)
        {
            if (gr_monster.isCool)
            {
                gr_monster.isCool = false;
                if (gr_monster.isAngry)
                {
                    gr_monster.gr_attack = new Gr_FlameAttack(gameObj);
                }
                else
                {
                    gr_monster.gr_attack = new Gr_ClawAttack(gameObj);
                }
                gr_monster.StartCor();
            }
            else
            {
                gr_monster.gr_attack = new Gr_Attack(gameObj);
            }
            gr_monster.SetState(gr_monster.gr_attack);
        }
    }

    public override void Exit()
    {
        gr_monster.animator.SetFloat("Speed", 0);
        gr_monster.speed = 0;
    }
}

public class Gr2_Movenent : Gr_Movement
{
    public Gr2_Movenent(GameObject gameObject) : base(gameObject)
    {
        gr_monster.speed = 2;
    }
}
