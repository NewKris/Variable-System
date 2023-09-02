using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace CoffeeBara.VariableSystem.Editor
{
	public class VariableListSearchWindow : ScriptableObject, ISearchWindowProvider
	{
		private static Texture2D IndentTexture;

		public string[] options;
		public Action<string> callback;

		public List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context)
		{
			List<SearchTreeEntry> searchTreeEntries = new List<SearchTreeEntry>();
			List<string> groups = new List<string>();

			if (!IndentTexture) IndentTexture = CreateIndentTexture();

			searchTreeEntries.Add(CreateGroup("Variables", 0));
			foreach (string option in options)
			{
				if(string.IsNullOrEmpty(option)) continue;
				
				string[] path = option.Split("/");
				string groupName = "";
				for (int i = 0; i < path.Length - 1; i++)
				{
					groupName += path[i];

					if (!groups.Contains(groupName))
					{
						searchTreeEntries.Add(CreateGroup(path[i], i + 1));
						groups.Add(groupName);
					}
					
					groupName += "/";
				}

				SearchTreeEntry entry = CreateEntry(path.Last());
				entry.level = path.Length;
				entry.userData = option;
				searchTreeEntries.Add(entry);
			}
			
			return searchTreeEntries;
		}

		public bool OnSelectEntry(SearchTreeEntry searchTreeEntry, SearchWindowContext context)
		{
			callback?.Invoke((string) searchTreeEntry.userData);
			return true;
		}

		private SearchTreeEntry CreateEntry(string value)
		{
			return new SearchTreeEntry(new GUIContent(value, IndentTexture));
		}

		private SearchTreeGroupEntry CreateGroup(string groupName, int level)
		{
			return new SearchTreeGroupEntry(new GUIContent(groupName), level);
		}

		private Texture2D CreateIndentTexture()
		{
			Texture2D indent = new Texture2D(1, 1);
			indent.SetPixel(0, 0, Color.clear);
			indent.Apply();
			return indent;
		}
	}
}