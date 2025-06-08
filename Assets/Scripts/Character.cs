using System;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public enum Statistic{
    Life,
    Damage,
    Armor,
    AttackSpeed,
    MoveSpeed
}

[Serializable]
public class StatsValue{
    public Statistic statType;
    public int value;
    public float float_value;
    public int int_value;
    public bool typeFloat;

    public StatsValue(Statistic statType, int value = 0){
        this.statType = statType;
        this.value = value;
    }

    public StatsValue(Statistic statType, float float_value){
        this.statType = statType;
        this.float_value = float_value;
        typeFloat = true;
    }
}

[Serializable]
public class StatsGroup{
    public List<StatsValue> stats;
    public StatsGroup(){
        stats = new List<StatsValue>();
    }

    public void Init(){
        stats.Add(new StatsValue(Statistic.Life, 100));
        stats.Add(new StatsValue(Statistic.Damage, 25));
        stats.Add(new StatsValue(Statistic.Armor, 5));
        stats.Add(new StatsValue(Statistic.AttackSpeed, 1f));
        stats.Add(new StatsValue(Statistic.MoveSpeed, 1f));
    }

    internal StatsValue Get(Statistic staticToGet){
        return stats[(int)staticToGet];
    }
}

public enum Attribute{
    Strength,
    Dexterity,
    Intelligence
}

[Serializable]
public class AttributeValue{
    public Attribute attributeType;
    public int value;

    public AttributeValue(Attribute attributeType, int value = 0){
        this.attributeType = attributeType;
        this.value = value;
    }
}

[Serializable]
public class AttributeGroup{
    public List <AttributeValue> attributeValues;
    public AttributeGroup(){
        attributeValues = new List<AttributeValue>();
    }

    public void Init(){
        attributeValues.Add(new AttributeValue(Attribute.Strength));
        attributeValues.Add(new AttributeValue(Attribute.Dexterity));
        attributeValues.Add(new AttributeValue(Attribute.Intelligence));
    }
}

[Serializable]
public class ValuePool{
    public StatsValue maxValue;
    public int currentValue;

    public ValuePool(StatsValue maxValue){
        this.maxValue = maxValue;
        this.currentValue = maxValue.value;
    }

    internal void FullRestore(){
        currentValue = maxValue.value;
    }
}

public class Character : MonoBehaviour{
    [SerializeField] AttributeGroup attributes;
    [SerializeField] StatsGroup stats;
    public ValuePool lifePool;
    public bool isDead;

    private void Start(){
        attributes = new AttributeGroup();
        attributes.Init();

        stats = new StatsGroup();
        stats.Init();

        lifePool = new ValuePool(stats.Get(Statistic.Life));
    }

    public void TakeDamage(int damage){
        damage = ApplyDefense(damage);
        lifePool.currentValue -= damage;
        // Debug.Log("Life: " + lifePool.currentValue.ToString());
        CheckHealth();
    }

    private int ApplyDefense(int damage){
        damage -= stats.Get(Statistic.Armor).value;
        if(damage < 0){
            damage = 1;
        }

        return damage;
    }

    private void CheckHealth(){
        if(lifePool.currentValue <= 0){
            Debug.Log("Character is dead");
            isDead = true;
            GetComponent<CharacterDefeatHandler>().Defeated();
        }
    }

    public StatsValue TakeStats(Statistic staticToGet){
        return stats.Get(staticToGet);
    }

    internal void Restore(){
        lifePool.FullRestore();
        isDead = false;
    }
}
