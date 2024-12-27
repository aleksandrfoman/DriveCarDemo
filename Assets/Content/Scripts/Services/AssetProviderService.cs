using Content.Scripts.SO;
using UnityEngine;

namespace Content.Scripts.Services
{
    public class AssetProviderService : MonoBehaviour
    {
        [field: SerializeField] public GameDataSO GameData { get; private set; }
    }
}