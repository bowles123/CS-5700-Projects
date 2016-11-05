using Stocks;

namespace Panels
{
    public interface Observer
    {
        void update(Subject stock);
    }
}
