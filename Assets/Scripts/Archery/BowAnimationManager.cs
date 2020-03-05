using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowAnimationManager : MonoBehaviour
{

    public SkinnedMeshRenderer Bow;
    public SkinnedMeshRenderer Arrow;


    public void UpdateStrength(float strength, float MaxStrength)
    {
        Bow.SetBlendShapeWeight(0, (strength / MaxStrength) * 100);
        Arrow.SetBlendShapeWeight(0, (strength / MaxStrength) * 100);
    }
}
