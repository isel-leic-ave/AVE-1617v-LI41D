
using System;
using System.Reflection;

public class Program : Object {
	// Membros
	
	// Fields
	private int instanceField = 0; // Instance Field
    private int anotherInstanceField = 0; // Instance Field
    private static int classField = 1; // Class Field


    // Class Constructor (.cctor in IL) 
    static Program()
    {

    }

    // Instance constructor (.ctor in IL)
    public Program()
    {

    }

    // Another Instance constructor (.ctor in IL)
    public Program(int instanceField)
    {
        this.instanceField = instanceField;
    }

    public override string ToString()
    {
        return instanceField.ToString();
    }

    // Methods

    // Instance Method
    public void InstanceMethod()
    {
        Console.WriteLine("Instance method called");
    } 
	public static void ClassMethod() { } // Class Method

    private void AnotherInstanceMethod() { } // Instance Method
    private static void AnotherClassMethod() { } // Instance Method

    // Acessor methods - old fashhined way (aka. Java way!)
    //public int GetInstanceField() {
    //    return instanceField;
    //}

    //public void SetInstanceField(int newValue) {
    //    instanceField = newValue;
    //}

    // Property
    public int SomeProperty
    {
        get { return anotherInstanceField; }
        set { anotherInstanceField = value; }
    }

    // Automatic property
    public int AnotherProperty
    {
        get; set;
    }


    // Other Types
    class InnerClass {
		
	}
	
	public static void Main() {
		Console.WriteLine("Using reflection API");
		
		Type t = typeof(Program);
		
		ShowMembers(t);
	    CreateInstances(t);
	    AcessingProperties();
	    InvokingInstanceMethods(t);
	    AcessingPropertiesThroughReflection(t);
	    AcessingFieldsThroughReflection(t);


	    // Create a new Object through Constructor Info
	}

    private static void AcessingFieldsThroughReflection(Type t)
    {
        Program p1 = new Program();
        // Acessing private fields
        FieldInfo fieldInfo = t.GetField("anotherInstanceField", BindingFlags.Instance | BindingFlags.NonPublic);
        int valField = (int) fieldInfo.GetValue(p1);
        Console.WriteLine(valField);

        fieldInfo.SetValue(p1, 20);
        Console.WriteLine(p1.anotherInstanceField);
    }

    private static void AcessingPropertiesThroughReflection(Type t)
    {
        Program p1 = new Program();
        // Reflection API to access properties
        PropertyInfo propertyInfo = t.GetProperty("SomeProperty");
        int val = (int) propertyInfo.GetMethod.Invoke(p1, null);
        Console.WriteLine(val);

        propertyInfo.SetMethod.Invoke(p1, new Object[] {15});

        Console.WriteLine(p1.SomeProperty);
    }

    private static void InvokingInstanceMethods(Type t)
    {
        Program p1 = new Program();
        p1.InstanceMethod();
        // Invoking instance method through reflection API
        MethodInfo m = t.GetMethod("InstanceMethod");
        Console.WriteLine(m.ToString());
        m.Invoke(p1, null);
    }

    private static void AcessingProperties()
    {
        Program p1 = new Program();
        Console.WriteLine(p1.AnotherProperty);
        p1.AnotherProperty = 10;
    }

    private static void CreateInstances(Type t)
    {
        Program p = new Program(2);
        Console.WriteLine(p.ToString());

        Program p1 = (Program) Activator.CreateInstance(t);
        Console.WriteLine(p1.ToString());

        Program p2 = (Program) Activator.CreateInstance(t, new Object[] {3});
        Console.WriteLine(p2.ToString());
    }

    private static void ShowMembers(Type t)
    {
        MemberInfo[] mi = t.GetMembers(BindingFlags.NonPublic);
        for (int i = 0; i < mi.Length; ++i)
        {
            Console.WriteLine(mi[i].Name);
        }
    }
}
