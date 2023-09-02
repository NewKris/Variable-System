using System.Collections.Generic;
using UnityEngine;

namespace CoffeeBara.VariableSystem
{
	[CreateAssetMenu(fileName = "Variable Database")]
	public class VariableDatabase : ScriptableObject
	{
		public List<Variable> variables;

		public void Add(Variable variable)
		{
			variables.Add(variable);
		}

		public void Remove(Variable variable)
		{
			variables.Remove(variable);
		}
	}
}