using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Float Reference")]
public class FloatReference : ScriptableObject
{
    public bool useConstant = true;
    public float constantValue;
    public FloatValue floatValue;

    public float Value
    {
        get { return useConstant ? constantValue : floatValue.value; }
        set
        {
            if (useConstant)
            {
                constantValue = value;
            }
            else
            {
                floatValue.value = value;
            }
        }
    }
}
