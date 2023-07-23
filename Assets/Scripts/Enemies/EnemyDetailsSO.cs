using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDetails_", menuName = "Scriptable Objects/Enemy/EnemyDetails")]
public class EnemyDetailsSO : ScriptableObject
{
    public string enemyName;
    public float chaseDistance = 50f;

    public Material enemyStandardMaterial;

    public float enemyMaterializeTime;

    public Shader enemyMaterializeShader;
    [ColorUsage(true, true)]

    public Color enemyMaterializeColor;

    public GameObject enemyPrefab;

    public WeaponDetailsSO enemyWeapon;

    public float firingIntervalMin = 0.1f;

    public float firingIntervalMax = 1f;

    public float firingDurationMin = 1f;

    public float firingDurationMax = 2f;

    public bool firingLineOfSightRequired;

    public EnemyHealthDetails[] enemyHealthDetailsArray;
    public bool isImmuneAfterHit = false;
    public float hitImmunityTime;

    public bool isHealthBarDisplayed = false;
}