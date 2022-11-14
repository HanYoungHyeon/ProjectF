using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleMonster : Monster
{

    public P_Attack p_attack;
    public P_Movement p_movement;
    public P_Scream p_scream;
    public float selfHell;
    public bool isDoSelfHell = true;
    public bool isTailCool = true;
    public ParticleSystem[] phaseParts;

    float phaseTwo;

    public IEnumerator tailcor;
    private void Start()
    {
        p_attack = new P_Attack(gameObject);
        p_movement = new P_Movement(gameObject);
        p_scream = new P_Scream(gameObject);

        SetState(p_movement);
        selfHell = 30;

        phaseTwo = (scriptable.hp / 100) * 20;
    }

    private void Update()
    {
        if(Hp <= phaseTwo && isDoSelfHell)
        {
            SetStratagy();
            SetState(p_scream);
        }
        curState.Update();
    }

    public void SetStratagy()
    {
        p_movement = new P2_Movement(gameObject);
    }
    public void StartCor()
    {
        tailcor = TailCool();
        StartCoroutine(tailcor);
    }

    public IEnumerator TailCool()
    {
        yield return new WaitForSeconds(5);
        isTailCool = true;
    }





}
