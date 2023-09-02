using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace CoffeeBara.VariableSystem.Editor
{
	public class SearchField : VisualElement
	{
		public SearchField(Action<string> onSearchValueChanged)
		{
			Texture searchIconTexture = EditorGUIUtility.IconContent("d_search Icon").image;
			Image searchImage = new Image() {image = searchIconTexture};
			searchImage.AddStyleClass(StyleUtility.SearchFieldIconStyle);
			
			TextField searchInput = new TextField();
			searchInput.RegisterValueChangedCallback((e) => onSearchValueChanged(e.newValue));
			searchInput.AddStyleClass(StyleUtility.SearchFieldInputStyle);
			
			Button clearButton = new Button(() => searchInput.value = "" ) {text = "x"};
			clearButton.AddStyleClass(StyleUtility.SearchFieldClearStyle);

			Add(searchImage);
			Add(searchInput);
			Add(clearButton);
		}
	}
}