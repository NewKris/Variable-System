using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace CoffeeBara.VariableSystem.Editor
{
	public class VariableRowContainer : VisualElement
	{

		private readonly VariableDatabase _database;
		private readonly List<VariableRow> _rows;

		public VariableRowContainer(VariableDatabase database)
		{
			_database = database;
			_rows = new List<VariableRow>();
			
			if(database.variables == null) return;
			
			foreach (Variable variable in database.variables)
			{
				CreateNewVariableRow(variable);
			}
		}

		public void CreateNewVariable()
		{
			Variable variable = new Variable();

			if (_database.variables == null)
			{
				_database.variables = new List<Variable>();
			}
			
			_database.variables.Add(variable);
			MarkDatabaseAsDirty();
			
			CreateNewVariableRow(variable);
		}

		public void FilterRows(string searchQuery)
		{
			searchQuery = searchQuery.Trim();
			
			foreach (VariableRow row in _rows)
			{
				bool match = Regex.IsMatch(row.VariableData.key, searchQuery);
				DisplayStyle displayStyle = match ? DisplayStyle.Flex : DisplayStyle.None;
				row.style.display = displayStyle;
			}
		}
		
		private void CreateNewVariableRow(Variable variable)
		{
			VariableRow row = new VariableRow(variable, RemoveRow, MarkDatabaseAsDirty);

			_rows.Add(row);
			Add(row);
		}

		private void RemoveRow(VariableRow row)
		{
			_database.Remove(row.VariableData);
			_rows.Remove(row);
			Remove(row);
			
			MarkDatabaseAsDirty();
		}

		private void MarkDatabaseAsDirty()
		{
			EditorUtility.SetDirty(_database);
		}
	}
}