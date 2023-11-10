using UnityEngine;

public class VRButtonPress : MonoBehaviour
{
    public TextMesh displayText; // 用于显示点击结果的 TextMesh

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("VRController"))
        {
            // VR 手柄接近按钮
            GetComponent<Renderer>().material.color = Color.red; // 可选：改变按钮颜色
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("VRController"))
        {
            // VR 手柄离开按钮
            GetComponent<Renderer>().material.color = Color.white; // 可选：恢复按钮颜色
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("VRController") && Input.GetButtonDown("Fire1")) // 假设 Fire1 是 VR 手柄的按键
        {
            // VR 手柄点击按钮
            TextMesh buttonText = GetComponent<TextMesh>();
            if (buttonText != null && displayText != null)
            {
                displayText.text = buttonText.text; // 更新显示文本
            }
        }
    }
}