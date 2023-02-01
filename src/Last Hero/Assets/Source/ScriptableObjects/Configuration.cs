using LastHero.ScriptableObjects.Interfaces;
using UnityEditor;
using UnityEngine;

namespace LastHero.ScriptableObjects
{
    [CreateAssetMenu]
    public class Configuration : ScriptableObject, IConfiguration
    {
        [SerializeField] private SceneAsset _startScene;

        public SceneAsset StartScene => _startScene;
    }
}