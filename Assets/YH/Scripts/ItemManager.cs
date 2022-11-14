using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class ItemManager : MonoBehaviour
{
    public Player player;
    public Image[] images;
    public TextMeshProUGUI[] names;
    public TextMeshProUGUI[] tooltips;
    public Shop shop;
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
