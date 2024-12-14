using UnityEngine;

namespace Kivoices.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Kivoices/ScriptableObject/PlayerData")]
    public class PlayerDataSO : ScriptableObject
    {
        [Header("Player Data")]
        [SerializeField] private int _initialPlayerHealth;

        public int GetInitialPlayerHealth()
        {
            return _initialPlayerHealth;
        }
    }
}