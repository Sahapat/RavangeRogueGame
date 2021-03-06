﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemType
{
    EQUIPMENT,
    ITEM,
    NONE
};
public interface IItem
{
    ItemType itemType{get;}
    string description{get;}
    string headerName{get;}
    Sprite Icon{get;}
    Vector3 popOutChildPositionOffset{get;}
    Vector3 popOutChildRotationOffset{get;}
}
