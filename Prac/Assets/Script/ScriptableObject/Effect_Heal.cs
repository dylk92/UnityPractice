using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Effect_Heal", menuName = "Scriptable Object/Effect_Heal", order = 4)]
public class Effect_Heal : EffectSO
{
    [SerializeField] RangeSO range;    // ���� ����
    [SerializeField] float DMG;        // ������ ����

    // ���� ����
    public override void Effect(Character caster)
    {
        float CharHeal = caster.characterSO.stat.ATK;

        Tile[,] Tiles = GameManager.Instance.BattleMNG.BattleField.TileArray;

        List<Vector2> RangeList = GetRange();

        // ���� ������ ���� ����
        for (int i = 0; i < RangeList.Count; i++)
        {
            int x = caster.LocX - (int)RangeList[i].x;
            int y = caster.LocY - (int)RangeList[i].y;

            // ���� ������ �ʵ带 ����� ���� ��� ����
            if (0 <= x && x < 8)
            {
                if (0 <= y && y < 3)
                {
                    Tiles[y, x].OnHeal(caster);
                }
            }
        }
    }

    public List<Vector2> GetRange() => range.GetRange();
}

