using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : Singleton<GameManager>
{
    private static GameManager instance;
    [SerializeField]
    private GameObject shopCanvas;
    public GameManager Instnace 
    {
        get { return instance; }
    }
    private int wave;
    private int curWave;
    public int Wave
    {
        get { return wave; }
        set 
        { 
            wave = value; 
            if(wave != curWave)
            {
                shopCanvas.SetActive(true);
                curWave = wave;
            }
        }
    }
    private new void Awake()
    {
        base.Awake();
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
        wave = 0;
        curWave = wave;
    }
}
