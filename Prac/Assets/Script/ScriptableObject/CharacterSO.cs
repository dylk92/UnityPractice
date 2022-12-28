using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Stat
{
    public float HP;
    public float ATK;
}

[CreateAssetMenu(fileName = "Character", menuName = "Scriptable Object/Character", order = 0)]
public class CharacterSO : ScriptableObject
{
    [SerializeField] public Stat stat;
    [SerializeField] SkillSO skill;

    public void use(GameObject go)
    {
        skill.use(go);
    }
}
