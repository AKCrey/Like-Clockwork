using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new GameSettings", menuName = "ScriptableObjects/GameSettings")]
public class GameSettings : ScriptableObject
{
    [SerializeField] public float throttlePower; //In the UI builder you need to name the binding path the exact same as the variable name
    [SerializeField] public float rotationPower;
    [SerializeField] public float damage;
    [SerializeField] public bool enableDamage;
}
