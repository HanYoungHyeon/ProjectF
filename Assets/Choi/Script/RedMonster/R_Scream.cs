using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Scream : MonsterBaseState
{
    RedMonster r_monster;
    public R_Scream(GameObject gameObject) : base(gameObject)
    {
        gameObj = gameObject;
        r_monster = gameObj.GetComponent<RedMonster>();
    }

    public override void Enter()
    {
        r_monster.animator.SetTrigger("Scream");
        r_monster.isAngry = true;
    }

    public override void Update()
    {
        if (monster.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            r_monster.SetState(r_monster.r_movement);
        }
    }
}
