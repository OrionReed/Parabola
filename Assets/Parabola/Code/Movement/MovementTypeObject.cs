using UnityEngine;

[CreateAssetMenu(fileName = "New Movement Type", menuName = "Parabola/New Movement Type")]

[System.Serializable]
public class MovementTypeObject : ScriptableObject
{

    [HideInInspector]
    public string ForceActors;

    public ForceMode2D ForceMode;
    public float ForceApplied;
    public float MaxSpeed;
    public bool WhileGrounded;
    public int Timeout;
}
