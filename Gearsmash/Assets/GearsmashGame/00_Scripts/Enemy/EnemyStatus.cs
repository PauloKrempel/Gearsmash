using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemySystem.Status
{
    [CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy/Create New Enemy")]
    [System.Serializable]
    public class EnemyStatus : ScriptableObject
    {
        [Header("Base Statistics")]
        public int ID;
        public int Level;
        public bool IsAlive;
        [Header("Characteristics")]
        public Sprite DefaultSprite;
        public string NameEnemy;
        public TypeEnemy EnemyType;
        [Header("Status")]
        public int Life;
        public int DamageAttack;
        public int XP;
        public int GoldReward;
    }
}
public enum TypeEnemy
{
    Ranged,
    Meele,
    Boss
}
