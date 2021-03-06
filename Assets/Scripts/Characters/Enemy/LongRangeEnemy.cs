﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRangeEnemy : MonoBehaviour, IAttackable
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] SightCheck enemySightCheck = null;
    [SerializeField] GameObject Y_Rotater = null;
    [SerializeField] GameObject Bullet = null;
    [SerializeField] Transform AttackPosition = null;
    [SerializeField] float coolDown = 5f;
    [SerializeField] Rigidbody[] destructRigid = null;
    [SerializeField] MeshCollider[] destructCollider = null;
    [SerializeField] AudioClip[] temp = null;

    public Health CharacterHP { get; private set; }

    public bool isBlocking { get; private set; }

    private DamageMaterial m_takedamageMaterial = null;
    private float coolDownCounter = 0f;
    private bool isDead = false;

    private Vector3 startPosition = Vector3.zero;
    private Vector3 startRotation = Vector3.zero;

    private AudioSource m_audioSource = null;

    void Awake()
    {
        CharacterHP = new Health(maxHealth);
        m_takedamageMaterial = GetComponent<DamageMaterial>();
        m_audioSource = GetComponent<AudioSource>();
        startPosition = transform.position;
        startRotation = transform.eulerAngles;
    }
    void Start()
    {
        foreach (var i in destructCollider)
        {
            i.enabled = false;
        }
        foreach (var i in destructRigid)
        {
            i.isKinematic = true;
            i.useGravity = false;
        }
    }
    void FixedUpdate()
    {
        if (isDead) return;

        if (enemySightCheck.targetInSight)
        {
            transform.LookAt(new Vector3(enemySightCheck.targetInSight.transform.position.x, transform.position.y, enemySightCheck.targetInSight.transform.position.z));
            Y_Rotater.transform.LookAt(enemySightCheck.targetInSight.transform);

            if (coolDownCounter <= Time.time)
            {
                coolDownCounter = Time.time + coolDown;
                var bullet = Instantiate(Bullet, AttackPosition);
                bullet.transform.localPosition = Vector3.zero;
                bullet.transform.localRotation = Quaternion.identity;
                bullet.transform.parent = null;
                var direction = enemySightCheck.targetInSight.transform.position - AttackPosition.position;
                Quaternion rotation = Quaternion.LookRotation(direction);
                bullet.transform.rotation = rotation;
                m_audioSource.PlayOneShot(temp[0]);
                Destroy(bullet.gameObject, coolDown);
            }
        }
        else
        {
            transform.position = startPosition;
            transform.rotation = Quaternion.Euler(startRotation);
        }
    }
    public void TakeDamage(int damage)
    {
        CharacterHP.RemoveHP(damage);
        m_takedamageMaterial.TakeDamageMaterialActive(CharacterHP.HP, CharacterHP.MaxHP);
        if (CharacterHP.HP <= 0)
        {
            foreach (var i in destructCollider)
            {
                i.enabled = true;
            }
            foreach (var i in destructRigid)
            {
                i.isKinematic = false;
                i.useGravity = true;
            }
            isDead= true;
            m_audioSource.PlayOneShot(temp[1]);
            m_takedamageMaterial.FadeOut(4f);
        }
    }

    public void TakeDamage(int damage, Vector3 forceToAdd)
    {
        CharacterHP.RemoveHP(damage);
        m_takedamageMaterial.TakeDamageMaterialActive(CharacterHP.HP, CharacterHP.MaxHP);
        if (CharacterHP.HP <= 0)
        {
            foreach (var i in destructCollider)
            {
                i.enabled = true;
            }
            foreach (var i in destructRigid)
            {
                i.isKinematic = false;
                i.useGravity = true;
            }
            isDead= true;
            m_takedamageMaterial.FadeOut(4f);
        }
    }
}
