// 14.11.2025 AI-Tag
// This was created with the help of Assistant, a Unity Artificial Intelligence product.

using UnityEngine;

public class ChangeBallColor : MonoBehaviour
{
    public Color newColor = Color.yellow; // Set the desired color here

    void Start()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            Material material = meshRenderer.material;
            material.color = newColor;
        }
        else
        {
            Debug.LogError("MeshRenderer component not found on the Ball object.");
        }
    }
}
