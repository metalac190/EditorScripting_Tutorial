using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ElementType
{
    None,
    Earth,
    Fire,
    Wind,
    Water,
    Heart
}

[System.Serializable]
public class MonsterAbility
{
    [SerializeField]
    private string _name = "...";
    [SerializeField]
    private int _damage = 1;
    [SerializeField]
    private ElementType _element = ElementType.None;
}
