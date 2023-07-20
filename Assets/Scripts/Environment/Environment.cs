using UnityEngine;

[DisallowMultipleComponent]
public class Environment : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    #region Validation

#if UNITY_EDITOR

    private void OnValidate()
    {
        HelperUtilities.ValidateCheckNullValue(this, nameof(spriteRenderer), spriteRenderer);
    }

#endif

    #endregion Validation

}