using UnityEngine;

public class VRButtonInteraction : MonoBehaviour
{
    private Renderer buttonRenderer; // 按鈕的Renderer組件
    public Color highlightedColor = Color.red; // 當按鈕被選中時的顏色
    private Color originalColor; // 按鈕的原始顏色

    void Start()
    {
        buttonRenderer = GetComponent<Renderer>();
        if (buttonRenderer != null)
        {
            originalColor = buttonRenderer.material.color; // 保存原始顏色
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("VRController"))
        {
            // VR手柄接近按鈕，改變顏色
            buttonRenderer.material.color = highlightedColor;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("VRController"))
        {
            // VR手柄遠離按鈕，恢復原始顏色
            buttonRenderer.material.color = originalColor;
        }
    }
}