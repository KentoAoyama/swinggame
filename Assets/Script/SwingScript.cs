using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingScript : MonoBehaviour
{
	[SerializeField] Transform m_point = default;

	public float m_speed = 1.0f;
	public float circle_radius = 1.0f;

    private void Update()
    {
		Circle();
    }
    void Circle()
	{
		Vector2 pos = transform.position;

		float rad = m_speed * Mathf.Rad2Deg * Time.time;

		pos.x = Mathf.Cos(rad) * circle_radius;

		pos.y = Mathf.Sin(rad) * circle_radius;

		transform.position = pos;
	}
}
