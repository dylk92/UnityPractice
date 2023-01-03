using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


// RangeSO�� Ŀ���� ������
[CustomEditor(typeof(RangeSO))]
public class RangeEditor : Editor
{
    const int row = 5;
    const int column = 15;

    RangeSO _range;
    bool[] atkRange;

    private void OnEnable()
    {
        _range = target as RangeSO;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        serializedObject.Update();

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("���� ����");

        atkRange = _range.AttackRange;

        for (int i = 0; i < atkRange.Length; i++)
        {
            if(i % column == 0)
                GUILayout.BeginHorizontal();

            GUI.color = Color.white;
            if (atkRange[i])
                GUI.color = Color.red;

            if (i == row * column >> 1)
                GUI.color = Color.green;


            SerializedProperty a = serializedObject.FindProperty("AttackRange").GetArrayElementAtIndex(i);
            atkRange[i] = EditorGUILayout.Toggle(atkRange[i]);
            a.boolValue = atkRange[i];

            if (i % column == column - 1) 
                GUILayout.EndHorizontal();
        }
        serializedObject.ApplyModifiedProperties();
    }
}


[Serializable]
[CreateAssetMenu(fileName = "Attack_Range", menuName = "Scriptable Object/Attack_Range", order = 4)]
public class RangeSO : ScriptableObject
{
    const int row = 5;
    const int column = 15;

    [SerializeField] [HideInInspector] public bool[] AttackRange = new bool[row * column];

    // ���ݹ����� ĳ������ ��ġ�� (0, 0)���� �����ϰ� ����Ʈ�� ��ȯ
    public List<Vector2> GetRange()
    {
        List<Vector2> RangeList = new List<Vector2>();

        for(int i = 0; i < AttackRange.Length; i++)
        {
            if (AttackRange[i])
            {
                int x = -((i % column) - (column >> 1));
                int y = (i / column) - (row >> 1);

                Vector2 vec = new Vector2(x, y);

                RangeList.Add(vec);
            }
        }

        return RangeList;
    }
}
