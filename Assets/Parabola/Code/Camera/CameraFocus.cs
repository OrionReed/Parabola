using UnityEngine;
using System.Collections;
using GameEye2D.Focus;
using GameEye2D.Behaviour;

public class CameraFocus : F_RigidBody2D
{
    Camera2D m_Camera2D;

    void OnEnable()
    {
        m_Camera2D = Camera.main.GetComponent<Camera2D>();
        if (m_Camera2D != null)
        {
            m_Camera2D.AddFocus(this);
        }
    }

    void OnDisable()
    {
        if (m_Camera2D != null)
        {
            m_Camera2D.RemoveFocus(this);
        }
    }
}
