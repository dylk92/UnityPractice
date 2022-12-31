using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour
{
    [SerializeField] public CharacterSO characterSO;

    void Start()
    {
        Init();
        use();
        StartCoroutine(CharUse());
    }

    void Init()
    {
        Debug.Log(GameManager.Instance.BattleMNG.BattleCharList);
        GameManager.Instance.BattleMNG.BattleCharList.Add(GetComponent<Character>());
    }

    IEnumerator CharUse()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            use();
        }
    }

    void use()
    {
        characterSO.use(gameObject);
    }

    public int GetSpeed() => characterSO.stat.SPD;
}
