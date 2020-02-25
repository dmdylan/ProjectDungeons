using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Base Stat", menuName = "Stats/Base Stats")]
public class BaseStats : ScriptableObject
{
    [SerializeField] private float _baseValue;
}
