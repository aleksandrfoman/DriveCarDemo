﻿using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Packs.Epic_Toon_FX.Demo.Scripts.VFX_Library
{

public enum ButtonTypes {
	NotDefined,
	Previous,
	Next
}

public class PEButtonScript : MonoBehaviour, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler {
	#pragma warning disable 414
	private Button myButton;
	#pragma warning disable 414
	public ButtonTypes ButtonType = ButtonTypes.NotDefined;

	// Use this for initialization
	void Start () {
		myButton = gameObject.GetComponent<Button> ();
	}

	public void OnPointerEnter(PointerEventData eventData) {
		// Used for Tooltip
		UICanvasManager.GlobalAccess.MouseOverButton = true;
		UICanvasManager.GlobalAccess.UpdateToolTip (ButtonType);
	}

	public void OnPointerExit(PointerEventData eventData) {
		// Used for Tooltip
		UICanvasManager.GlobalAccess.MouseOverButton = false;
		UICanvasManager.GlobalAccess.ClearToolTip ();
	}

	public void OnButtonClicked () {
		// Button Click Actions
		UICanvasManager.GlobalAccess.UIButtonClick(ButtonType);
	}
}
}