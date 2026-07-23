using UnityEngine;
using game.Stats;

// Replace the old Stats.cs with this when it works...
[CreateAssetMenu(fileName = "NewStats", menuName = "Scriptable Objects/NewStats")]
public class NewStats : ScriptableObject
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
    [Range(0,100)] public Stat channelChance;
    [SerializeField] public Stat[] channelTime;
    // [HideInInspector]public float currentHealth, attackCooldownTimer;



    public Stat healthStat, speedStat, damageStat, attackRangeStat, attackCooldownStat, channelDelayStat;
}
