using System;
using System.Linq;
using CoffeeBara.VariableSystem;
using CoffeeBara.VariableSystem.Attribute;
using UnityEngine;

namespace CoffeeBara
{
	public class MockGame : MonoBehaviour
	{
		public VariableDatabase database;
		
		[VariableReference]
		public string keyTest;

		private void Start()
		{
			Debug.Log(database.variables.First(x => x.key == keyTest).stringValue);
		}
	}
}
