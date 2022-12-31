using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Effect_Attack", menuName = "Scriptable Object/Effect_Attack", order = 3)]
public class Effect_Attack : EffectSO
{
    [SerializeField] RangeSO range;
    [SerializeField] float DMG;

    public override void Effect(GameObject caster)
    {
        float CharATK = caster.GetComponent<Character>().characterSO.stat.ATK;

        Debug.Log("Attack " + CharATK * DMG + "DMG");

        List<Vector2> rg = GetRange();

        for(int i = 0; i < rg.Count; i++)
        {
            Debug.Log(rg[i]);
        }

    }

    public List<Vector2> GetRange() => range.GetRange();
}
