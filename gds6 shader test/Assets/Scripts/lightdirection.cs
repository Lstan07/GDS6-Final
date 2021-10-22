using UnityEngine;

[ExecuteInEditMode]
public class lightdirection : MonoBehaviour
{

    void Update()
    {
        Shader.SetGlobalVector("_LightDirectionVec", -transform.forward);

    }
}