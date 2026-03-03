using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Scriptable Objects/Stats")]
public class Stats : ScriptableObject
{
    [SerializeField] public float health, speed, damage, attackRange, attackCooldown;
    [SerializeField] public float[] channelTime;
    [HideInInspector]public float currentHealth, attackCooldownTimer;

}
