using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrayMonster : Monster
{
    public Gr_Attack gr_attack;
    public Gr_Movement gr_movement;
    public ParticleSystem[] particles;
    public bool isAngry;
    public bool isCool;

    float phaseHp;
    IEnumerator coolTimeCor;

    private void Start()
    {
        gr_movement = new Gr_Movement(gameObject);
        gr_attack = new Gr_Attack(gameObject);

        SetState(gr_movement);
        isCool = true;
        isAngry = false;
        phaseHp = (scriptable.hp / 100) * 30;
    }

    private void Update()
    {
        if(Hp <= phaseHp && !isAngry)
        {
            isAngry=true;
            gr_movement = new Gr2_Movenent(gameObject);
        }
        curState.Update();
    }

    public void StartCor()
    {
        if(isAngry)
        {
            coolTimeCor = SkillColTime(15);
        }
        else
        {
            coolTimeCor = SkillColTime(6);
        }
        StartCoroutine(coolTimeCor);
    }

    public IEnumerator SkillColTime(float cool)
    {
        yield return new WaitForSeconds(cool);
        isCool = true;
    }
}
