using UnityEngine;

[CreateAssetMenu(fileName = "ManagersPrefabsScriptableObject", menuName = "Thirtwo/ScriptableObjects/ManagersSO")]
public class ManagersSO : ScriptableObject
{
    [field: Header("Prefabs")]
    [field: SerializeField] public CoroutineHandler CoroutineHandler { get; private set; }
}
