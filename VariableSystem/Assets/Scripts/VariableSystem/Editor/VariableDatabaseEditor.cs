using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace CoffeeBara.VariableSystem.Editor
{
	[CustomEditor(typeof(VariableDatabase))]
	public class VariableDatabaseEditor : UnityEditor.Editor
	{
		private VariableDatabase _database;
		private VariableRowContainer _container;

		public override VisualElement CreateInspectorGUI()
		{
			_database = target as VariableDatabase;

			if (!_database) return null;
			
			VisualElement root = new VisualElement();
			
			StyleSheet styleSheet = EditorGUIUtility.Load(StyleUtility.StyleSheetPath) as StyleSheet;
			root.styleSheets.Add(styleSheet);
			
			root.AddStyleClass(StyleUtility.VariableAuthorStyle);

			_container = new VariableRowContainer(_database);
			_container.AddStyleClass(StyleUtility.VariableContainerStyle);
			
			SearchField searchField = new SearchField((searchQuery) => _container.FilterRows(searchQuery));
			searchField.AddStyleClass(StyleUtility.SearchFieldStyle);
			
			Button addNewRowButton = new Button(() => _container.CreateNewVariable()) {text = "+"};
			addNewRowButton.AddStyleClass(StyleUtility.AddRowStyle);
			
			root.Add(searchField);
			root.Add(addNewRowButton);
			root.Add(_container);

			return root;
		}
	}
}