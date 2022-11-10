using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Monster : MonoBehaviour, IHitable
{
    private float hp;
    public float atk;
    [SerializeField]private Transform[] poss;
    public M_ScriptableObject scriptable;
    public Animator animator;
    public CharacterController monsterController;
    public GameObject player;
    public bool isDead;
    public GameObject[] attackRange;
    public RaycastHit hit;
    public LayerMask playerMask;


    public float Hp
    {
        get { return hp; }
        set
        {
            hp = value;
            if (hp <= 0)
            {
                isDead = true;
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

    public RaycastHit HitAttackTarget(GameObject RangeObject)
    {
        poss = RangeObject.GetComponentsInChildren<Transform>();
        for (int i =1; i<poss.Length-1;i++)
        {
            Vector3 dir = poss[i + 1].position - poss[i].position;
            Debug.DrawRay(poss[i].position, dir, Color.red, 1);
            Physics.BoxCast(poss[i].position, new Vector3(1, 1, 1), dir, out hit, Quaternion.Euler(0,0,0),10,playerMask);
        }
        Debug.Log(hit.transform.name);
        return hit;
    }

    public void Hit(float damage)
    {
        Hp -= damage;
    }
}
