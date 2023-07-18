using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
  public LineRenderer circleRenderer;

  public Transform targetTransform;
  public int resolution = 100;  // Résolution du cercle
  public float radius = 1f;     // Rayon du cercle
  public float width = 0.5f;     // Rayon du cercle

  void Start()
  {
    circleRenderer.startWidth = width;
    circleRenderer.endWidth = width;
  }

  private void Update()
  {
    DrawCircle();
  }

  void DrawCircle()
  {
    circleRenderer.loop = true;  // Cela ferme le cercle
    circleRenderer.positionCount = resolution;

    float angle = 0f;

    for (int i = 0; i < resolution; i++)
    {
      float x = radius * Mathf.Cos(angle);
      float y = radius * Mathf.Sin(angle);

      circleRenderer.SetPosition(i, new Vector3(x, 0.1f, y) + targetTransform.position);

      angle += 2f * Mathf.PI / resolution;
    }
  }
}
