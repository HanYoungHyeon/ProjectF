using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Monster : MonoBehaviour, IHitable
{
    private float hp;
    private float atk;
    public M_ScriptableObject scriptable;
    public Animator animator;
    public CharacterController monsterController;
    public GameObject player;
    public float Hp
    {
        get { return hp; }
        set
        {
            hp = value;
            if (hp <= 0)
            {
                SetState(new M_DieState(gameObject));
            }
        }
    }

    public IStater curState;
    public M_AttackState m_AttackState;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        monsterController = GetComponent<CharacterController>();
        SetStaters();
        player = GameObject.Find("Player");
        SetState(new M_MoveState(gameObject));
    }
    private void SetStaters()
    {
        Hp = scriptable.hp;
        atk = scriptable.atk;
    }

    public void SetState(IStater input)
    {
        if(curState != null)
        {
            curState.Exit();
        }
        curState = input;
        curState.Enter();
    }

    public void Hit(float damage)
    {
        Hp -= damage;
    }
}
