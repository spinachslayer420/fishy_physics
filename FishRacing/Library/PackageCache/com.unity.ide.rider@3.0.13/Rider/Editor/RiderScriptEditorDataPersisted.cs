using System;
using UnityEditor;
using UnityEngine;

namespace Packages.Rider.Editor
{
#if UNITY_2020_1_OR_NEWER // API doesn't exist in 2019.4
  [FilePath("ProjectSettings/RiderScriptEditorPersistedState.asset", FilePathAttribute.Location.ProjectFolder)]
#endif
  internal class RiderScriptEditorPersistedState : ScriptableSingleton<RiderScriptEditorPersistedState>
  {
    [SerializeField] private long lastWriteTicks;

    public DateTime? LastWrite
    {
      get => DateTime.FromBinary(lastWriteTicks);
      set
      {
        if (!value.HasValue) return;
        lastWriteTicks = value.Value.ToBinary();
        Save(true);
      }
    }
  }
}