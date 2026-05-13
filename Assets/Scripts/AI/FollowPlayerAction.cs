using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Follow Player", story: "[AI] moves to [Player]", category: "Action", id: "b5c713e31df23e4620e75ca638b474f3")]
public partial class FollowPlayerAction : Action
{
    [SerializeReference] public BlackboardVariable<AIBase> AI;
    [SerializeReference] public BlackboardVariable<GameObject> Player;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

