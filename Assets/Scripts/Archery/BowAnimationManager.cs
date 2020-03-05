using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowAnimationManager : MonoBehaviour
{

    public SkinnedMeshRenderer renderer;
    public Transform Arrow;
    Vector3 StartPos;
    public float moveDistance;

    private void Awake()
    {
        StartPos = Arrow.position;
    }

    public void UpdateStrength(float strength, float MaxStrength)
    {
        renderer.SetBlendShapeWeight(0, (strength / MaxStrength) * 50);
        Arrow.position = StartPos + (Arrow.up * -1 * strength * moveDistance);
    }
}
