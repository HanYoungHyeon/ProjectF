using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ShopManager : MonoBehaviour
{
    private static ShopManager instance;
    [SerializeField]
    private GameObject shopCanvas;
    public ShopManager Instnace 
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
    private void Awake()
    {
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
