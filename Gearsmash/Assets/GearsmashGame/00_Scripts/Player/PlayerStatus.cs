using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystem.Status
{
    [System.Serializable]
    public class PlayerStatus : MonoBehaviour
    {
        [Header("Base Statistics")]
        public int Level;
        public bool IsAlive;
        public int XP;
        public int GoldBalance;
        [Header("Characteristics")]
        public Sprite DefaultSprite;
        public string NamePlayer;
        [Header("Status")]
        public int Life;
        public int DamageAttack;
        public float Speed;
        public int Armor;

    }
}

