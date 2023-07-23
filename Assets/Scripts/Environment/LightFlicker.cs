using UnityEngine;
using UnityEngine.Rendering.Universal;

[DisallowMultipleComponent]
public class LightFlicker : MonoBehaviour
{
    private Light2D light2D;
    [SerializeField] private float lightIntensityMin;
    [SerializeField] private float lightIntensityMax;
    [SerializeField] private float lightFlickerTimeMin;
    [SerializeField] private float lightFlickerTimeMax;
    private float lightFlickerTimer;

    private void Awake()
    {
        // Load components
        light2D = GetComponentInChildren<Light2D>();
    }

    private void Start()
    {
        lightFlickerTimer = Random.Range(lightFlickerTimeMin, lightFlickerTimeMax);
    }

    private void Update()
    {
        if (light2D == null) return;

        lightFlickerTimer -= Time.deltaTime;

        if (lightFlickerTimer < 0f)
        {
            lightFlickerTimer = Random.Range(lightFlickerTimeMin, lightFlickerTimeMax);

            RandomiseLightIntensity();
        }
    }

    private void RandomiseLightIntensity()
    {
        light2D.intensity = Random.Range(lightIntensityMin, lightIntensityMax);
    }
}