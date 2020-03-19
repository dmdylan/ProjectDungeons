using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityInfoTest : MonoBehaviour
{
    public AbilityInfo abilityInfo;
    private MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        meshRenderer.material.color = abilityInfo.AbilityColor ;
        Debug.Log(abilityInfo.AbilityColor);
        Debug.Log(abilityInfo.AbilityDamageType);
        Debug.Log(abilityInfo.AbilityName);
    }
}
