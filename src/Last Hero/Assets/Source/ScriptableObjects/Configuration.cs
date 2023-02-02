using LastHero.ScriptableObjects.Interfaces;
using Mirror;
using UnityEditor;
using UnityEngine;

namespace LastHero.ScriptableObjects
{
    [CreateAssetMenu]
    public class Configuration : ScriptableObject, IConfiguration
    {
        [SerializeField] private SceneAsset _startScene;

        [SerializeField] private NetworkIdentity[] _networkObjects;

        public SceneAsset StartScene => _startScene;
    }
}