using UnityEngine;

public class Ring : MonoBehaviour
{
    public int ringID; // Բ���ı��

    // �ƶ���ָ������
    public void MoveToPosition(Vector3 newPosition)
    {
        transform.position = newPosition;
    }
}