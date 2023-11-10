using UnityEngine;

public class VRButtonPress : MonoBehaviour
{
    public TextMesh displayText; // ������ʾ�������� TextMesh

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("VRController"))
        {
            // VR �ֱ��ӽ���ť
            GetComponent<Renderer>().material.color = Color.red; // ��ѡ���ı䰴ť��ɫ
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("VRController"))
        {
            // VR �ֱ��뿪��ť
            GetComponent<Renderer>().material.color = Color.white; // ��ѡ���ָ���ť��ɫ
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("VRController") && Input.GetButtonDown("Fire1")) // ���� Fire1 �� VR �ֱ��İ���
        {
            // VR �ֱ������ť
            TextMesh buttonText = GetComponent<TextMesh>();
            if (buttonText != null && displayText != null)
            {
                displayText.text = buttonText.text; // ������ʾ�ı�
            }
        }
    }
}