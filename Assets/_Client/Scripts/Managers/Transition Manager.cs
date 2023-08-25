using Artemida.Tools;
using AYellowpaper.SerializedCollections;
using UnityEngine;


public class TransitionManager : PersistentSingleton<TransitionManager>
{
    [SerializedDictionary("Root", "Point")]
    [SerializeField] private SerializedDictionary<Transition, Transform> _transitions;

    public void Initialize()
    {
        
    }
}