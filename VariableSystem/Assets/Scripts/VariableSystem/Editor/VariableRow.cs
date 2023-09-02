using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace CoffeeBara.VariableSystem.Editor
{
	public class VariableRow : VisualElement
	{
		private Variable _variable;
		private TextField _key;
		private TextField _stringValue;
		private Toggle _booleanValue;
		private IntegerField _integerValue;
		private Action _setDirtyCallback;

		public Variable VariableData => _variable;
		
		public VariableRow(Variable variable, Action<VariableRow> onRemoveRow, Action setDirtyCallback)
		{
			_variable = variable;
			_setDirtyCallback = setDirtyCallback;
			
			_key = new TextField("Key: ") {value = variable.key};
			_key.AddStyleClass(StyleUtility.VariableRowKeyStyle);
			_key.RegisterValueChangedCallback((e) => ValueChanged());

			_booleanValue = new Toggle("Boolean Value: ") {value = variable.booleanValue};
			_booleanValue.AddStyleClass(StyleUtility.VariableRowToggleStyle);
			_booleanValue.RegisterValueChangedCallback((e) => ValueChanged());

			_integerValue = new IntegerField("Integer Value: ") {value = variable.integerValue};
			_integerValue.AddStyleClass(StyleUtility.VariableRowInputStyle);
			_integerValue.RegisterValueChangedCallback((e) => ValueChanged());

			_stringValue = new TextField("String Value: ") {value = variable.stringValue};
			_stringValue.AddStyleClass(StyleUtility.VariableRowInputStyle);
			_stringValue.RegisterValueChangedCallback((e) => ValueChanged());

			Button removeRow = new Button(() => onRemoveRow(this)) {text = "x"};
			removeRow.AddStyleClass(StyleUtility.VariableRowDeleteStyle);
			
			Add(removeRow);
			Add(_key);
			Add(_booleanValue);
			Add(_integerValue);
			Add(_stringValue);
			
			this.AddStyleClass(StyleUtility.VariableRowStyle);
		}

		private void ValueChanged()
		{
			_variable.key = _key.value;
			_variable.booleanValue = _booleanValue.value;
			_variable.integerValue = _integerValue.value;
			_variable.stringValue = _stringValue.value;
			_setDirtyCallback();
		}
	}
}
