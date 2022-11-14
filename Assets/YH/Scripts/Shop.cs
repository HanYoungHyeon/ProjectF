using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
public class Shop : MonoBehaviour
{
    public Player player;
    [SerializeField]
    private GameObject shopCanvas;
    public Button button;
    public Item item;
    public Action getItem;
    public Image[] images;
    public TextMeshProUGUI[] names;
    public TextMeshProUGUI[] tooltips;
    public ItemData[] items;
    [SerializeField]
    private int random;
    private void OnEnable()
    {
        StartCoroutine(RandomShop());
    }
    private void Update()
    {
        random = UnityEngine.Random.Range(0, items.Length);
    }
    public void OnClickButton()
    {
        string name = button.GetComponentInChildren<TextMeshProUGUI>().text;
        for(int i = 0; i < items.Length; i++)
        {
            
        }
        
        getItem();
        shopCanvas.SetActive(false);
    }
    public void OnClikExit()
    {
        shopCanvas.SetActive(false);
    }
    IEnumerator RandomShop()
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].sprite = items[random].Icon;
            names[i].text = items[random].Name;
            tooltips[i].text = items[random].Tooltip;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
