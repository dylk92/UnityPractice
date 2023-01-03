using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �ʵ� ���� �÷��� ĳ������ ��ũ��Ʈ
// ��ų ���, �̵�, �������� ��������� ó��

public class Character : MonoBehaviour
{
    SpriteRenderer SR;
    [SerializeField] public CharacterSO characterSO;

    Tile[,] Tiles;

    #region Loc X, Y
    [SerializeField] int locX, locY;
    public int LocX => locX;
    public int LocY => locY;
    #endregion
    [SerializeField] float MaxHP, CurHP;


    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        Tiles = GameManager.Instance.BattleMNG.BattleField.TileArray;

        Init();
        SetLotate();
    }

    // �ν����Ϳ��� ��ġ �̵���Ű�� ���� �ӽ÷� ��ġ
    private void Update()
    {
        SetLotate();
    }

    // ĳ���� �ʱ�ȭ
    void Init()
    {
        GameManager.Instance.BattleMNG.CharEnter(GetComponent<Character>());

        // sprite�� ��ġ�ߴٸ� �����ϱ�
        if (characterSO.sprite != null)
            SR.sprite = characterSO.sprite;

        // ������ ��� x�� ������
        SR.flipX = (characterSO.team == Team.Enemy) ? true : false;
        MaxHP = CurHP = characterSO.stat.HP;
    }

    // ��ų ���
    public void use()
    {
        characterSO.use(GetComponent<Character>());
    }

    // �̵� ��θ� �޾ƿ� �̵���Ų��
    public void MoveLotate(int x, int y)
    {
        Tiles[LocY, LocX].ExitTile();

        int dumpX = locX;
        int dumpY = locY;

        // Ÿ�� ������ ��� �̵��̸� �̵����� ����
        if(0 <= locX + x && locX + x < 8)
            dumpX += x;
        if (0 <= locY + y && locY + y < 3)
            dumpY += y;

        // �̵��� ���� ������� �ʴٸ� �̵����� ����
        if(!Tiles[dumpY, dumpX].isOnTile)
        {
            locX = dumpX;
            locY = dumpY;
        }


        SetLotate();
    }

    // Ÿ�� ���� �̵�
    public void SetLotate()
    {
        Vector3 vec = GameManager.Instance.BattleMNG.BattleField.GetTileLocate(LocX, LocY);
        transform.position = vec;

        // ���� Ÿ�Ͽ� ���� ���Դٰ� �˷��� 
        Tiles[LocY, LocX].EnterTile(GetComponent<Character>());
    }

    // �������� ���� ��
    public void GetDamage(float DMG)
    {
        CurHP -= DMG;

        Debug.Log("DMG : " + DMG + ", CurHP ; " + CurHP);

        if (MaxHP <= CurHP)
            CurHP = MaxHP;

        DeadCheck();
    }

    // ĳ���Ͱ� ����ߴ��� Ȯ��
    void DeadCheck()
    {
        if(CurHP <= 0)
        {
            // �׾��� �� ó���� �͵�
            GameManager.Instance.BattleMNG.CharExit(GetComponent<Character>());
            Tiles[LocY, LocX].ExitTile();

            Destroy(gameObject);
        }
    }

    public int GetSpeed() => characterSO.stat.SPD;
}
