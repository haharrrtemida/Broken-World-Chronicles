using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Scene")]
public class LevelSO : ScriptableObject
{
    [SerializeField] private SceneAsset[] _locationsOfLevel;

    public SceneAsset[] LocationsOfLevel => _locationsOfLevel;

    [SerializeField] private string _levelName;
}
