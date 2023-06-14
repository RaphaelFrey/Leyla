using System.Diagnostics;
using System.Runtime.Serialization;

namespace LeylaEditor.Components;

public interface IMSComponent {}

[DataContract]
public abstract class Component : ViewModelBase
{
    [DataMember]
    public GameEntity Owner { get; set; }
    public Component(GameEntity entity)
    {
        Debug.Assert(entity != null);
        Owner = entity;
    }
}

public abstract class MSComponent<T> : ViewModelBase, IMSComponent where T : Component
{
    
}