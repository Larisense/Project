using UnityEngine;

public class GameController : MonoBehaviour
{
    // ����ÿ������Բ��λ������
    public Vector3[,] towerRingPositions = new Vector3[3, 3];
    public Ring[] rings; // Բ����������
    private Ring[,] towerRings = new Ring[3, 3]; // ���ڸ���ÿ�����ϵ�Բ��״̬

    void Start()
    {
        // ��ʼ������
        // ����ߵ�������
        towerRingPositions[0, 0] = new Vector3(-0.4649999f, -0.2805f, 0.465f); // �����������
        towerRingPositions[0, 1] = new Vector3(-0.4649999f, -0.2515f, 0.464f); // �м������
        towerRingPositions[0, 2] = new Vector3(-0.467f, -0.2225f, 0.465f);     // �����������

        // �м��������
        towerRingPositions[1, 0] = new Vector3(-0.4649999f, -0.28f, 0.908f);   // �����������
        towerRingPositions[1, 1] = new Vector3(-0.4649999f, -0.251f, 0.9069999f); // �м������
        towerRingPositions[1, 2] = new Vector3(-0.467f, -0.222f, 0.908f);       // �����������

        // ���ұߵ�������
        towerRingPositions[2, 0] = new Vector3(-0.4649999f, -0.28f, 1.326f);   // �����������
        towerRingPositions[2, 1] = new Vector3(-0.4649999f, -0.251f, 1.325f);   // �м������
        towerRingPositions[2, 2] = new Vector3(-0.467f, -0.222f, 1.326f);       // �����������

        // ��ʼ�� towerRings ���飬��������λ�ö�û��Բ��
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                towerRings[i, j] = null; // ��������λ�ö�û��Բ��
            }
        }
    }

    // �����İ�ť�����ʱ���ô˷���
    public void OnTowerButtonClicked(int towerIndex)
    {
        // ʵ���ƶ�Բ�����߼�
        MoveRing(towerIndex);
    }

    private void MoveRing(int towerIndex)
    {
        // ���ݵ�ǰ����Ϸ״̬ȷ���ƶ��ĸ�Բ��
        int ringToMove = DetermineRingToMove(towerIndex);
        if (ringToMove != -1)
        {
            int targetPositionIndex = CalculateTargetPositionIndex(towerIndex, ringToMove);
            Vector3 newPosition = towerRingPositions[towerIndex, targetPositionIndex];
            rings[ringToMove].MoveToPosition(newPosition);

            // ���� towerRings ���飬��ʾ��Ŀ��λ����Բ����
            towerRings[towerIndex, targetPositionIndex] = rings[ringToMove];
        }
    }

    private int DetermineRingToMove(int towerIndex)
    {
        // ʵ��ȷ���ĸ�Բ��Ӧ���ƶ����߼�
        // ʾ���������С�Ŀ��ƶ�Բ��
        for (int i = 0; i < 3; i++)
        {
            if (towerRings[towerIndex, i] != null)
            {
                return towerRings[towerIndex, i].ringID;
            }
        }
        return -1; // δ�ҵ����ƶ���Բ��
    }

    private int CalculateTargetPositionIndex(int towerIndex, int ringID)
    {
        // ʵ�ָ�������״̬��Բ�����������Բ����λ�õ��߼�
        // ʾ�������Ŀ��λ��Ϊ�գ�����Ŀ��λ������
        for (int i = 0; i < 3; i++)
        {
            if (towerRings[towerIndex, i] == null)
            {
                return i;
            }
        }
        return -1; // �޷��ƶ���Ŀ��λ��
    }

    // ��������...
}