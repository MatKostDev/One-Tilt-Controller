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

    private Material m_initialMaterial;

    private MeshRenderer m_meshRenderer;

    private void Awake()
    {
	    m_meshRenderer = GetComponent<MeshRenderer>();

	    m_initialMaterial = m_meshRenderer.material;
    }

    private void OnMouseDown()
    {
	    m_meshRenderer.material = selectedMaterial;
    }

    private void OnMouseUp()
    {
	    m_meshRenderer.material = m_initialMaterial;
    }

    private void Update()
    {
	    if (DoesButtonExist(inputButtonName))
		{
			if (Input.GetButtonDown(inputButtonName))
			{
				m_meshRenderer.material = selectedMaterial;
			}

			if (Input.GetButtonUp(inputButtonName))
			{
				m_meshRenderer.material = m_initialMaterial;
			}
		}

	    if ( DoesAxisExist(inputAxisName))
	    {
		    if (Input.GetAxisRaw(inputAxisName) > 0.2f)
			{
				m_meshRenderer.material = selectedMaterial;
			} 
		    else
			{
				m_meshRenderer.material = m_initialMaterial;
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
