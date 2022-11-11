using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gr_Attack : M_AttackState
{
    public GrayMonster gr_monster;
    public Gr_Attack(GameObject gameObject) : base(gameObject)
    {
        gameObj = gameObject;
        gr_monster = gameObj.GetComponent<GrayMonster>();
    }

    public override void Enter()
    {
        gr_monster.animator.SetTrigger("Attack");
    }

    public override void Update()
    {
        if (monster.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            monster.SetState(gr_monster.gr_movement);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
public class Gr_ClawAttack : Gr_Attack
{
    public Gr_ClawAttack(GameObject gameObject) : base(gameObject)
    {
    }
}

public class Gr_FlameAttack : Gr_Attack
{
    public Gr_FlameAttack(GameObject gameObject) : base(gameObject)
    {
    }
}
