using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDetails_", menuName = "Scriptable Objects/Player/Player Details")]
public class PlayerDetailsSO : ScriptableObject
{
    public string playerCharacterName;
    public GameObject playerPrefab;
    public RuntimeAnimatorController runtimeAnimatorController;
    public int playerHealthAmount;
    public WeaponDetailsSO startingWeapon;
    public List<WeaponDetailsSO> startingWeaponList;
    public Sprite playerMiniMapIcon;
    public Sprite playerHandSprite;

    public bool isImmuneAfterHit = false;
    public float hitImmunityTime;
}
