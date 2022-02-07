using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [Header("General Stats")]
    [SerializeField]
    private string _name;
    [SerializeField][Range(0,100)]
    private float _changeToDropItem;
    [SerializeField][Tooltip("Radius size where monster will see the player")]
    private float _rangeOfAwareness;

    [Header("Combat Stats")]
    [SerializeField]
    private int _damage;
    [SerializeField]
    private int _health;
    [SerializeField]
    private int _speed;

    [Header("Dialogue")]
    [SerializeField][Tooltip("Speaks dialogue when entering combat")]
    [TextArea()]
    private string _battleCry;
}
