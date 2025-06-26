using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Attack Data")]
public class AttackData : ScriptableObject
{
    public string attackName = "New Attack";
    public int baseDamage = 5;
    public int bonusPerZoneHit = 5;

    [Range(0.1f, 5f)] public float scrollSpeed = 1f;

    [System.Serializable]
    public struct TimingZone
    {
        [Range(0f, 1f)] public float min;
        [Range(0f, 1f)] public float max;
    }

    public TimingZone[] timingZones;
}