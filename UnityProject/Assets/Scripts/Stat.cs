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
    public float AttackRange { get; set; }
    public float moveSpeed { get; set; }

    public Stat()
    {

    }

    public Stat(UnitCode unitCode, string name, int maxHp, int HP, int ATK, int EXP, float AttackSpeed, float AttackRange, float moveSpeed)
    {
        this.unitCode = unitCode;
        this.name = name;
        this.maxHp = maxHp;
        this.HP = maxHp;
        this.ATK = ATK;
        this.EXP = EXP;

        this.AttackSpeed = AttackSpeed;
        this.AttackRange = AttackRange;
        this.moveSpeed = moveSpeed;
    }

    public Stat SetUnitStat(UnitCode unitCode)
    {
        Stat stat = null;

        switch (unitCode)
        {
            case UnitCode.Player:
                stat = new Stat(unitCode, "Player", 100, 100, 15, 0, 0.8f, 4f, 4f);
                break;
            case UnitCode.Slime:
                stat = new Stat(unitCode, "Slime", 20, 20, 5, 0, 1f, 0f, 1f);
                break;
        }
        return stat;
    }
}
