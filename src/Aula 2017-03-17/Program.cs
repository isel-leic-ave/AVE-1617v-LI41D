
using System;
using System.Reflection;

public class Program : Object {
	// Membros
	
	// Fields
	private int instanceField; // Instance Field
	private static int classField; // Class Field
	
	
	// Methods
	public void instanceMethod() { } // Instance Method
	public static void classMethod() { } // Class Method
	
	
	// Other Types
	class InnerClass {
		
	}
	
	public static void Main() {
		Console.Write("Using reflection API");
		
		Type t = typeof(Program);
		
		MemberInfo[] mi = t.GetMembers();
		for(int i = 0; i < mi.Length; ++ i) {
				Console.WriteLine(mi[i].Name);
		}
	}

}
