using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Dir
{
    Left,
    Right,
    Up,
    Down
}

[CreateAssetMenu(fileName = "Effect_Move", menuName = "Scriptable Object/Effect_Move", order = 2)]
public class Effect_Move : EffectSO
{
    [SerializeField] List<Dir> MoveDir;

    public override void Effect(GameObject caster)
    {
        for(int i = 0; i < MoveDir.Count; i++)
            Debug.Log("Move " + MoveDir[i]);
    }
}
