using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    #region BattleField
    [SerializeField] Field _BattleField;
    public Field BattleField => _BattleField;
    #endregion

    List<Character> BattleCharList = new List<Character>();

    public void CharEnter(Character ch)
    {
        BattleCharList.Add(ch);
    }

    public void CharExit(Character ch)
    {
        BattleCharList.Remove(ch);
    }

    #region OrderSort

    void CharTurnReplace()
    {
        SpeedSort();
    }

    // 일단 선택 정렬으로 정렬, 나중에 바꾸기
    void SpeedSort()
    {
        for(int i = 0; i < BattleCharList.Count; i++)
        {
            Character max = null;
            for(int j = i; j < BattleCharList.Count; j++)
            {
                if (i == j)
                {
                    max = BattleCharList[j];
                }
                else if (BattleCharList[j].GetSpeed() > max.GetSpeed())
                {
                    CharSwap(i, j);
                }
                else if(BattleCharList[j].GetSpeed() == max.GetSpeed())
                {
                    if(BattleCharList[j].LocX < max.LocX)
                    {
                        CharSwap(i, j);
                    }
                    else if(BattleCharList[j].LocX == max.LocX)
                    {
                        if(BattleCharList[j].LocY < max.LocY)
                        {
                            CharSwap(i, j);
                        }
                    }
                }
            }
        }
    }

    void CharSwap(int a, int b)
    {
        Character dump = BattleCharList[a];
        BattleCharList[a] = BattleCharList[b];
        BattleCharList[b] = dump;
    }

    #endregion

    public void TurnStart()
    {
        CharTurnReplace();

        StartCoroutine(CharUse());
    }

    IEnumerator CharUse()
    {
        for (int i = 0; i < BattleCharList.Count; i++)
        {
            BattleCharList[i].use();

            yield return new WaitForSeconds(0.5f);
        }
    }
}