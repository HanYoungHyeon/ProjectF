using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class Shop : MonoBehaviour
{
    [SerializeField]
    private GameObject shopCanvas;
    [SerializeField]
    private GameObject itemManager;
    public Action getItem;
    private void Awake()
    {
        itemManager.SetActive(true);
    }
    public void OnClickButton()
    {
        getItem();
        shopCanvas.SetActive(false);
    }
    public void OnClikExit()
    {
        shopCanvas.SetActive(false);
    }
}
