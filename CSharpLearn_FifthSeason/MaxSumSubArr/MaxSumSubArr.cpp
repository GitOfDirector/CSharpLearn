// MaxSumSubArr.cpp : �������̨Ӧ�ó������ڵ㡣
//

#include "stdafx.h"
#include <iostream>

using namespace std;

struct PositioASum
{
	int low;
	int high;
	int sum;
};

//Ѱ�Ұ����е�λ�õ���������麯��
PositioASum MaxCrossingSubarray(int a[], int low, int mid, int high)
{
	//���е���ߵ����ֵ�����λ��
	int maxLeft;//��¼��ߵ����λ��
	int maxSumLeft = -10000;//��¼��ߵ�����
	int sumLeft = 0;
	for (int i = mid; i >= low; i--)
	{
		sumLeft += a[i];
		if (sumLeft > maxSumLeft)
		{
			maxSumLeft = sumLeft;
			maxLeft = i;
		}
	}

	//���е��ұߵ����ֵ�����λ��
	int maxRight = mid + 1;//��¼�ұߵ����λ��
	int maxSumRight = -10000;//��¼�ұߵ�����
	int sumRight = 0;//��¼�ұ������еĺ�
	for (int i = mid + 1; i <= high; i++)
	{
		sumRight += a[i];
		if (sumRight > maxSumRight)
		{
			maxSumRight = sumRight;
			maxRight = i;
		}
	}

	cout << maxLeft << "===" << maxRight << "~~~" <<
		maxSumLeft << "___" << maxSumRight << endl;

	PositioASum ps;
	ps.low = maxLeft;
	ps.high = maxRight;
	ps.sum = maxSumLeft + maxSumRight;
	return ps;
}

//���η�
PositioASum FindMaxSubArray(int a[], int low, int high)
{
	if (low == high)
	{
		PositioASum ps;
		ps.low = low;
		ps.high = high;
		ps.sum = a[low];
		return ps;
	}
	else
	{
		int mid = (low + high) / 2;
		PositioASum left = FindMaxSubArray(a, low, mid);
		PositioASum right = FindMaxSubArray(a, mid + 1, high);
		PositioASum cross = MaxCrossingSubarray(a, low, mid, high);
		if (left.sum >= cross.sum && left.sum >= right.sum)
		{
			return left;
		}
		else if (right.sum >= left.sum && right.sum >= cross.sum)
		{
			return right;
		}
		else{
			return cross;
		}
	}
}


int _tmain(int argc, _TCHAR* argv[])
{
	/*int arr[8] = { -1, 0, 0, 0, -1 };
	PositioASum result = FindMaxSubArray(arr, 0, 4);*/

	//int priceArray[] = { 1, 2, 3, 4, -2, 2, 4, 6, 8, 6, 4, 2, 3, 4, 5, 6 };
	int priceArray[] = { 1, 1, 1, -6, 4, 2, 2, 2, -2, -2, -2, 1, 1, 1, 1 };
	PositioASum result = FindMaxSubArray(priceArray, 0, 14);

	printf("�������ʼ�±� %d �����±� %d ������ %d", result.low, result.high, result.sum);//�������ӡ����
	getchar();

	return 0;
}

