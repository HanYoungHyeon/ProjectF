using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField]
    private Slider hpBar;
    [SerializeField]
    private TextMeshProUGUI hpText;
    private CharacterController character;
    private float axisX;
    private float axisZ;
    private float moveSpeed;
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
        Move();
        Attack();
        Shield();
        Roll();
        hpBar.maxValue = maxhp;
    }
    private void Move()
    {

        axisX = Input.GetAxis("Horizontal");
        axisZ = Input.GetAxis("Vertical");
        moveInput = new Vector3(axisX, 0, axisZ);
        if (moveInput.magnitude > 0 && isAttackOver)
        {
            character.Move(moveInput * moveSpeed * Time.deltaTime);
            gameObject.transform.forward = moveInput;
            SetState(playerWalkState);
        }
    }
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isAttackOver == true)
        {
            isAttackOver = false;
            SetState(playerAttackState);
        }
    }
    private void Shield()
    {
        if(Input.GetKeyDown(KeyCode.C) && isGuardOver == true)
        {
            isGuardOver = false;
            SetState(playerShieldState);
        }
    }
    private void Roll()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            SetState(playerRollState);
        }
    }
    IEnumerator HpRecovery()
    {
        while (true)
        {
            yield return fiveSeconds;
            Hp += hpRecovery;
        }
    }
}

