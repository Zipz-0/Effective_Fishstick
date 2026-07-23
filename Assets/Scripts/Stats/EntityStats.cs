using UnityEngine;
using game.Stats;

[CreateAssetMenu(fileName = "EntityStats", menuName = "Scriptable Objects/EntityStats")]
public class EntityStats : ScriptableObject
{
    /*
    we should distinguish between a Stat and its modifiers, and a "Resource"
    each Resource has three values that should update when a Stat is updated or smth happens in the game
    how would you implement...:
    health?
        -> init: currentHealth = Resource(0, health.Value, health.Value)
        when damaging 
        currentHealth -= damage
    attackDamage?
        -> init: damage = Stat.Value * ...


    basically if its something we need to constantly change and keep track of (and is bounded), use Resource
    Resource(min, max, current)
    if we just need one off calculations just use the Stat.Value

    */
    public Stat health, speed, damage, attackRange, attackCooldown, channelDelay;
    [Range(0,100)] public Stat channelChance;
    [SerializeField] public Stat[] channelTime;
    // [HideInInspector]public float currentHealth, attackCooldownTimer;
    // ---> these should be Resources
}

