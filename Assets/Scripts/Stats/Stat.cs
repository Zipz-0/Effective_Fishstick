using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace game.Stats
{
    [Serializable]
    public class Stat
    {
        public float BaseValue;
        protected float lastBaseValue = float.MinValue;
        protected float _value;
        protected bool isDirty;

        protected readonly List<StatModifier> modifiers;
        public readonly ReadOnlyCollection<StatModifier> Modifiers;


        public List<Resource> observers;


        public Stat()
        {
            modifiers = new List<StatModifier>();
            Modifiers = modifiers.AsReadOnly();
            observers = new List<Resource>();
        }

        public Stat(float baseValue) : this()
        {
            BaseValue = baseValue;
        }

        public virtual float Value { get {
            if (isDirty || lastBaseValue != BaseValue) // to prevent recalcuating the final value every time...
                {
                    lastBaseValue = BaseValue;
                    _value = CalculateFinalValue();
                    isDirty = false;
                }
            return _value; }
        }

        public static implicit operator float(Stat a) { return a.Value; } // lets see if this bites us in the ass later

        public virtual void AddModifier(StatModifier mod)
        {
            isDirty = true;
            modifiers.Add(mod);
            modifiers.Sort(CompareModifierOrder);

            NotifyObservers();
        }

        protected virtual int CompareModifierOrder(StatModifier a, StatModifier b)
        {
            if (a.Order < b.Order) return -1;
            else if (a.Order > b.Order) return 1;
            return 0;
        }

        public virtual bool RemoveModifier(StatModifier mod)
        {
            if (modifiers.Remove(mod))
            {
                isDirty = true;

                NotifyObservers();
                return true;
            }
            return false;
        }

        public virtual bool RemoveAllModifiersFromSource(object source)
        {
            bool didRemove = false;
            for (int i = modifiers.Count - 1; i >= 0; i--)
            {
                if (modifiers[i].Source == source)
                {
                    isDirty = true;
                    didRemove = true;
                    modifiers.RemoveAt(i);
                }
            }
            return didRemove;
        }

        protected float CalculateFinalValue()
        {
            float finalValue = BaseValue;
            float sumPercentAdd = 0;

            for (int i = 0; i<modifiers.Count; i++)
            {
                StatModifier mod = modifiers[i];
                if (mod.Type == StatModType.Flat)
                {
                    finalValue += mod.Value;
                }
                else if (mod.Type == StatModType.PercentAdd)
                {
                    sumPercentAdd += mod.Value;
                    if (i + 1 > modifiers.Count || modifiers[i + 1].Type != StatModType.PercentAdd)
                    {
                        finalValue *= 1 + sumPercentAdd;
                        sumPercentAdd = 0;
                    }
                }
                else if (mod.Type == StatModType.PercentMult)
                {
                    finalValue *= 1 + mod.Value;
                }
            }

            // lets avoid float calc errors!
            return (float)Math.Round(finalValue, 4);
        }
        
        public void AddObserver(Resource res) { observers.Add(res); }
        public bool RemoveObserver(Resource res) => observers.Remove(res);
        public void NotifyObservers() { foreach (var obj in observers) obj.notify(this); }
        

    }


}