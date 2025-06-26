using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class TimingSliderController : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Image fillImage;

    private float inputCooldown = 0f;
    [SerializeField] private float wrongPressDelay = 0.5f; //half a second delay after wrong press

    private float speed = 1f;
    private bool increasing = true;
    private bool isActive = false;

    private AttackData.TimingZone[] activeZones;
    private bool[] zonesHitFlags;  //Track which zones were hit already

    [SerializeField] private InputActionReference confirmAction;

    public System.Action<int> OnZoneHitsComplete; //Total hits after finish

    private void OnEnable()
    {
        if (confirmAction != null)
            confirmAction.action.Enable();
    }

    private void OnDisable()
    {
        if (confirmAction != null)
            confirmAction.action.Disable();
    }

    public void StartTiming(float scrollSpeed, AttackData.TimingZone[] zones)
    {
        isActive = true;
        slider.value = 0f;
        increasing = true;
        speed = scrollSpeed;
        activeZones = zones;
        zonesHitFlags = new bool[zones.Length]; //Reset hit tracking
    }

    private void StopTiming()
    {
        isActive = false;
        int totalHits = 0;
        foreach (bool hit in zonesHitFlags)
            if (hit) totalHits++;
        OnZoneHitsComplete?.Invoke(totalHits); //Calls HandleTimingResults in PlayerCombat
    }

    private void Update()
    {
        if (!isActive) return;

        float step = speed * Time.deltaTime;
        slider.value += increasing ? step : -step; //Logic also allows for bar to bounce back and drain

        if (slider.value >= 1f)
        {
            slider.value = 1f;
            increasing = false;
            StopTiming();
            return;
        }
        else if (slider.value <= 0f)
        {
            slider.value = 0f;
            increasing = true;
        }

        //Track timing zone
        bool inUnhitZone = false;
        bool inHitZone = false;

        for (int i = 0; i < activeZones.Length; i++)
        {
            var zone = activeZones[i];
            if (slider.value >= zone.min && slider.value <= zone.max)
            {
                if (zonesHitFlags[i])
                    inHitZone = true;
                else
                    inUnhitZone = true;
            }
        }

        //Color logic
        if (inHitZone)
            fillImage.color = Color.Lerp(Color.green, Color.white, 0.6f); //Brighter green
        else if (inUnhitZone)
            fillImage.color = Color.green; //Normal green
        else
            fillImage.color = Color.red;

        //Reduce failed timing timer
        if (inputCooldown > 0f)
            inputCooldown -= Time.deltaTime;

        //Only accept input if not in timeout 
        if (inputCooldown <= 0f && confirmAction != null && confirmAction.action.triggered)
        {
            bool hitAnyZone = false;

            for (int i = 0; i < activeZones.Length; i++)
            {
                var zone = activeZones[i];
                if (!zonesHitFlags[i] && slider.value >= zone.min && slider.value <= zone.max)
                {
                    zonesHitFlags[i] = true;
                    Debug.Log($"Zone {i + 1} hit!");
                    hitAnyZone = true;
                    break;
                }
            }

            if (!hitAnyZone)
            {
                inputCooldown = wrongPressDelay;
                Debug.Log("Wrong timing, you suck! Cooldown started.");
            }
        }
    }
}