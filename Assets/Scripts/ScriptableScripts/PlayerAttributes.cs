using UnityEngine;

[CreateAssetMenu(fileName = "Player Attribute", menuName = "Add Player Attributes", order = 1)]
public class PlayerAttributes : ScriptableObject
{
    [Header("PLAYER STATS")]

    [Space(5)]

    [Tooltip("PLAYER MAX HEALTH")]
    [SerializeField] int _healthPoints;
    public int HealthPoints { get { return _healthPoints; } }

    [Tooltip("ATTACK STRENGTH")]
    [SerializeField] float _atkStrength;
    public float AtkStrength { get { return _atkStrength; } }

    [Tooltip("ARMOR TO RESIST ATTACKS")]
    [SerializeField] float _defenseArmor;
    public float DefenseArmor { get { return _defenseArmor; } }

    [Tooltip("MOVE SPEED")]
    [SerializeField] float _moveSpeed;
    public float MoveSpeed { get { return _moveSpeed; } }
}
