/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using UnityEngine;
using UnityEngine.Serialization;

public class TestEditor : EditorWindow //Arv, heritage of the editorwindow
{
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private Variables.FloatVariable floatVariable;
    [SerializeField] private VisualTreeAsset uxmlFile;
    [MenuItem("Tools/Settings")]//Making sure I can access the Editor in the top under Tools
    public static void ShowMyEditor() //Adding the Window in the editor
    {
        EditorWindow window = GetWindow<TestEditor>();
        window.titleContent = new GUIContent("Settings");
    }

    private void CreateGUI() //This creates the UI in the Window we created earlier
    {
        uxmlFile.CloneTree(rootVisualElement);//It clones the UI Toolkit to the window
        Bind();
    }

    private void Bind()//Everything here makes sure that the scriptable object changes values when we change values in the UI
    {
        rootVisualElement.Bind(new SerializedObject(gameSettings)); //If we only have one scriptable object we can do this. It binds the variables from the games settings scriptable object
        /* root = rootVisualElement.Q<VisualElement>("Root");//Q stands for quarry. Since we have two scriptable objects we need to make a reference to the tree name in the hiearchy in the UI Toolkit
        root.Bind(new SerializedObject(gameSettings));
        var secondroot = rootVisualElement.Q<VisualElement>("SecondRoot");
        secondroot.Bind(new SerializedObject(floatVariable));
        var filipsKnapp = rootVisualElement.Q<Button>("FilipsKnapp");//The same thing needs to be done with a button. 
        filipsKnapp.clicked += TestPrintFunction;*/
    /*}

    void TestPrintFunction()
    {
        Debug.Log("Hey Fillip");
    }
}*/
