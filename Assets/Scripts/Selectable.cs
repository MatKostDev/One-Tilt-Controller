using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    [SerializeField]
    private Material selectedMaterial = null;

    [SerializeField]
    private string inputButtonName;

    [SerializeField]
    private string inputAxisName;

    [SerializeField]
    private bool trigger = false;

    private Material m_initialMaterial;

    private MeshRenderer m_meshRenderer;

    private Animator m_animator;

    private void Awake()
    {
	    m_meshRenderer = GetComponent<MeshRenderer>();
	    m_animator     = GetComponent<Animator>();

	    m_initialMaterial = m_meshRenderer.material;
    }

    private void OnMouseDown()
    {
	    m_meshRenderer.material = selectedMaterial;
	    
	    m_animator.Play("Press");
    }

    private void OnMouseUp()
    {
	    m_meshRenderer.material = m_initialMaterial;

	    m_animator.Play("Release");
	}

    private void Update()
    {
	    if (DoesButtonExist(inputButtonName))
		{
			if (Input.GetButtonDown(inputButtonName))
			{
				m_meshRenderer.material = selectedMaterial;

				m_animator.Play("Press");
			}

			if (Input.GetButtonUp(inputButtonName))
			{
				m_meshRenderer.material = m_initialMaterial;

				m_animator.Play("Release");
			}
		}

	    if (DoesAxisExist(inputAxisName))
	    {
		    if (Input.GetAxisRaw(inputAxisName) > 0.2f)
			{
				m_meshRenderer.material = selectedMaterial;

				if (trigger)
				{
					m_animator.Play("Press");
				}
			} 
		    else
			{
				m_meshRenderer.material = m_initialMaterial;

				if (trigger)
				{
					m_animator.Play("Release");
				}
			}
	    }
    }

    bool DoesAxisExist(string a_name)
    {
	    try
	    {
		    Input.GetAxis(a_name);
		    return true;
	    }
	    catch (ArgumentException exc)
	    {
		    return false;
	    }
    }

    bool DoesButtonExist(string a_name)
    {
	    try
	    {
		    Input.GetButton(a_name);
		    return true;
	    }
	    catch (ArgumentException exc)
	    {
		    return false;
	    }
    }
}
