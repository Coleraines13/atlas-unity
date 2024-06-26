using UnityEngine;

public class DissolveEffect : MonoBehaviour
{
    public Material dissolveMaterial;
    public float dissolveSpeed = 1.0f;

    private float dissolveThreshold = 0.0f;

    void Update()
    {
        dissolveThreshold += dissolveSpeed * Time.deltaTime;
        dissolveThreshold = Mathf.Clamp01(dissolveThreshold);

        dissolveMaterial.SetFloat("_DissolveThreshold", dissolveThreshold);
    }
}