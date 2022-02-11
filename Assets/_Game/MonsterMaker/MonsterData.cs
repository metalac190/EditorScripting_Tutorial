using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData_", menuName = "UnitData/Monster")]
public class MonsterData : ScriptableObject
{
    [SerializeField]
    private string _name = "...";

    [SerializeField]
    private MonsterType _monsterType = MonsterType.None;
    [SerializeField]
    [Range(0, 100)]
    private float _chanceToDropItem = 20;
    [SerializeField]
    [Tooltip("Radius size where monster will see the player")]
    private float _rangeOfAwareness = 10;
    [SerializeField]
    private bool _canEnterCombat = true;

    [SerializeField]
    private int _damage = 1;
    [SerializeField]
    private int _health = 1;
    [SerializeField]
    private int _speed = 1;

    [SerializeField]
    [Tooltip("Speaks dialogue when entering combat")]
    [TextArea()]
    private string _battleCry = "...";

    [SerializeField]
    private MonsterAbility[] _abilities;

    public string Name => _name;
    public MonsterType MonsterType => _monsterType;
    public float ChanceToDropItem => _chanceToDropItem;
    public float RangeOfAwareness => _rangeOfAwareness;
    public bool CanEnterCombat => _canEnterCombat;

    public int Damage => _damage;
    public int Health => _health;
    public int Speed => _speed;

    public string BattleCry => _battleCry;
    public MonsterAbility[] Abilities => _abilities;
}
