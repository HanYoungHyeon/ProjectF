using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Monster : MonoBehaviour, IHitable
{
    private float hp;
    private float atk;
    public M_ScriptableObject scriptable;
    protected Animator animator;
    protected CharacterController monster;
    protected GameObject target;
    public float Hp
    {
        get { return hp; }
        set
        {
            hp = value;
            if (hp <= 0)
            {
                Die();
            }
        }
    }

    public IStater curState;
    public M_AttackState m_AttackState;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        monster = GetComponent<CharacterController>();
        SetStaters();
        target = GameObject.Find("Player");
        
    }
    private void SetStaters()
    {
        Hp = scriptable.hp;
        atk = scriptable.atk;
    }

    public void Die()
    {
        animator.SetTrigger("Die");
    }

    public void Hit(float damage)
    {
        Hp -= damage;
    }
}
