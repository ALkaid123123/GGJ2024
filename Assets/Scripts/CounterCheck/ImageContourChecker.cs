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
		// 获取图像的边缘点集合
		//Vector2[] imageContourPoints = GetContourPoints(imageTexture);
		// 获取Sprite的轮廓上所有的点
		Vector2[] outlinePoints = GetSpriteOutlinePoints();

		// 在场景中绘制轮廓点
		DrawOutlinePoints(outlinePoints);
		// 判断边缘点是否包含在指定轮廓内
		bool isContained = IsContourPointsContained(outlinePoints, specifiedContourCollider);

		Debug.Log("Is Contour Contained: " + isContained);
	}
	private Vector2[] GetSpriteOutlinePoints()
	{
		// 获取Sprite的轮廓边界点
		Vector2[] vertices = spriteRenderer.sprite.vertices;

		// 计算点之间的间距
		float spacing = pointSpacing / spriteRenderer.sprite.pixelsPerUnit;

		// 创建保存轮廓点的列表
		outlinePoints = new List<Vector2>();

		// 遍历边界点，并加入轮廓点列表
		foreach (Vector2 vertex in vertices)
		{
			// 将边界点转换为世界坐标
			Vector2 worldPosition = transform.TransformPoint(vertex);

			// 添加到轮廓点列表
			outlinePoints.Add(worldPosition);

			// 添加间距点
			Vector2 direction = vertex.normalized;
			Vector2 spacingPoint = worldPosition + direction * spacing;
			outlinePoints.Add(spacingPoint);
			print(spacingPoint);
		}

		return outlinePoints.ToArray();
	}

	private void DrawOutlinePoints(Vector2[] points)
	{
		// 绘制轮廓点
		for (int i = 0; i < points.Length - 1; i++)
		{
			Debug.DrawLine(points[i], points[i + 1], Color.red);
		}
	}
	private bool IsContourPointsContained(Vector2[] outlinePoints, Collider2D contourCollider)
	{
		// 判断边缘点是否包含在指定轮廓内
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


