using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using Unity.VisualScripting;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Get AI Script", story: "Find [AI] in [Enemy]", category: "Action", id: "e764924ff99ec162ad86cb33b6ac7353")]
public partial class GetAiScriptAction : Action
{
    [SerializeReference] public BlackboardVariable<AIBase> AI;
    [SerializeReference] public BlackboardVariable<GameObject> Enemy;

    protected override Status OnStart()
    {
        if(Enemy.Value == null)
        {
            return Status.Failure;
        }

        AI.Value = Enemy.Value.GetComponent<AIBase>();
        return AI.Value != null ? Status.Success : Status.Failure;
    }

    
}

