using VTS.Core;

namespace StreamingApp.API.VTubeStudio;

public interface IVTubeStudioApiRequest
{
    Task Initalize();
    Task AddItem();
    Task ChangeColour();
    Task ChangeLocaton(float x, float y, float r, float size);
    Task<ModelPosition> GetPosData();
    Task SendRequest();
}