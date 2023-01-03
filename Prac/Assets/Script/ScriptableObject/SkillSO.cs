using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Scriptable Object/Skill", order = 1)]
public class SkillSO : ScriptableObject
{
    [SerializeField] List<EffectSO> EffectList;

    // ����Ʈ����Ʈ ���� ����Ʈ���� ������� ����
    public void use(Character ch)
    {
        for(int i = 0; i < EffectList.Count; i++)
        {
            EffectList[i].Effect(ch);
        }
    }
}