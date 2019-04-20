﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum WeaponType
{
    SHIELD_AND_SWORD,
    AXE,
    SPEAR,
    GREAT_SWORD,
    NONE
};

public class BaseWeapon: MonoBehaviour,IItem,IPopable
{
    [SerializeField]ItemType _itemType = ItemType.NONE;
    [SerializeField]WeaponType _weaponType = WeaponType.NONE;
    [SerializeField]Sprite _Icon = null;
    [SerializeField]string _headerName = string.Empty;
    [SerializeField]string _description = string.Empty;
    [SerializeField]Vector3 _HoldingPos = Vector3.zero;

    public WeaponType weaponType{get{return _weaponType;}}
    public Vector3 HoldingPos{get{return _HoldingPos;}}
    public ItemType itemType{get{return _itemType;}}
    public Sprite Icon{get{return _Icon;}}
    public string description{get{return _description;}}
    public string headerName{get{return _headerName;}}
    public HitManager hitSystemManager{get;private set;}


    void Awake()
    {
        hitSystemManager = GetComponent<HitManager>();
    }
    public int GetNormalSteminaDeplete(int index)
    {
        return hitSystemManager.GetNormalHitSteminaDeplete(index);
    }
    public int GetHeavySteminaDeplete()
    {
        return hitSystemManager.GetHeavyHitSteminaDeplete();
    }
    public void SetTargetLayer(LayerMask mask)
    {
        hitSystemManager.SetTargetLayer(mask);
    }

    public void PopOut(Vector3 startPosition, Vector3 endPosition, float duration)
    {
    }
}
