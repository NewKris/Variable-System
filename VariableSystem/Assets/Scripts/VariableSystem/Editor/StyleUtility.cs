using System.Collections.Generic;
using UnityEngine.UIElements;

namespace CoffeeBara.VariableSystem.Editor
{
	public static class StyleUtility
	{
		public static readonly string StyleSheetPath = "VariableAuthor/VariableAuthor.uss";

		public static readonly string VariableAuthorStyle = "variable-author";

		public static readonly string SearchFieldStyle = "search-field";
		
		public static readonly string SearchFieldInputStyle = "search-field__input";

		public static readonly string SearchFieldIconStyle = "search-field__icon";
		
		public static readonly string SearchFieldClearStyle = "search-field__clear";

		public static readonly string AddRowStyle = "add-row";

		public static readonly string VariableContainerStyle = "variable-container";

		public static readonly string VariableRowStyle = "variable-row";

		public static readonly string VariableRowKeyStyle = "variable-row__key";
		
		public static readonly string VariableRowToggleStyle = "variable-row__toggle";
		
		public static readonly string VariableRowInputStyle = "variable-row__input";

		public static readonly string VariableRowDeleteStyle = "variable-row__delete";
		
		public static void AddStyleClass(this VisualElement visualElement, params string[] styleClasses)
		{
			foreach (string styleClass in styleClasses)
				visualElement.AddToClassList(styleClass);
		}
	}
}