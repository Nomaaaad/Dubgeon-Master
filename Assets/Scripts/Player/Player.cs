using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


#region REQUIRE COMPONENTS
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(SortingGroup))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(IdleEvent))]
[RequireComponent(typeof(Idle))]
[RequireComponent(typeof(AimWeaponEvent))]
[RequireComponent(typeof(AimWeapon))]
[RequireComponent(typeof(SetActiveWeaponEvent))]
[RequireComponent(typeof(FireWeaponEvent))]
[RequireComponent(typeof(FireWeapon))]
[RequireComponent(typeof(ActiveWeapon))]
[RequireComponent(typeof(PlayerControl))]
[RequireComponent(typeof(AnimatePlayer))]
[RequireComponent(typeof(ReloadWeaponEvent))]
[RequireComponent(typeof(ReloadWeapon))]
[RequireComponent(typeof(WeaponReloadedEvent))]
[RequireComponent(typeof(MovementToPositionEvent))]
[RequireComponent(typeof(MovementToPosition))]
[RequireComponent(typeof(MovementByVelocityEvent))]
[RequireComponent(typeof(MovementByVelocity))]
[DisallowMultipleComponent]
#endregion REQUIRE COMPONENTS
public class Player : MonoBehaviour
{
    [HideInInspector] public PlayerDetailsSO playerDetails;
    [HideInInspector] public Health health;
    [HideInInspector] public IdleEvent idleEvent;
    [HideInInspector] public AimWeaponEvent aimWeaponEvent;
    [HideInInspector] public MovementByVelocityEvent movementByVelocityEvent;
    [HideInInspector] public MovementToPositionEvent movementToPositionEvent;
    [HideInInspector] public SetActiveWeaponEvent setActiveWeaponEvent;
    [HideInInspector] public ActiveWeapon activeWeapon;
    [HideInInspector] public FireWeaponEvent fireWeaponEvent;
    [HideInInspector] public WeaponFiredEvent weaponFiredEvent;
    [HideInInspector] public ReloadWeaponEvent reloadWeaponEvent;
    [HideInInspector] public WeaponReloadedEvent weaponReloadedEvent;
    [HideInInspector] public SpriteRenderer spriteRenderer;
    [HideInInspector] public Animator animator;

    public List<Weapon> weaponList = new List<Weapon>();


    private void Awake()
    {
        health = GetComponent<Health>();
        idleEvent = GetComponent<IdleEvent>();
        aimWeaponEvent = GetComponent<AimWeaponEvent>();
        movementByVelocityEvent = GetComponent<MovementByVelocityEvent>();
        movementToPositionEvent = GetComponent<MovementToPositionEvent>();
        setActiveWeaponEvent = GetComponent<SetActiveWeaponEvent>();
        activeWeapon = GetComponent<ActiveWeapon>();
        fireWeaponEvent = GetComponent<FireWeaponEvent>();
        weaponFiredEvent = GetComponent<WeaponFiredEvent>();
        reloadWeaponEvent = GetComponent<ReloadWeaponEvent>();
        weaponReloadedEvent = GetComponent<WeaponReloadedEvent>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    public void Initialize(PlayerDetailsSO playerDetails)
    {
        this.playerDetails = playerDetails;

        CreatePlayerStartingWeapons();

        SetPlayerHealth();
    }

    /// <summary>
    /// Set the player starting weapon
    /// </summary>
    private void CreatePlayerStartingWeapons()
    {
        // Clear list
        weaponList.Clear();

        foreach (WeaponDetailsSO weaponDetails in playerDetails.startingWeaponList)
        {
            AddWeaponToPlayer(weaponDetails);
        }
    }

    private void SetPlayerHealth()
    {
        health.SetStartingHealth(playerDetails.playerHealthAmount);
    }

    /// <summary>
    /// Add a weapon to the player weapon dictionary
    /// </summary>
    public Weapon AddWeaponToPlayer(WeaponDetailsSO weaponDetails)
    {
        Weapon weapon = new Weapon() { weaponDetails = weaponDetails, weaponReloadTimer = 0f, weaponClipRemainingAmmo = weaponDetails.weaponClipAmmoCapacity, weaponRemainingAmmo = weaponDetails.weaponAmmoCapacity, isWeaponReloading = false };

        weaponList.Add(weapon);

        weapon.weaponListPosition = weaponList.Count;

        setActiveWeaponEvent.CallSetActiveWeaponEvent(weapon);

        return weapon;

    }
}
