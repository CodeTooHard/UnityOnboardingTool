using UnityEditor;
using UnityEngine;

public class Example : EditorWindow
{
    ProfilerWindow m_Profiler;
    long m_SelectedFrameIndex;

    [MenuItem("Window/Analysis/Profiler Extension")]
    public static void ShowExampleWindow()
    {
        GetWindow<Example>();
    }

    void OnEnable()
    {
        // Make sure there is an open Profiler Window.
        if (m_Profiler == null)
            m_Profiler = EditorWindow.GetWindow<ProfilerWindow>();

        // Subscribe to the Profiler window's SelectedFrameIndexChanged event.
        m_Profiler.SelectedFrameIndexChanged += OnProfilerSelectedFrameIndexChanged;
    }

    private void OnGUI()
    {
        GUILayout.Label($"The selected frame in the Profiler window is {m_SelectedFrameIndex}.");
    }

    private void OnDisable()
    {
        // Unsubscribe from the Profiler window's SelectedFrameIndexChanged event.
        m_Profiler.SelectedFrameIndexChanged -= OnProfilerSelectedFrameIndexChanged;
    }

    void OnProfilerSelectedFrameIndexChanged(long selectedFrameIndex)
    {
        // Update the GUI with the selected Profiler frame.
        m_SelectedFrameIndex = selectedFrameIndex;
        Repaint();
    }
}
