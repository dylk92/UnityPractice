using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Effect_Attack", menuName = "Scriptable Object/Effect_Attack", order = 3)]
public class Effect_Attack : EffectSO
{
    [SerializeField] RangeSO range;
    [SerializeField] float DMG;

    public override void Effect(Character caster)
    {
        float CharATK = caster.characterSO.stat.ATK;

        Tile[,] Tiles = GameManager.Instance.BattleMNG.BattleField.TileArray;

        List<Vector2> RangeList = GetRange();

        for(int i = 0; i < RangeList.Count; i++)
        {
            int x = caster.LocX - (int)RangeList[i].x;
            int y = caster.LocY - (int)RangeList[i].y;

            if(0 <= x && x < 8)
            {
                if(0 <= y && y < 3)
                {
                    Tiles[y, x].Attacked(caster);
                }
            }
        }
    }

    public List<Vector2> GetRange() => range.GetRange();
}
