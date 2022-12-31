using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    List<Character> _BattleCharList = new List<Character>();
    public List<Character> BattleCharList => _BattleCharList;

    List<Character> CharTurnList = new List<Character>();

    void CharTurnReplace()
    {

    }
}