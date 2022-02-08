using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    private MonsterData _data;

    [Separator()]

    [SerializeField]
    private int _health;

    public MonsterData Data => _data;

    private void Awake()
    {
        Debug.Log("Name: " + _data.Name);
        Debug.Log("Damage: " + _data.Damage);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _data.RangeOfAwareness);

        Gizmos.color = Color.cyan;
        Vector3 ray = transform.forward * _data.RangeOfAwareness;
        Gizmos.DrawRay(transform.position, ray);
    }

}
