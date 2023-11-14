using UnityEngine;

public class GameController : MonoBehaviour
{
    // 定义每个塔的圆环位置坐标
    public Vector3[,] towerRingPositions = new Vector3[3, 3];
    public Ring[] rings; // 圆环对象数组
    private Ring[,] towerRings = new Ring[3, 3]; // 用于跟踪每个塔上的圆环状态

    void Start()
    {
        // 初始化坐标
        // 最左边的塔坐标
        towerRingPositions[0, 0] = new Vector3(-0.4649999f, -0.2805f, 0.465f); // 最下面的坐标
        towerRingPositions[0, 1] = new Vector3(-0.4649999f, -0.2515f, 0.464f); // 中间的坐标
        towerRingPositions[0, 2] = new Vector3(-0.467f, -0.2225f, 0.465f);     // 最上面的坐标

        // 中间的塔坐标
        towerRingPositions[1, 0] = new Vector3(-0.4649999f, -0.28f, 0.908f);   // 最下面的坐标
        towerRingPositions[1, 1] = new Vector3(-0.4649999f, -0.251f, 0.9069999f); // 中间的坐标
        towerRingPositions[1, 2] = new Vector3(-0.467f, -0.222f, 0.908f);       // 最上面的坐标

        // 最右边的塔坐标
        towerRingPositions[2, 0] = new Vector3(-0.4649999f, -0.28f, 1.326f);   // 最下面的坐标
        towerRingPositions[2, 1] = new Vector3(-0.4649999f, -0.251f, 1.325f);   // 中间的坐标
        towerRingPositions[2, 2] = new Vector3(-0.467f, -0.222f, 1.326f);       // 最上面的坐标

        // 初始化 towerRings 数组，假设所有位置都没有圆环
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                towerRings[i, j] = null; // 假设所有位置都没有圆环
            }
        }
    }

    // 当塔的按钮被点击时调用此方法
    public void OnTowerButtonClicked(int towerIndex)
    {
        // 实现移动圆环的逻辑
        MoveRing(towerIndex);
    }

    private void MoveRing(int towerIndex)
    {
        // 根据当前的游戏状态确定移动哪个圆环
        int ringToMove = DetermineRingToMove(towerIndex);
        if (ringToMove != -1)
        {
            int targetPositionIndex = CalculateTargetPositionIndex(towerIndex, ringToMove);
            Vector3 newPosition = towerRingPositions[towerIndex, targetPositionIndex];
            rings[ringToMove].MoveToPosition(newPosition);

            // 更新 towerRings 数组，表示在目标位置有圆环了
            towerRings[towerIndex, targetPositionIndex] = rings[ringToMove];
        }
    }

    private int DetermineRingToMove(int towerIndex)
    {
        // 实现确定哪个圆环应该移动的逻辑
        // 示例：检查最小的可移动圆环
        for (int i = 0; i < 3; i++)
        {
            if (towerRings[towerIndex, i] != null)
            {
                return towerRings[towerIndex, i].ringID;
            }
        }
        return -1; // 未找到可移动的圆环
    }

    private int CalculateTargetPositionIndex(int towerIndex, int ringID)
    {
        // 实现根据塔的状态和圆环编号来计算圆环新位置的逻辑
        // 示例：如果目标位置为空，返回目标位置索引
        for (int i = 0; i < 3; i++)
        {
            if (towerRings[towerIndex, i] == null)
            {
                return i;
            }
        }
        return -1; // 无法移动到目标位置
    }

    // 其他方法...
}