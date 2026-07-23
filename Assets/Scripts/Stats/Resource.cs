using System;
using UnityEngine;

namespace game.Stats
{
    public enum ResourceStatUpdateType
    {
        None,
        OnlyMax,
        OnlyMin,
    }

    [Serializable]
    public class Resource : UnityEngine.Object
    {
        private float _value;
        [SerializeField] private float MinValue; // show in the editor
        [SerializeField] private float MaxValue;
        [SerializeField] private ResourceStatUpdateType UpdateType;

        public Resource(float minValue, float maxValue, float value, ResourceStatUpdateType updateType = ResourceStatUpdateType.OnlyMax)
        {
            Value = value;
            MinValue = minValue;
            MaxValue = maxValue;
            UpdateType = updateType;
        }

        public void updateMax(Stat stat)
        {
            /*
            If you wanna change this... change Stat.Value thru the stat modifiers and not directly with a new calculated value!
            -> (do) Stat.AddModifier(...)
                    updateMax(Stat.Value)
            -> (dont) updateMax(Stat.Value * ...)
            Another way to do this is by linking this resource to the Stat and setting the ResourceStatUpdateType enum

            Otherwise we could end up in a situation like:
            - Player gets a temporary debuff which lowers max health by 5%...
            - The debuff is removed after a time...
            - What was the player's max health again?
            - What if during the time the debuff is applied, a different buff/debuff applies? What order do
            go in?
            */
            MaxValue = stat.Value;
        }
        public void updateMin(Stat stat)
        {
            MinValue = stat.Value;
        }


        public float Value {
            get => _value;
            set { 
                if (value > MaxValue) _value = MaxValue;
                if (value < MinValue) _value = MinValue;
                else _value = value;
            }
        }

        public void notify(Stat source)
        {
            if (UpdateType == ResourceStatUpdateType.OnlyMax) updateMax(source);
            else if (UpdateType == ResourceStatUpdateType.OnlyMin) updateMin(source);
        }
    }
}
