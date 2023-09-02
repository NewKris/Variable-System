using System;
using CoffeeBara.VariableSystem.Attribute;

namespace CoffeeBara.VariableSystem
{
	[Serializable]
	public struct VariableRequirement
	{
		[VariableReference] public string key;
		
		public bool expectedBooleanValue;
		public string expectedStringValue;
		public int minIntegerValue;
		public int maxIntegerValue;
		public bool invertIntegerValue;
	}
}