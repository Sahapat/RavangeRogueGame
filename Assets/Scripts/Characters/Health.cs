﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Health
{
    public int HP{get;private set;}
    public int MaxHP{get; private set;}
    public delegate void _Func();
    public delegate void _FuncValue(int value);

    public event _FuncValue OnHPChanged;
    public event _Func OnResetHP;

    public Health(int maxHealth)
    {
        SetMaxHP(maxHealth);
        ResetHP();
    }
    ~Health()
    {
        OnHPChanged = null;
        OnResetHP = null;
    }
    public void RemoveHP(int value)
    {
        HP -= value;
        HP = Mathf.Clamp(HP,0,MaxHP);
        _FireEvent_OnHPChanged();
    }
    public void AddHP(int value)
    {
        HP += value;
        HP = Mathf.Clamp(HP,0,MaxHP);
        _FireEvent_OnHPChanged();
    }
    public void SetMaxHP(int value)
    {
        MaxHP = value;
        HP = MaxHP;
        _FireEvent_OnHPChanged();
    }
    public void ResetHP()
    {
        HP = MaxHP;
        _FireEvent_OnResetHP();
    }
    void _FireEvent_OnResetHP()
    {
        OnResetHP?.Invoke();
    }
    void _FireEvent_OnHPChanged()
    {
        OnHPChanged?.Invoke(HP);
    }
}