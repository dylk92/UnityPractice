using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] public CharacterSO characterSO;

    void Start()
    {

        StartCoroutine(CharUse());
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
}
