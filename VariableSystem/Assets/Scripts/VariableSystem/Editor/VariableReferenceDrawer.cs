using System;
using System.Linq;
using CoffeeBara.VariableSystem.Attribute;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace CoffeeBara.VariableSystem.Editor
{
	[CustomPropertyDrawer(typeof(VariableReference))]
	public class VariableReferenceDrawer : PropertyDrawer
	{
		private static VariableDatabase Database;
		private static VariableListSearchWindow VariableSearchWindow;
		
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			if (!Database)
				LoadDatabase();

			if (!Database)
			{
				GUI.Label(position, "Missing Variable Database!");
				return;
			}

			if (!VariableSearchWindow)
			{
				VariableSearchWindow = (VariableListSearchWindow) ScriptableObject.CreateInstance(typeof(VariableListSearchWindow));
			}
			
			string[] options = Database.variables.Select(variable => variable.key).ToArray();

			Rect labelRect = position;
			labelRect.width = position.width * 0.4f;

			Rect buttonRect = position;
			buttonRect.width = position.width * 0.6f;
			buttonRect.position = new Vector2(labelRect.width, position.y);
			
			GUI.Label(labelRect, label);
			
			if (GUI.Button(buttonRect, property.stringValue, EditorStyles.popup))
			{
				VariableSearchWindow.options = options;
				VariableSearchWindow.callback = (value) =>
				{
					property.stringValue = value;
					property.serializedObject.ApplyModifiedProperties();
				};
				SearchWindow.Open(new SearchWindowContext(GUIUtility.GUIToScreenPoint(Event.current.mousePosition)), VariableSearchWindow);
			}
		}
		
		private void LoadDatabase()
		{
			string[] guids = AssetDatabase.FindAssets("t:VariableDatabase");
			if (guids.Length == 0)
			{
				Debug.LogWarning("No Variable Database found in project!");
				return;
			}

			Database = AssetDatabase.LoadAssetAtPath<VariableDatabase>(AssetDatabase.GUIDToAssetPath(guids[0]));
		}
	}
}