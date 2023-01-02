using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Stat
{
    public float HP;
    public float ATK;
    public int SPD;
}

[Serializable]
public enum Team
{
    Player,
    Enemy
}

[CreateAssetMenu(fileName = "Character", menuName = "Scriptable Object/Character", order = 0)]
public class CharacterSO : ScriptableObject
{
    [SerializeField] public Team team;
    [SerializeField] public Stat stat;
    [SerializeField] SkillSO skill;

    public void use(Character ch)
    {
        skill.use(ch);
    }
}
