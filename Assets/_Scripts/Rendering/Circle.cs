using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
  public LineRenderer circleRenderer;
  public int resolution = 100;  // Résolution du cercle
  public float radius = 1f;     // Rayon du cercle
  public float width = 0.5f;     // Rayon du cercle

  private Transform ParentTransform;

  private void Awake()
  {
    ParentTransform = this.transform.parent;
  }

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
      float z = radius * Mathf.Sin(angle);

      circleRenderer.SetPosition(i, new Vector3(x,-0.5f, z) + ParentTransform.position);

      angle += 2f * Mathf.PI / resolution;
    }
  }
}
