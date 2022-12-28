using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Effect_Attack", menuName = "Scriptable Object/Effect_Attack", order = 3)]
public class Effect_Attack : EffectSO
{
    [SerializeField] float DMG;

    public override void Effect(GameObject caster)
    {
        float CharATK = caster.GetComponent<Character>().characterSO.stat.ATK;

        Debug.Log("Attack " + CharATK * DMG + "DMG");
    }
}
