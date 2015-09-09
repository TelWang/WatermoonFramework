using WaterMoon.IntelliPool;
namespace WaterMoon.BufferIntelliPool
{
    public interface IBufferPool : IPool<byte[]>
    {
        int BufferSize { get; }
    }
}
