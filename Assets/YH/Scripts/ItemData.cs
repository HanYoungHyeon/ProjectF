using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu]
public class ItemData : ScriptableObject
{
    public string Name => _name;
    public string Tooltip => _tooltip;
    public Sprite Icon => _icon;
    public Shop Shop;
    [SerializeField] private string _name;
    [SerializeField] private string _tooltip;
    [SerializeField] private Sprite _icon;

}
