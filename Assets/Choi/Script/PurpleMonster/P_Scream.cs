using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Scream : MonsterBaseState
{
    public PurpleMonster p_monster;
    public P_Scream(GameObject gameObject) : base(gameObject)
    {
        gameObj = gameObject;
        p_monster = gameObject.GetComponent<PurpleMonster>();
    }

    public override void Enter()
    {
        p_monster.animator.SetTrigger("Scream");
        for(int i = 0; i < p_monster.phaseParts.Length;i++)
        {
            p_monster.phaseParts[i].Play();
        }

        p_monster.Hp += p_monster.selfHell;
        p_monster.atk += 3;
        p_monster.isDoSelfHell = false;
    }
    public override void Update()
    {
        if (monster.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            monster.SetState(p_monster.p_movement);
        }
    }

}
