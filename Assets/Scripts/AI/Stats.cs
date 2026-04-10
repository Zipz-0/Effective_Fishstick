using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Scriptable Objects/Stats")]
public class Stats : ScriptableObject
{
    public float health, speed, damage, attackRange, attackCooldown, channelDelay;
    [Range(0,100)] public float channelChance;
    [SerializeField] public float[] channelTime;
    [HideInInspector]public float currentHealth, attackCooldownTimer;

}
