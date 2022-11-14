using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMonster : Monster
{
    public R_Attack r_attack;
    public R_Movement r_movement;
    public R_Scream r_scream;
    public bool isCool;
    public bool isAngry;

    float phaseHp;

    private void Start()
    {
        r_attack = new R_Attack(gameObject);
        r_movement = new R_Movement(gameObject);
        r_scream = new R_Scream(gameObject);
        isAngry = false;
        isCool = true;
        SetState(r_movement);
        phaseHp = (scriptable.hp / 100)*30;
    }
    private void Update()
    {
        if(Hp <= phaseHp)
        {
            SetState(r_scream);
        }
        curState.Update();
    }

    public void StartCor()
    {

    }

    public IEnumerator SkillCoolTimeCor(float time)
    {
        yield return new WaitForSeconds(time);
        isCool = true;
    }
}
