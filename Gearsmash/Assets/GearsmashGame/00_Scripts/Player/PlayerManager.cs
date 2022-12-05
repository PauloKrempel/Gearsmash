using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystem.Manager
{
    using Status;
    public class PlayerManager : Singleton<PlayerManager>
    {
        public GameObject PlayerPosition;
        [SerializeField] private PlayerStatus _playerStatus = new PlayerStatus();
        public int TakeDamage(int damage)
        {
            int EndDamage = damage - _playerStatus.Armor;
            return EndDamage;
        }

        public void TesteString()
        {
            Debug.Log("Teste de mensagem");
        }
    }
}

