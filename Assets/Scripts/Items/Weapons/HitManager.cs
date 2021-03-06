﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{
    [SerializeField]BaseHitSystem[] NormalHits = null;
    [SerializeField]BaseHitSystem HeavyHit = null;

    private HitSystem[] normalHits = null;
    private HeavyHit heavyHit = null;

    void Start()
    {
        normalHits = new HitSystem[NormalHits.Length];

        for(int i=0;i<normalHits.Length;i++)
        {
            normalHits[i] = NormalHits[i].gameObject.GetComponent<HitSystem>();
        }
        heavyHit = HeavyHit.gameObject.GetComponent<HeavyHit>();
    }

    public int GetNormalHitSteminaDeplete(int index)
    {
        return normalHits[index].steminaDeplete;
    }
    public int GetHeavyHitSteminaDeplete()
    {
        return heavyHit.steminaDeplete;
    }
    public void SetTargetLayer(LayerMask mask)
    {
        foreach(var i in normalHits)
        {
            i.SetTargetLayer(mask);
        }
        heavyHit.SetTargetLayer(mask);
    }
    public void ActiveNormalHit(int index)
    {
        NormalHits[index].ActiveHit();
    }
    public void ActiveHeavyHit()
    {
        HeavyHit.ActiveHit();
    }
    public void CancelNormalHit(int index)
    {
        NormalHits[index].CancelHit();
    }
    public void CancelHeavyHit()
    {
        HeavyHit.CancelHit();
    }
    public void CancelAllHit()
    {
        CancelHeavyHit();
        for(int i=0;i<NormalHits.Length;i++)
        {
            CancelNormalHit(i);
        }
    }
}
