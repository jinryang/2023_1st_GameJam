using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour
{
    public UnitCode unitCode { get; }
    public string name { get; set; }
    public int maxHp { get; set; }
    public int HP { get; set; }
    public int ATK { get; set; }
    public int EXP { get; set; }
    public float AttackSpeed { get; set; }
    public float ShotSpeed { get; set; }
    public float moveSpeed { get; set; }

    public Stat()
    {

    }

    public Stat(UnitCode unitCode, string name, int maxHp, int HP, int ATK, int EXP, float AttackSpeed, float ShotSpeed, float moveSpeed)
    {
        this.unitCode = unitCode;
        this.name = name;
        this.maxHp = maxHp;
        this.HP = maxHp;
        this.ATK = ATK;
        this.EXP = EXP;

        this.AttackSpeed = AttackSpeed;
        this.ShotSpeed = ShotSpeed;
        this.moveSpeed = moveSpeed;
    }

    public Stat SetUnitStat(UnitCode unitCode)
    {
        Stat stat = null;

        switch (unitCode)
        {
            case UnitCode.Player:
                stat = new Stat(unitCode, "Player", 10, 10, 1, 5, 0.8f, 8f, 4f);
                break;
            case UnitCode.Slime:
                stat = new Stat(unitCode, "Slime", 3, 3, 1, 1, 0.2f, 0f, 1f);
                break;
            case UnitCode.Flower:
                stat = new Stat(unitCode, "Flower", 5, 5, 1, 2, 1.5f, 4f, 0f);
                break;
            case UnitCode.Goblin:
                stat = new Stat(unitCode, "Goblin", 4, 4, 1, 3, 0.2f, 0f, 1.5f);
                break;
            case UnitCode.Goblin_Bow:
                stat = new Stat(unitCode, "Goblin_Bow", 3, 3, 1, 3, 1.2f, 5f, 0f);
                break;
            case UnitCode.Skeleton:
                stat = new Stat(unitCode, "Skeleton", 10, 10, 5, 5, 0.2f, 0f, 1f);
                break;
            default:
                Debug.Log("아직 만들어지지 않았다.");
                break;
        }
        return stat;
    }
}
