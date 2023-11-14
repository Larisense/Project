using UnityEngine;

public class Ring : MonoBehaviour
{
    public int ringID; // 圆环的编号

    // 移动到指定坐标
    public void MoveToPosition(Vector3 newPosition)
    {
        transform.position = newPosition;
    }
}