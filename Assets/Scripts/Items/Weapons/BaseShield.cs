﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseShield : MonoBehaviour,IItem
{
    [SerializeField]ItemType _itemType = ItemType.NONE;
    [SerializeField]Sprite _Icon = null;
    [SerializeField]string _headerName = string.Empty;
    [SerializeField]string _description = string.Empty;
    [SerializeField]Vector3 _HoldingPos = Vector3.zero;
    [SerializeField]Vector3 _popOutChildPositionOffset = Vector3.zero;
    [SerializeField]Vector3 _popOutChildRotationOffset = Vector3.zero;
    

    public Vector3 HoldingPos{get{return _HoldingPos;}}
    public ItemType itemType{get{return _itemType;}}
    public Sprite Icon{get{return _Icon;}}
    public string description{get{return _description;}}
    public string headerName{get{return _headerName;}}

    public Vector3 popOutChildPositionOffset{get{return _popOutChildPositionOffset;}}

    public Vector3 popOutChildRotationOffset{get{return _popOutChildRotationOffset;}}
}
