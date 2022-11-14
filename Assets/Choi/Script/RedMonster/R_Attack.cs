using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Attack : M_AttackState
{
    public RedMonster r_monster;
    public R_Attack(GameObject gameObject) : base(gameObject)
    {
        gameObj = gameObject;
        r_monster = gameObj.GetComponent<RedMonster>();
    }

    public override void Enter()
    {
        r_monster.animator.SetTrigger("Attack");
        r_monster.attackCols[0].enabled = true;
    }
}

public class R_ClawAttack : R_Attack
{
    Transform target;
    public R_ClawAttack(GameObject gameObject) : base(gameObject)
    {
    }

    public override void Enter()
    {
        target = r_monster.player.transform;
        target.forward = target.position - r_monster.transform.position;
        r_monster.animator.SetTrigger("ClawAttack");
        r_monster.attackCols[1].enabled = true;
    }
}

public class R_FlameAttack : R_Attack
{
    public R_FlameAttack(GameObject gameObject) : base(gameObject)
    {
    }
    public override void Enter()
    {
        r_monster.animator.SetTrigger("FlameAttack");
        r_monster.attackCols[2].enabled = true;
    }
}
