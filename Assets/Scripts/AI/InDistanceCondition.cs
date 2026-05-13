using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "In Distance", story: "[Player] is within attack range of [Enemy]", category: "Conditions", id: "7a3fe1bd287082d24693001e1d8e826a")]
public partial class InDistanceCondition : Condition
{
     [SerializeReference] public BlackboardVariable<AIBase> Enemy;
     [SerializeReference] public BlackboardVariable<Transform> Player;
     [Comparison(comparisonType: ComparisonType.All)]
     [SerializeReference] public BlackboardVariable<ConditionOperator> Operator;
     [SerializeReference] public BlackboardVariable<float> AttackThreshold;
    public override bool IsTrue()
    {
        if(Enemy.Value == null || Player.Value == null)
        {
            return false;
        }

        Debug.Log("Checking distance condition");

        float currentDistance = Vector3.Distance(Enemy.Value.transform.position, Player.Value.position);

        return Enemy.Value.stats.attackRange > currentDistance;
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
