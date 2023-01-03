using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ ����ϴ� �Ŵ���
// �ʵ�� ���� ����
// �ʵ忡 �ö���ִ� ĳ������ ��� ��Ʋ�Ŵ������� ���

public class BattleManager : MonoBehaviour
{
    // ���� UI
    [SerializeField] ManaGuage PlayerMana;
    // ������ ����Ǵ� �ʵ�
    #region BattleField
    [SerializeField] Field _BattleField;
    public Field BattleField => _BattleField;
    #endregion

    // ������ �������� ĳ���Ͱ� ����ִ� ����Ʈ
    List<Character> BattleCharList = new List<Character>();

    bool CanTurnStart = true;

    // ����Ʈ�� ĳ���͸� �߰� / ����
    #region CharEnter / Exit
    public void CharEnter(Character ch)
    {
        BattleCharList.Add(ch);
    }
    public void CharExit(Character ch)
    {
        BattleCharList.Remove(ch);
    }
    #endregion

    #region OrderSort

    void CharTurnReplace()
    {
        SpeedSort();
    }

    // �ϴ� ���� �������� ����, ���߿� �ٲٱ�
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

    // �� ����
    public void TurnStart()
    {
        if (CanTurnStart)
        {
            CanTurnStart = false;
            CharTurnReplace();

            StartCoroutine(CharUse());
        }
    }
    //�Ͽ� ������ �ֱ�(��� ����ұ�?)
    IEnumerator CharUse()
    {
        for (int i = 0; i < BattleCharList.Count; i++)
        {
            BattleCharList[i].use();

            yield return new WaitForSeconds(1f);
        }

        TurnEnd();
    }

    void TurnEnd()
    {
        PlayerMana.AddMana(2);
        CanTurnStart = true;
    }
}