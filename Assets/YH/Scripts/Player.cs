using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour,IHitable
{
    [SerializeField]
    private Slider hpBar;
    [SerializeField]
    private TextMeshProUGUI hpText;
    private CharacterController character;
    private float moveSpeed;
    public ParticleSystem swordEffect;
    public ParticleSystem shieldEffect;
    public ParticleSystem hitEffect;
    public float maxhp;
    public float minAtk;
    public float minDef;
    public float hpRecovery;
    public float secondAtk;
    public float thirdAtk;
    public bool isHit;
    public bool isAttackOver;
    public bool isGuardOver;
    public Vector3 moveInput;
    private IStater curState;
    private PlayerIdleState playerIdleState;
    private PlayerWalkState playerWalkState;
    private PlayerAttackState playerAttackState;
    private PlayerShieldState playerShieldState;
    private PlayerRollState playerRollState;
    private PlayerHitState playerHitState;
    private PlayerDieState playerDieState;
    private WaitForSeconds fiveSeconds;
    private float hp;
    public float Hp
    {
        get { return hp; }
        set 
        {
            if (isGuardOver == false)
                return;
            if (hp < maxhp && isHit == false && value < 0)
            {
                hp = value / def;
                hpBar.value = hp;
                hpText.text = "HP : "+ hp;
                isHit = true;
                SetState(playerHitState);
                if (hp <= 0)
                {
                    SetState(playerDieState);
                    hp = maxhp;
                }
            }
            if(value > 0)
            {
                hp = value;
                hpBar.value = hp;
            }
        }
    }
    private float atk;
    public float Atk
    {
        get { return atk; }
        set 
        {
            atk = value;
        }
    }
    private float def;
    public float Def
    {
        get { return def; }
        set 
        { 
            def = value;
        }
    }
    public void SetState(IStater input)
    {
        if (curState != null)
        {
            curState.Exit();
        }
        curState = input;
        curState.Enter();
    }
    private void Awake()
    {
        maxhp = 100;
        hp = maxhp;
        hpText.text = "HP : " + hp;
        minAtk = 1;
        atk = minAtk;
        minDef = 1;
        def = minDef;
        moveSpeed = 5f;
        hpRecovery = 0f;
        fiveSeconds = new WaitForSeconds(5f);
        isAttackOver = true;
        isGuardOver = true;
        isHit = false;
        character = GetComponent<CharacterController>();
        playerIdleState = new PlayerIdleState(this.gameObject);
        playerWalkState = new PlayerWalkState(this.gameObject);
        playerAttackState = new PlayerAttackState(this.gameObject);
        playerShieldState = new PlayerShieldState(this.gameObject);
        playerHitState = new PlayerHitState(this.gameObject);
        playerDieState = new PlayerDieState(this.gameObject);
        playerRollState = new PlayerRollState(this.gameObject);
    }
    private void Start()
    {
        SetState(playerIdleState);
        StartCoroutine(HpRecovery());
    }
    private void Update()
    {
        curState.Update();

        hpBar.maxValue = maxhp;
    }
    public void Move(Vector3 inputDirection)
    {
        
        if (isAttackOver)
        {
            character.Move(inputDirection * moveSpeed);
            gameObject.transform.forward = inputDirection;
            SetState(playerWalkState);
        }
    }
    public void Attack()
    {
            isAttackOver = false;
            SetState(playerAttackState);
    }
    public void Shield()
    {
            isGuardOver = false;
            SetState(playerShieldState);
    }
    public void Roll()
    {
            SetState(playerRollState);
    }
    IEnumerator HpRecovery()
    {
        while (true)
        {
            yield return fiveSeconds;
            Hp += hpRecovery;
        }
    }
    public void Hit(float damage)
    {
        Hp -= damage;
    }
}

