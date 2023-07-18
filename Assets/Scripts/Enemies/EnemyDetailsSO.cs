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

    #region Validation
#if UNITY_EDITOR
    // Validate the scriptable object details entered
    private void OnValidate()
    {
        HelperUtilities.ValidateCheckEmptyStrings(this, nameof(enemyName), enemyName);
        HelperUtilities.ValidateCheckNullValue(this, nameof(enemyPrefab), enemyPrefab);
        HelperUtilities.ValidateCheckPositiveValue(this, nameof(chaseDistance), chaseDistance, false);
    }

#endif
    #endregion

}