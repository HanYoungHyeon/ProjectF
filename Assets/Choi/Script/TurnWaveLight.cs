using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurnWaveLight : MonoBehaviour
{
    private Monster monster;    

    public UnityAction NextWaveAction;
    private void Start()
    {
        monster = FindObjectOfType<Monster>();
        monster.monsterDieAction += TurnLight;
    }

    private void TurnLight()
    {
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            if(GameManager.Instance.Wave == 0)
            {
                GameManager.Instance.Wave++;
            }
            NextWaveAction?.Invoke();
            //ȭ�� �˰� �����
            //�÷��̾� ��ġ �ٲٰ�
            gameObject.SetActive(false);
        }
    }
}