using UnityEngine;

[CreateAssetMenu(fileName = "WeaponShootEffect_", menuName = "Scriptable Objects/Weapons/Weapon Shoot Effect")]
public class WeaponShootEffectSO : ScriptableObject
{

    public Gradient colorGradient;

    public float duration = 0.50f;

    public float startParticleSize = 0.25f;

    public float startParticleSpeed = 3f;

    public float startLifetime = 0.5f;

    public int maxParticleNumber = 100;

    public int emissionRate = 100;

    public int burstParticleNumber = 20;

    public float effectGravity = -0.01f;

    public Sprite sprite;

    public Vector3 velocityOverLifetimeMin;

    public Vector3 velocityOverLifetimeMax;

    public GameObject weaponShootEffectPrefab;
}