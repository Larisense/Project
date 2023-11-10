using UnityEngine;

public class VRButtonInteraction : MonoBehaviour
{
    private Renderer buttonRenderer; // ���o��Renderer�M��
    public Color highlightedColor = Color.red; // �����o���x�Еr���ɫ
    private Color originalColor; // ���o��ԭʼ�ɫ

    void Start()
    {
        buttonRenderer = GetComponent<Renderer>();
        if (buttonRenderer != null)
        {
            originalColor = buttonRenderer.material.color; // ����ԭʼ�ɫ
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("VRController"))
        {
            // VR�ֱ��ӽ����o����׃�ɫ
            buttonRenderer.material.color = highlightedColor;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("VRController"))
        {
            // VR�ֱ��h�x���o���֏�ԭʼ�ɫ
            buttonRenderer.material.color = originalColor;
        }
    }
}