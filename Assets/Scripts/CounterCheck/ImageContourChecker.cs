using System.Collections.Generic;
using UnityEngine;

public class ImageContourChecker : MonoBehaviour
{
	//public Texture2D imageTexture;
	public Collider2D specifiedContourCollider;
	public SpriteRenderer spriteRenderer;
	public float pointSpacing = 0.1f;
	public List<Vector2> outlinePoints;
	private void Start()
	{
		// ��ȡͼ��ı�Ե�㼯��
		//Vector2[] imageContourPoints = GetContourPoints(imageTexture);
		// ��ȡSprite�����������еĵ�
		Vector2[] outlinePoints = GetSpriteOutlinePoints();

		// �ڳ����л���������
		DrawOutlinePoints(outlinePoints);
		// �жϱ�Ե���Ƿ������ָ��������
		bool isContained = IsContourPointsContained(outlinePoints, specifiedContourCollider);

		Debug.Log("Is Contour Contained: " + isContained);
	}
	private Vector2[] GetSpriteOutlinePoints()
	{
		// ��ȡSprite�������߽��
		Vector2[] vertices = spriteRenderer.sprite.vertices;

		// �����֮��ļ��
		float spacing = pointSpacing / spriteRenderer.sprite.pixelsPerUnit;

		// ����������������б�
		outlinePoints = new List<Vector2>();

		// �����߽�㣬�������������б�
		foreach (Vector2 vertex in vertices)
		{
			// ���߽��ת��Ϊ��������
			Vector2 worldPosition = transform.TransformPoint(vertex);

			// ��ӵ��������б�
			outlinePoints.Add(worldPosition);

			// ��Ӽ���
			Vector2 direction = vertex.normalized;
			Vector2 spacingPoint = worldPosition + direction * spacing;
			outlinePoints.Add(spacingPoint);
			print(spacingPoint);
		}

		return outlinePoints.ToArray();
	}

	private void DrawOutlinePoints(Vector2[] points)
	{
		// ����������
		for (int i = 0; i < points.Length - 1; i++)
		{
			Debug.DrawLine(points[i], points[i + 1], Color.red);
		}
	}
	private bool IsContourPointsContained(Vector2[] outlinePoints, Collider2D contourCollider)
	{
		// �жϱ�Ե���Ƿ������ָ��������
		foreach (Vector2 point in outlinePoints)
		{
			if (!contourCollider.OverlapPoint(point))
			{
				print(false);
				return false;
			}
		}
		print(true);
		return true;
	}
}


