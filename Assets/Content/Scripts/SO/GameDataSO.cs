using Content.Scripts.PlayerVechile;
using UnityEngine;
namespace Content.Scripts.SO
{
    [CreateAssetMenu(fileName = "GameDataSO", menuName = "GameData/GameDataSO", order = 0)]
    public class GameDataSO : ScriptableObject
    {
        [field: SerializeField] public Player PlayerPrefab { get; private set; }
        [field: SerializeField] public string GameSceneName { get; private set; }
    }
}
