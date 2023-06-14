using System.Diagnostics;
using System.Runtime.Serialization;

namespace LeylaEditor.Components;

[DataContract]
public class Component : ViewModelBase
{
    [DataMember]
    public GameEntity Owner { get; set; }
    public Component(GameEntity entity)
    {
        Debug.Assert(entity != null);
        Owner = entity;
    }
}