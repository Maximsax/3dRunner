using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Scriptable Objects/GameSettings")]
public class GameSettings : ScriptableObject
{
    public float forwardSpeed = 5f;
    public float strafeSpeed = 7f;
    public float jumpForce = 7f;
}
