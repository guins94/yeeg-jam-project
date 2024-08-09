using UnityEngine;

[CreateAssetMenu(fileName = "ShakeSettings", menuName = "Shake", order = 1)]
public class ShakeSettings : ScriptableObject
{
   public float intensity = 0;
   public float duration = 0;
   public float frequency = 0;
}
