﻿using System;
using System.Collections.Generic;

namespace Galaga.Common.Utils.Data
{
    public enum ModifierType
    {
        None,
        Multiplier,
        Sum
    }

    public class ValueModifier
    {
        public string Id;
        public ModifierType Type;
        public float Value;

        public ValueModifier(string id, ModifierType type, float value)
        {
            Id = id;
            Type = type;
            Value = value;
        }
    }

    public class ActiveModifiableFloatData: IModifiableData
    {
        public event Action<float> UpdateEvent;
        public event Action<float> ModifierUpdatedEvent;

        public readonly Dictionary<string, ValueModifier> Modifiers = new Dictionary<string, ValueModifier>();

        private float defaultValue;
        private float modifiedDefaultValue;
        private float value;

        public ActiveModifiableFloatData(float defaultValue = default(float))
        {
            value = defaultValue;
            this.defaultValue = defaultValue;
            RecalcModifiedDefaultValue();
        }

        public void UpdateValues(float initializeValue)
        {
            DefaultValue = initializeValue;
            Value = initializeValue;
        }

        public void SetModifier(string id, bool isAdd, ModifierType type, float value)
        {
            if (isAdd)
            {
                AddModifier(id, type, value);
            }
            else
            {
                RemoveModifier(id);
            }
        }

        public void AddModifier(string id, ModifierType type, float value)
        {
            var currentCoef = Coef;
            if (!Modifiers.ContainsKey(id))
            {
                var valueModifier = new ValueModifier(id, type, value);
                Modifiers.Add(id, valueModifier);
                RecalcModifiedDefaultValue();
                Value = modifiedDefaultValue * currentCoef;
                ModifierUpdatedEvent.Call(Value);
            }
        }

        public void RemoveModifier(string id)
        {
            var currentCoef = Coef;
            if (Modifiers.ContainsKey(id))
            {
                Modifiers.Remove(id);
            }
            RecalcModifiedDefaultValue();
            Value = modifiedDefaultValue * currentCoef;
            ModifierUpdatedEvent.Call(Value);
        }

        public void RemoveModifiers()
        {
            Modifiers.Clear();
        }

        public float Coef
        {
            get
            {
                var result = 0f;
                if (DefaultValue != 0)
                {
                    result = Value / DefaultValue;
                }
                return result;
            }
        }

        private void RecalcModifiedDefaultValue()
        {
            modifiedDefaultValue = defaultValue;
            foreach (var item in Modifiers)
            {
                switch (item.Value.Type)
                {
                    case ModifierType.Sum:
                        modifiedDefaultValue += item.Value.Value;
                        break;
                    case ModifierType.Multiplier:
                        modifiedDefaultValue *= item.Value.Value;
                        break;
                }
            }
        }

        public virtual float DefaultValue
        {
            get
            {
                return modifiedDefaultValue;
            }
            set
            {
                if (!defaultValue.Equals(value))
                {
                    defaultValue = value;
                    RecalcModifiedDefaultValue();
                    UpdateEvent.Call(defaultValue);
                }
            }
        }

        public virtual float Value
        {
            get { return value; }
            set
            {
                if (!this.value.Equals(value))
                {
                    this.value = value;
                    UpdateEvent.Call(Value);
                }
            }
        }

        public void Destroy()
        {
            RemoveModifiers();
        }
    }

    public class ActiveModifiableFloatDataCont : IModifiableData
    {
        public float DefaultValue { get; set; }
        public float Value { get; set; }

        List<ActiveModifiableFloatData> data = new List<ActiveModifiableFloatData>();

        public void AddProperty(ActiveModifiableFloatData property)
        {
            data.Add(property);
        }

        public void AddModifier(string id, ModifierType type, float value)
        {
            for (var i = 0; i < data.Count; i++)
            {
                data[i].AddModifier(id, type, value);
            }
        }

        public void RemoveModifier(string id)
        {
            for (var i = 0; i < data.Count; i++)
            {
                data[i].RemoveModifier(id);
            }
        }

        public void SetModifier(string id, bool isAdd, ModifierType type, float value)
        {
            for (var i = 0; i < data.Count; i++)
            {
                data[i].SetModifier(id,isAdd,type,value);
            }
        }

        public void Destroy()
        {
            for (var i = 0; i < data.Count; i++)
            {
                data[i].Destroy();
            }
            data.Clear();
            data = null;
        }
    }

    public interface IModifiableData
    {
        void SetModifier(string id, bool isAdd, ModifierType type, float value);
        void AddModifier(string id, ModifierType type, float value);
        void RemoveModifier(string id);
        float DefaultValue { get; set; }
        float Value { get; set; }
        void Destroy();
    }
}